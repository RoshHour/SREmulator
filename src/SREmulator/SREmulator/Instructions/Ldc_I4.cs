using System.Reflection.Emit;
using SREmulator.Reader;

namespace SREmulator.Instructions {
    internal class Ldc_I4 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(cilInstruction.Operand));
        }
    }

    internal class Ldc_I4_S : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_S;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(cilInstruction.Operand));
        }
    }

    internal class Ldc_I4_1 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_1;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(1));
        }
    }

    internal class Ldc_I4_2 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_2;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(2));
        }
    }

    internal class Ldc_I4_3 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_3;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(3));
        }
    }

    internal class Ldc_I4_4 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_4;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(4));
        }
    }

    internal class Ldc_I4_5 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_5;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(5));
        }
    }

    internal class Ldc_I4_6 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_6;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(6));
        }
    }

    internal class Ldc_I4_7 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_7;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(7));
        }
    }

    internal class Ldc_I4_8 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_8;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(8));
        }
    }

    internal class Ldc_I4_M1 : InstructionBase {
        public override OpCode OpCode => OpCodes.Ldc_I4_M1;

        public override void Emulate(SRContext context, CilInstruction cilInstruction) {
            context.Stack.Push(SRElement.CreateSRElement(-1));
        }
    }
}
