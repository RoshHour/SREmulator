using System.Reflection.Emit;
using SREmulator.Reader;

namespace SREmulator.Instructions {
    abstract class InstructionBase {
        abstract public OpCode OpCode { get; }
        abstract public void Emulate(SRContext context, CilInstruction cilInstruction);
    }
}
