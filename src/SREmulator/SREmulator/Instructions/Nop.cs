using System.Reflection.Emit;
using SREmulator.Reader;

namespace SREmulator.Instructions {
    internal class Nop : InstructionBase {
        public override OpCode OpCode => OpCodes.Nop;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) { }
    }
}
