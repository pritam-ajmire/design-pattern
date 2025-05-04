namespace MementoPattern.Core
{
    /// <summary>
    /// Generic Caretaker class that can work with any Originator and Memento implementation
    /// </summary>
    public class Caretaker<T, M> where T : IOriginator<M> where M : IMemento
    {
        private readonly List<M> _mementos = new();
        private readonly T _originator;
        private int _currentIndex = -1;

        public Caretaker(T originator)
        {
            _originator = originator;
        }

        /// <summary>
        /// Saves the current state of the originator
        /// </summary>
        public void Backup()
        {
            Console.WriteLine("Caretaker: Saving state...");
            
            // Remove any future states if we're in the middle of history
            if (_currentIndex < _mementos.Count - 1)
            {
                _mementos.RemoveRange(_currentIndex + 1, _mementos.Count - _currentIndex - 1);
            }
            
            _mementos.Add(_originator.SaveState());
            _currentIndex = _mementos.Count - 1;
        }

        /// <summary>
        /// Restores the previous state of the originator (Undo)
        /// </summary>
        public bool Undo()
        {
            if (_currentIndex <= 0 || _mementos.Count == 0)
            {
                Console.WriteLine("Caretaker: No states to restore");
                return false;
            }

            _currentIndex--;
            Console.WriteLine("Caretaker: Restoring to previous state...");
            _originator.RestoreState(_mementos[_currentIndex]);
            return true;
        }

        /// <summary>
        /// Restores the next state of the originator (Redo)
        /// </summary>
        public bool Redo()
        {
            if (_currentIndex >= _mementos.Count - 1)
            {
                Console.WriteLine("Caretaker: No future states to restore");
                return false;
            }

            _currentIndex++;
            Console.WriteLine("Caretaker: Restoring to next state...");
            _originator.RestoreState(_mementos[_currentIndex]);
            return true;
        }

        /// <summary>
        /// Shows the history of saved states
        /// </summary>
        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of saved states:");
            
            for (int i = 0; i < _mementos.Count; i++)
            {
                string currentMarker = i == _currentIndex ? " (current)" : "";
                Console.WriteLine($"{i}: {_mementos[i].GetCreationDate()}{currentMarker}");
            }
        }
    }
}
