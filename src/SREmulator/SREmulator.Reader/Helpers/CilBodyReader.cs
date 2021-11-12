using System;
using SREmulator.Reader.Decoders;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Reflection.Emit;

namespace SREmulator.Reader.Helpers {
    internal class CilBodyReader {
        internal CilContext Context { get; }
        public byte[] ILBuffer { get; }
        private BinaryReader Reader { get; set; }

        internal CilBodyReader(CilContext context, byte[] buffer) {
            Context = context;
            ILBuffer = buffer;

            Reader = new BinaryReader(new MemoryStream(buffer));
        }

        internal List<CilInstruction> Read() {
            List<CilInstruction> instructions = new();

            while (Reader.BaseStream.Position < Reader.BaseStream.Length)
                instructions.Add(ReadInstruction());

            return instructions;
        }

        CilInstruction ReadInstruction() {
            var opcode = ReadOpCode();
            var operand = ReadOperand(opcode);

            return new() { 
                OpCode = opcode,
                Operand = operand
            };
        }

        object ReadOperand(OpCode opCode) {
            switch (opCode.OperandType) {
                case OperandType.InlineNone:
                    return null;

                case OperandType.ShortInlineBrTarget:
                    return Reader.ReadSByte();

                case OperandType.InlineI8:
                    return Reader.ReadInt64();

                case OperandType.InlineVar:
                    return Reader.ReadUInt16();

                case OperandType.ShortInlineI:
                case OperandType.ShortInlineVar:
                    return Reader.ReadByte();

                case OperandType.InlineString:
                    return ReadString(Reader.ReadInt32()); 

                case OperandType.InlineTok:
                case OperandType.InlineSig:
                case OperandType.InlineType:
                case OperandType.InlineField:
                case OperandType.InlineMethod:
                    return new CilToken(Reader.ReadInt32());

                case OperandType.InlineI:
                case OperandType.InlineBrTarget:
                    return Reader.ReadInt32();

                case OperandType.ShortInlineR:
                    return Reader.ReadSingle();

                case OperandType.InlineR:
                    return Reader.ReadDouble();
            }

            throw new NotImplementedException("Operand type has not yet been supported.");
        }

        string ReadString(int mdtoken)
            => Context.MDReader.GetUserString(MetadataTokens.UserStringHandle(mdtoken));

        OpCode ReadOpCode() {
            var op = Reader.ReadByte();
            if (op == 0xFE) // Two byte opcode
                return CilCodeHelper.TwoByteOpCodes[(op << 8) | Reader.ReadByte()];
            return CilCodeHelper.OneByteOpCodes[op];
        }
    }
}
