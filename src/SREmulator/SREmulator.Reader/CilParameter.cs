using SREmulator.Reader.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace SREmulator.Reader {
    public class CilParameter {
        internal CilContext Context { get; }

        public Parameter Parameter { get; }

        #region Parameter properties
        public ParameterAttributes Attributes {
            get {
                return Parameter.Attributes;
            }
        }

        public int Index {
            get {
                return Parameter.SequenceNumber;
            }
        }

        public bool HasDefaultValue {
            get {
                return Attributes.HasFlag(ParameterAttributes.HasDefault);
            }
        }

        public object DefaultValue {
            get {
                return null;
            }
        }

        public string Name {
            get {
                return paramName ??= Context.Resolve(Parameter.Name);
            }
        }
        #endregion

        internal CilParameter(CilContext context, Parameter parameter) {
            Context = context;
            Parameter = parameter;

        }

        private string paramName;
    }
}
