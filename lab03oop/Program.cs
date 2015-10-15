using System;

namespace lab03oop {
    class Program {
        static void Main() {
            var obj1 = new StringArrayHandler();
            var obj2 = new StringArrayHandler();

            var oneByOneMerge = obj1 + obj2;
            var uniqueMerge = obj1 % obj2;

            Console.WriteLine($"Access string by index: {oneByOneMerge[2]}");
            Console.WriteLine($"\nElements merged one by one: \n{oneByOneMerge}");
            Console.WriteLine($"\nElements merged without duplicates: \n{uniqueMerge}");
        }
    }
}
