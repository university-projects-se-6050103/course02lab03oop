using System;

namespace lab03oop {
    public class StringArrayHandler {

        private string[] _array;
        private Tuple<int, int> _boundaries;

        public StringArrayHandler() {
            _array = new string[10];
        }

        public StringArrayHandler(int startPosition, int endPosition) : this() {
            SetBoundaries(startPosition, endPosition);
        }

        public int Length => _array.Length;

        public string this[int index] {
            get {
                return _array[index];
            }

            set {
                _array[index] = value;
            }
        }

        private void SetBoundaries(int startPosition, int endPosition) {
            if (startPosition < 0 || endPosition >= Length) {
                throw new IndexOutOfRangeException();
            }
            _boundaries = new Tuple<int, int>(startPosition, endPosition);
        }
    }
}