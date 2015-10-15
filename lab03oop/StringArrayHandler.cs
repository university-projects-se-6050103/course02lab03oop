using System;

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
            if (startRange < 0 || endRange >= Length) {
                throw new IndexOutOfRangeException();
            }
            _range = new Tuple<int, int>(startRange, endRange);
        }

        private void ThrowExceptionWhenRangeExceeded(int index) {
            if (!IsIndexInRange(index)) {
                throw new IndexOutOfRangeException("Your element is missing. Consider using another index.");
            }
        }

        private bool IsIndexInRange(int index) {
            return (_range.Item1 < 0 || _range.Item2 >= Length);
        }
    }
}