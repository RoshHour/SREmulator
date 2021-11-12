using System;
using System.IO;
using System.Reflection.Emit;
using SREmulator.Reader;

namespace SREmulator.Testing.Net {
    class Program {
        static void Main(string[] args) {
            var fileStream = new MemoryStream(File.ReadAllBytes(args[0]));

            var module = CilModule.Load(fileStream);

            var types = module.GetTypes();
            foreach (var type in types) {
                var methods = type.GetMethods();
                foreach (var method in methods) {
                    var emulator = new ReflectionEmulator(module) { Intercept = Intercept };
                    var result = emulator.Emulate(method);
                    Console.WriteLine($"Result of method: {result}");
                }
            }

            Console.ReadLine();
        }

        public static bool Intercept(SRContext context, CilInstruction instruction) {
            return instruction.OpCode == OpCodes.Stloc_0 || instruction.OpCode == OpCodes.Ldloc_0;
        }
    }
}