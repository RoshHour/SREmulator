using System.Reflection.Emit;
using SREmulator.Reader;

namespace SREmulator.Instructions {
    internal class Br : InstructionBase {
        public override OpCode OpCode => OpCodes.Br;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.InstructionPointer += (int)cilInstruction.Operand;
        }
    }

    internal class Br_S : InstructionBase {
        public override OpCode OpCode => OpCodes.Br_S;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.InstructionPointer += (sbyte)cilInstruction.Operand;
        }
    }
}