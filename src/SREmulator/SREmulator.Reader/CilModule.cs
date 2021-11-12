using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using SREmulator.Reader.Helpers;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace SREmulator.Reader {
    public class CilModule {
        public static CilModule Load(Stream stream)
            => new CilModule(stream);

        internal CilContext Context { get; }

        #region Reflection properties
        public AssemblyDefinition AssemblyDefinition { get; }
        public ModuleDefinition ModuleDefinition { get; }
        #endregion

        #region PE properties
        public bool IsConsoleApplication {
            get => Context.PEReader.PEHeaders.IsConsoleApplication;
        }

        public bool IsDll {
            get => Context.PEReader.PEHeaders.IsDll;
        }

        public bool IsExe {
            get => Context.PEReader.PEHeaders.IsExe;
        }
        #endregion

        #region Module properties
        public AssemblyFlags Flags {
            get => AssemblyDefinition.Flags;
        }

        public string Name {
            get {
                return this.moduleName ??= Context.Resolve(AssemblyDefinition.Name);
            }
        }

        public string Culture {
            get {
                return this.moduleCulture ??= Context.Resolve(AssemblyDefinition.Culture);
            }
        }

        public byte[] PublicKey {
            get {
                return this.modulePublicKey ??= Context.Resolve(AssemblyDefinition.PublicKey);
            }
        }

        public Version Version {
            get => AssemblyDefinition.Version;
        }
        #endregion

        private CilModule(Stream stream) {
            Context = CilContext.CreateContext(stream);

            AssemblyDefinition = Context.MDReader.GetAssemblyDefinition();
            ModuleDefinition = Context.MDReader.GetModuleDefinition();
        }

        public IEnumerable<CilType> GetTypes() {
            var typeDefinitions = Context.MDReader.TypeDefinitions;

            foreach (var typedef in typeDefinitions) {
                var resolvedType = Context.Resolve(typedef);
                var mdtoken = MetadataTokens.GetToken(typedef);
                var rid = MetadataTokens.GetRowNumber(typedef);
                var type = new CilType(Context, resolvedType, mdtoken, rid);

                Context.Cache.Add(type);

                yield return type;
            }

            yield break;
        }

        private string moduleName;
        private string moduleCulture;
        private byte[] modulePublicKey;
    }
}
