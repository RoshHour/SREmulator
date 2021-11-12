using System;

namespace SREmulator.Testing {
    public class Example {
        public Test TestingMore(int param1, string asd) {
            return new Test() { A = "Are" };
        }

        public int Addition() {
            return 2 + 2;
        }

        public class Test {
            public string A { get; set; }
        }
    }
}
