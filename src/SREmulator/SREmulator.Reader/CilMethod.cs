using SREmulator.Reader.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SREmulator.Reader {
    public class CilMethod : CilToken {
        internal CilContext Context { get; }

        internal SignatureDecoder<CilType, CilToken> SigDecoder {
            get {
                return new SignatureDecoder<CilType, CilToken>(DeclaringType, Context.MDReader, null);
            }
        }

        public MethodDefinition MethodDefinition { get; }

        public CilType DeclaringType { get; }

        #region Method properties
        public CilBody CilBody {
            get {
                return cilBody ??= new CilBody(this);
            }
        }

        public MethodAttributes MethodAttributes {
            get {
                return MethodDefinition.Attributes;
            }
        }

        public MethodImplAttributes ImplAttributes {
            get {
                return MethodDefinition.ImplAttributes;
            }
        }

        public int RVA {
            get {
                return MethodDefinition.RelativeVirtualAddress;
            }
        }

        public bool HasBody {
            get {
                // RVA (0) means method has no body
                return RVA != 0;
            }
        }

        public string Name {
            get {
                return this.methodName ??= Context.Resolve(MethodDefinition.Name);
            }
        }
        #endregion

        internal CilMethod(CilType type, MethodDefinition method, CilToken token)
            : base(token) {
            Context = type.Context;
            MethodDefinition = method;
            DeclaringType = type;
        }

        public void Test() {
            var blob = Context.MDReader.GetBlobReader(MethodDefinition.Signature);
            var sig = SigDecoder.DecodeMethodSignature(ref blob);

        }

        private string methodName;
        private CilBody cilBody;
    }
}
