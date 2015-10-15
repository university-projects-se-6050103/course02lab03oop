using System;
using System.Linq;

namespace lab03oop {
    public class StringArrayHandler {

        private string[] _array;
        private Tuple<int, int> _range;

        public StringArrayHandler() {
            _array = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
        }

        public StringArrayHandler(int startRange, int endRange) : this() {
            SetRange(startRange, endRange);
        }

        public StringArrayHandler(string[] array) : this(0, array.Length - 1) {
            _array = array;
            Console.WriteLine(string.Join(",", _array));
        }

        public int Length => _array.Length;

        public string this[int index] {
            get {
                ThrowExceptionWhenRangeExceeded(index);
                return _array[index];
            }

            set {
                ThrowExceptionWhenRangeExceeded(index);
                _array[index] = value;
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
            var firstArray = obj1ArrayHandler._array;
            var secondArray = obj2ArrayHandler._array;
            var mergeResultArray = new string[firstArray.Length + secondArray.Length];

            for (int i = 0, mergeArrayIndex = 0; i < mergeResultArray.Length; i++) {
                if (i % 2 == 0) {
                    mergeResultArray[i] = firstArray[mergeArrayIndex];
                } else {
                    mergeResultArray[i] = secondArray[mergeArrayIndex];
                    mergeArrayIndex++;
                }
            }

            return new StringArrayHandler(mergeResultArray);
        }
    }
}