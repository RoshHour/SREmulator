using System.Reflection;
using System.Reflection.Emit;

namespace SREmulator.Reader.Decoders {
    public static class CilCodeHelper {
        /// <summary>
        /// One byte OpCodes
        /// </summary>
        public static OpCode[] OneByteOpCodes = new OpCode[0x100];

        /// <summary>
        /// Two byte OpCodes (first byte is always 0xFE)
        /// </summary>
        public static OpCode[] TwoByteOpCodes = new OpCode[0x100];

        static CilCodeHelper() {
            var opcodeType = typeof(OpCode);

            var fields = typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var field in fields) {
                if (field.FieldType != opcodeType)
                    continue;

                OpCode opcode = (OpCode)field.GetValue(null);
                var value = (ushort)opcode.Value;
                if (value < 0x100) {
                    OneByteOpCodes[value] = opcode;
                }
                else {
                    TwoByteOpCodes[value & 0xFF] = opcode;
                }
            }
        }
    }
}
