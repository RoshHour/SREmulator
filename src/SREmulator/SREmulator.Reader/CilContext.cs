using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace SREmulator.Reader {
    internal class CilContext {
        internal static CilContext CreateContext(Stream stream)
            => new CilContext(stream);

        internal PEReader PEReader { get; }
        internal MetadataReader MDReader { get; }

        internal List<CilToken> Cache { get; } = new();

        private CilContext(Stream stream) {
            PEReader = new PEReader(stream);
            MDReader = PEReader.GetMetadataReader();
        }
    }
}