using System;
using System.Collections.Generic;
using System.Text;

namespace SREmulator {
    public class SRContext {
        public Stack<SRElement> Stack { get; set; } = new();
        public bool Running { get; set; } = true;

        public int InstructionPointer { get; set; } = 0;

        public Dictionary<int, SRElement> Locals { get; } = new();
    }
}
