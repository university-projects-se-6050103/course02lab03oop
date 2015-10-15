namespace lab03oop {
    public class StringArrayHandler {

        private string[] _stringArray;

        public StringArrayHandler() {
            _stringArray = new string[10];
        }

        public int Length => _stringArray.Length;

        public string this[int index] {
            get {
                return _stringArray[index];
            }

            set {
                _stringArray[index] = value;
            }
        }
    }
}