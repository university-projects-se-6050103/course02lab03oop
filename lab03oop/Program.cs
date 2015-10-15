using System;

namespace lab03oop {
    class Program {
        static void Main() {
            var obj1 = new StringArrayHandler(0, 9);
            var obj2 = new StringArrayHandler(0, 9);
            var result = obj1 % obj2;
            Console.WriteLine(result);
        }
    }
}
