using System;
using System.Linq;
using System.Reflection.Emit;
using System.Collections.Generic;
using SREmulator.Reader;
using SREmulator.Instructions;

namespace SREmulator {
    public class ReflectionEmulator {
        public SRContext Context { get; set; }
        public Func<SRContext, CilInstruction, bool> Intercept { get; set; } = delegate { return false; };

        internal CilModule Module { get; }

        internal static Dictionary<OpCode, InstructionBase> Instructions { get; }

        static ReflectionEmulator() {
            Instructions = new();

            var instructions = typeof(ReflectionEmulator).Assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(InstructionBase))).ToArray();

            foreach (var instruction in instructions) {
                var instance = (InstructionBase)Activator.CreateInstance(instruction);
                Instructions.Add(instance.OpCode, instance);
            }
        }

        public ReflectionEmulator(CilModule module) {
            Module = module;
            Context = new();
        }

        public object Emulate(CilMethod method) {
            if (!method.HasBody)
                return null;

            var context = this.Context;

            var body = method.CilBody;
            var instructions = body.Instructions;

            for (; context.InstructionPointer < instructions.Count && context.Running; context.InstructionPointer++) {
                var instruction = instructions[context.InstructionPointer];

                // Overwrite
                if (Intercept(context, instruction))
                    continue;

                // Normal
                Instructions[instruction.OpCode].Emulate(context, instruction);
            }

            return context.Stack.Count > 0 ? context.Stack.Pop().Get<object>() : null;
        }
    }
}
