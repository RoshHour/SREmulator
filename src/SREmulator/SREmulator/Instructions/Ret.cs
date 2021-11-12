using System.Reflection.Emit;
using SREmulator.Reader;

namespace SREmulator.Instructions {
    internal class Ret : InstructionBase {
        public override OpCode OpCode => OpCodes.Ret;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Running = false;
        }
    }
}
