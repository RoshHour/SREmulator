using System.Text;
using System.Reflection.Emit;

namespace SREmulator.Reader {
    public class CilInstruction {
        public OpCode OpCode { get; set; }
        public object Operand { get; set; }

        public override string ToString() {
            var str = new StringBuilder();

            str.Append(OpCode);

            if (Operand is not null) {
                str.Append(" ");
                str.Append(Operand);
            }

            return str.ToString();
        }
    }
}
