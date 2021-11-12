using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SREmulator.Reader {
    public class CilToken : IEquatable<CilToken> {
        internal static CilToken Create(EntityHandle handle) {
            var mdtoken = MetadataTokens.GetToken(handle);
            var rid = MetadataTokens.GetRowNumber(handle);
            return new(mdtoken, rid);
        }

        public int Token { get; }
        public int RID { get; }

        public CilToken(int token) {
            Token = token;
        }

        public CilToken(int token, int rid) {
            Token = token;
            RID = rid;
        }

        public CilToken(CilToken cilToken) {
            Token = cilToken.Token;
            RID = cilToken.RID;
        }

        public int ToInt32() {
            return Token;
        }

        public uint ToUInt32() {
            return unchecked((uint)Token);
        }

        public bool Equals(CilToken other) {
            if (ReferenceEquals(other, null))
                return false;
            else if (ReferenceEquals(this, other))
                return true;

            return this.Token == other.Token && this.RID == other.RID;
        }
    }
}
