using System;
using System.Collections.Generic;
using System.Linq;

namespace lab03oop {
    public class StringArrayHandler
    {

        public string[] Array { get; }
        private Tuple<int, int> _range;

        public StringArrayHandler() {
            Array = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
            SetRange(0, Array.Length - 1);
        }

        public StringArrayHandler(int startRange, int endRange) : this() {
            Array = Array.Skip(startRange).Take(endRange - startRange).ToArray();
            SetRange(startRange, endRange);
        }

        public StringArrayHandler(string[] array) {
            Array = array;
            SetRange(0, array.Length - 1);
        }

        public int Length => Array.Length;

        public string this[int index] {
            get {
                ThrowExceptionWhenRangeExceeded(index);
                return Array[index];
            }

            set {
                ThrowExceptionWhenRangeExceeded(index);
                Array[index] = value;
            }
        }

        private void SetRange(int startRange, int endRange) {
            _range = new Tuple<int, int>(startRange, endRange);
        }

        private void ThrowExceptionWhenRangeExceeded(int index) {
            if (!IsIndexInRange(index)) {
                throw new IndexOutOfRangeException("Your element is missing. Consider using another index.");
            }
        }

        private bool IsIndexInRange(int index) {
            return (index >= _range.Item1 || index <= _range.Item2);
        }

        public static StringArrayHandler operator +(StringArrayHandler obj1ArrayHandler, StringArrayHandler obj2ArrayHandler) {
            var firstArray = obj1ArrayHandler.Array.ToList();
            var secondArray = obj2ArrayHandler.Array.ToList();
            var mergeResult = new List<string>(firstArray.Count + secondArray.Count);

            var firstArrayIterator = firstArray.GetEnumerator();
            var secondArrayiterator = secondArray.GetEnumerator();

            for (var i = 0; i < mergeResult.Capacity; i++) {
                if (i % 2 == 0) {
                    if (firstArrayIterator.MoveNext()) {
                        mergeResult.Add(firstArrayIterator.Current);
                    }
                } else {
                    if (secondArrayiterator.MoveNext()) {
                        mergeResult.Add(secondArrayiterator.Current);
                    }
                }
            }

            return new StringArrayHandler(mergeResult.ToArray());
        }

        public static StringArrayHandler operator %(StringArrayHandler obj1ArrayHandler, StringArrayHandler obj2ArrayHandler) {
            return new StringArrayHandler(obj1ArrayHandler.Array.Union(obj2ArrayHandler.Array).ToArray());
        }

        public override string ToString() {
            return string.Join(", ", Array);
        }
    }
}