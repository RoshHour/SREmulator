using SREmulator.Reader.Abstraction;
using SREmulator.Reader.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SREmulator.Reader {
    public class CilType : CilToken, ICilType, IComparable<CilType>, IEquatable<CilType>, ISignatureTypeProvider<CilType, CilToken> {
        internal CilContext Context { get; }

        public TypeDefinition TypeDefinition { get; }

        public SignatureDecoder<CilType, object> SignatureDecoder { get; }

        #region Type properties
        public TypeAttributes TypeAttributes {
            get {
                return TypeDefinition.Attributes;
            }
        }

        public bool IsNested {
            get {
                return TypeDefinition.IsNested;
            }
        }

        public string Namespace {
            get {
                return this.typeNamespace ??= Context.Resolve(TypeDefinition.Namespace);
            }
            private set { this.typeNamespace = value; }
        }

        public string Name {
            get {
                return this.typeName ??= Context.Resolve(TypeDefinition.Name);
            }
            private set { this.typeName = value; }
        }
        #endregion

        internal CilType(string nameSpace, string name)
            : base(0x0, 0x0) {
            this.Namespace = nameSpace;
            this.Name = name;
        }

        internal CilType(CilContext context, TypeDefinition type, int mdtoken, int rid)
            : this(context, type, new CilToken(mdtoken, rid)) { }

        internal CilType(CilContext context, TypeDefinition type, CilToken token)
            : base(token) {
            Context = context;
            TypeDefinition = type;
        }

        public IEnumerable<CilType> GetNestedTypes() {
            var typeDefinitions = TypeDefinition.GetNestedTypes();

            foreach (var typedef in typeDefinitions) {
                var cilToken = CilToken.Create(typedef);

                var type = Context.Cache.FirstOrDefault(x => x.Equals(cilToken)) as CilType;
                if (type is null) {
                    type = new CilType(Context, Context.Resolve(typedef), cilToken);
                    Context.Cache.Add(type);
                }

                yield return type;
            }
        }

        public IEnumerable<CilMethod> GetMethods() {
            var methodDefinitions = TypeDefinition.GetMethods();

            foreach (var methodDef in methodDefinitions) {
                var cilToken = CilToken.Create(methodDef);

                var method = Context.Cache.FirstOrDefault(x => x.Equals(cilToken)) as CilMethod;
                if (method is null) {
                    method = new CilMethod(this, Context.Resolve(methodDef), cilToken);
                    Context.Cache.Add(method);
                }

                yield return method;
            }
        }

        public int CompareTo(CilType cilType) {
            return this.TypeDefinition.GetHashCode()
                .CompareTo(cilType.TypeDefinition.GetHashCode());
        }

        public bool Equals(CilType other) {
            if (ReferenceEquals(other, null))
                return false;
            else if (ReferenceEquals(this, other))
                return true;

            return this.CompareTo(other) == 1;
        }

        public CilType GetFunctionPointerType(MethodSignature<CilType> signature) {
            throw new NotImplementedException();
        }

        public CilType GetGenericMethodParameter(CilToken genericContext, int index) {
            throw new NotImplementedException();
        }

        public CilType GetGenericTypeParameter(CilToken genericContext, int index) {
            throw new NotImplementedException();
        }

        public CilType GetModifiedType(CilType modifier, CilType unmodifiedType, bool isRequired) {
            throw new NotImplementedException();
        }

        public CilType GetPinnedType(CilType elementType) {
            throw new NotImplementedException();
        }

        public CilType GetTypeFromSpecification(MetadataReader reader, CilToken genericContext, TypeSpecificationHandle handle, byte rawTypeKind) {
            throw new NotImplementedException();
        }

        public CilType GetPrimitiveType(PrimitiveTypeCode typeCode) {
            return new CilElementType(typeCode);
        }

        public CilType GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind) {
            var mdtoken = MetadataTokens.GetToken(handle);
            var resolvedType = Context.Resolve(handle);
            var cilToken = new CilToken(mdtoken, rawTypeKind);

            var type = Context.Cache.FirstOrDefault(x => x.Equals(cilToken)) as CilType;
            if (type is null) {
                type = new CilType(Context, resolvedType, cilToken);
                Context.Cache.Add(type);
            }

            return type;
        }

        public CilType GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind) {
            throw new NotImplementedException();
        }

        public CilType GetGenericInstantiation(CilType genericType, System.Collections.Immutable.ImmutableArray<CilType> typeArguments) {
            throw new NotImplementedException();
        }

        public CilType GetArrayType(CilType elementType, ArrayShape shape) {
            throw new NotImplementedException();
        }

        public CilType GetByReferenceType(CilType elementType) {
            throw new NotImplementedException();
        }

        public CilType GetPointerType(CilType elementType) {
            throw new NotImplementedException();
        }

        public CilType GetSZArrayType(CilType elementType) {
            throw new NotImplementedException();
        }

        private string typeName;
        private string typeNamespace;
    }
}
