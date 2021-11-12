using System.Reflection.Emit;
using SREmulator.Reader;

namespace SREmulator.Instructions {
    internal class Add : InstructionBase {
        public override OpCode OpCode => OpCodes.Add;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            var right = context.Stack.Pop().Get<int>();
            var left = context.Stack.Pop().Get<int>();

            context.Stack.Push(SRElement.CreateSRElement(left + right));
        }
    }
}
