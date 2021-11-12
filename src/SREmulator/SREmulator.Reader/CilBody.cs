using SREmulator.Reader.Decoders;
using SREmulator.Reader.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SREmulator.Reader {
    public class CilBody {
        internal CilContext Context { get; }

        public MethodBodyBlock MethodBodyInfo { get; }

        public byte[] BodyBuffer { get; }

        public List<CilInstruction> Instructions {
            get {
                return cilInstructions ??= ReadInstructions();
            }
        }

        internal CilBody(CilMethod method) {
            Context = method.Context;

            MethodBodyInfo = Context.PEReader.GetMethodBody(method.RVA);

            BodyBuffer = MethodBodyInfo.GetILBytes();
        }

        private List<CilInstruction> ReadInstructions() {
            var reader = new CilBodyReader(Context, BodyBuffer);
            return reader.Read();
        }

        private List<CilInstruction> cilInstructions;
    }
}
