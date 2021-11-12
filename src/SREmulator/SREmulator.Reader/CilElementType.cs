using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SREmulator.Reader {
    public class CilElementType : CilType {
        public PrimitiveTypeCode TypeCode { get; }

        public CilElementType(PrimitiveTypeCode typeCode)
            : base("System", Enum.GetName(typeof(PrimitiveTypeCode), typeCode)) {
            TypeCode = typeCode;
        }
    }
}
