using System;
using System.Reflection.Metadata;

namespace SREmulator.Reader.Helpers {
    internal static class MDReaderHelper {
		internal static AssemblyFile Resolve(this CilContext context, AssemblyFileHandle handle)
			=> context.MDReader.GetAssemblyFile(handle);
		internal static AssemblyReference Resolve(this CilContext context, AssemblyReferenceHandle handle)
			=> context.MDReader.GetAssemblyReference(handle);
		internal static byte[] Resolve(this CilContext context, BlobHandle handle)
			=> context.MDReader.GetBlobBytes(handle);
		internal static Constant Resolve(this CilContext context, ConstantHandle handle)
			=> context.MDReader.GetConstant(handle);
		internal static CustomAttribute Resolve(this CilContext context, CustomAttributeHandle handle)
			=> context.MDReader.GetCustomAttribute(handle);
		internal static CustomDebugInformation Resolve(this CilContext context, CustomDebugInformationHandle handle)
			=> context.MDReader.GetCustomDebugInformation(handle);
		internal static DeclarativeSecurityAttribute Resolve(this CilContext context, DeclarativeSecurityAttributeHandle handle)
			=> context.MDReader.GetDeclarativeSecurityAttribute(handle);
		internal static Document Resolve(this CilContext context, DocumentHandle handle)
			=> context.MDReader.GetDocument(handle);
		internal static EventDefinition Resolve(this CilContext context, EventDefinitionHandle handle)
			=> context.MDReader.GetEventDefinition(handle);
		internal static ExportedType Resolve(this CilContext context, ExportedTypeHandle handle)
			=> context.MDReader.GetExportedType(handle);
		internal static FieldDefinition Resolve(this CilContext context, FieldDefinitionHandle handle)
			=> context.MDReader.GetFieldDefinition(handle);
		internal static GenericParameter Resolve(this CilContext context, GenericParameterHandle handle)
			=> context.MDReader.GetGenericParameter(handle);
		internal static GenericParameterConstraint Resolve(this CilContext context, GenericParameterConstraintHandle handle)
			=> context.MDReader.GetGenericParameterConstraint(handle);
		internal static Guid Resolve(this CilContext context, GuidHandle handle)
			=> context.MDReader.GetGuid(handle);
		internal static ImportScope Resolve(this CilContext context, ImportScopeHandle handle)
			=> context.MDReader.GetImportScope(handle);
		internal static InterfaceImplementation Resolve(this CilContext context, InterfaceImplementationHandle handle)
			=> context.MDReader.GetInterfaceImplementation(handle);
		internal static LocalConstant Resolve(this CilContext context, LocalConstantHandle handle)
			=> context.MDReader.GetLocalConstant(handle);
		internal static LocalScope Resolve(this CilContext context, LocalScopeHandle handle)
			=> context.MDReader.GetLocalScope(handle);
		internal static LocalVariable Resolve(this CilContext context, LocalVariableHandle handle)
			=> context.MDReader.GetLocalVariable(handle);
		internal static ManifestResource Resolve(this CilContext context, ManifestResourceHandle handle)
			=> context.MDReader.GetManifestResource(handle);
		internal static MemberReference Resolve(this CilContext context, MemberReferenceHandle handle)
			=> context.MDReader.GetMemberReference(handle);
		internal static MethodDebugInformation Resolve(this CilContext context, MethodDebugInformationHandle handle)
			=> context.MDReader.GetMethodDebugInformation(handle);
		internal static MethodDefinition Resolve(this CilContext context, MethodDefinitionHandle handle)
			=> context.MDReader.GetMethodDefinition(handle);
		internal static MethodImplementation Resolve(this CilContext context, MethodImplementationHandle handle)
			=> context.MDReader.GetMethodImplementation(handle);
		internal static MethodSpecification Resolve(this CilContext context, MethodSpecificationHandle handle)
			=> context.MDReader.GetMethodSpecification(handle);
		internal static ModuleReference Resolve(this CilContext context, ModuleReferenceHandle handle)
			=> context.MDReader.GetModuleReference(handle);
		internal static NamespaceDefinition Resolve(this CilContext context, NamespaceDefinitionHandle handle)
			=> context.MDReader.GetNamespaceDefinition(handle);
		internal static Parameter Resolve(this CilContext context, ParameterHandle handle)
			=> context.MDReader.GetParameter(handle);
		internal static PropertyDefinition Resolve(this CilContext context, PropertyDefinitionHandle handle)
			=> context.MDReader.GetPropertyDefinition(handle);
		internal static StandaloneSignature Resolve(this CilContext context, StandaloneSignatureHandle handle)
			=> context.MDReader.GetStandaloneSignature(handle);
		internal static TypeDefinition Resolve(this CilContext context, TypeDefinitionHandle handle)
			=> context.MDReader.GetTypeDefinition(handle);
		internal static TypeReference Resolve(this CilContext context, TypeReferenceHandle handle)
			=> context.MDReader.GetTypeReference(handle);
		internal static TypeSpecification Resolve(this CilContext context, TypeSpecificationHandle handle)
			=> context.MDReader.GetTypeSpecification(handle);
		internal static string Resolve(this CilContext context, StringHandle handle)
			=> context.MDReader.GetString(handle);
		internal static string Resolve(this CilContext context, UserStringHandle handle)
			=> context.MDReader.GetUserString(handle);
	}
}
