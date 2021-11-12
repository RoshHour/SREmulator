using System;
using System.Reflection.Metadata;

namespace SREmulator {
    public class SRElement {
        public object Value { get; set; }
        public PrimitiveTypeCode PrimitiveTypeCode { get; set; }

        public static SRElement CreateSRElement(object obj) {
            if (obj is bool) {
                return new(obj, PrimitiveTypeCode.Boolean);
            }
            else if (obj is char) {
                return new(obj, PrimitiveTypeCode.Char);
            }
            else if (obj is sbyte) {
                return new(obj, PrimitiveTypeCode.SByte);
            }
            else if (obj is byte) {
                return new(obj, PrimitiveTypeCode.Int16);
            }
            else if (obj is short) {
                return new(obj, PrimitiveTypeCode.UInt16);
            }
            else if (obj is ushort) {
                return new(obj, PrimitiveTypeCode.Int32);
            }
            else if (obj is int) {
                return new(obj, PrimitiveTypeCode.Int32);
            }
            else if (obj is uint) {
                return new(obj, PrimitiveTypeCode.UInt32);
            }
            else if (obj is long) {
                return new(obj, PrimitiveTypeCode.Int64);
            }
            else if (obj is ulong) {
                return new(obj, PrimitiveTypeCode.UInt64);
            }
            else if (obj is float) {
                return new(obj, PrimitiveTypeCode.Single);
            }
            else if (obj is double) {
                return new(obj, PrimitiveTypeCode.Double);
            }
            else if (obj is string) {
                return new(obj, PrimitiveTypeCode.String);
            }
            else if (obj is IntPtr) {
                return new(obj, PrimitiveTypeCode.IntPtr);
            }
            else if (obj is UIntPtr) {
                return new(obj, PrimitiveTypeCode.UIntPtr);
            }

            return new(obj, PrimitiveTypeCode.Object);
        }
        
        private SRElement(object obj, PrimitiveTypeCode primitiveType) {
            this.Value = obj;
            this.PrimitiveTypeCode = primitiveType;
        }

        public T Get<T>() {
            return (T)Convert.ChangeType(this.Value, typeof(T));
        }

        public override string ToString() {
            return this.Value.ToString();
        }
    }
}
