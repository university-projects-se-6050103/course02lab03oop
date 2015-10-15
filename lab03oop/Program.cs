using System;

namespace lab03oop {
    class Program {
        static void Main() {
            var stringArrayHandler = new StringArrayHandler(0, 9);
            Console.WriteLine(stringArrayHandler[2]);
        }
    }
}
