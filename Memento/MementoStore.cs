using System.Collections.Generic;

namespace Memento
{
    internal class MementoStore<T> where T : IMemento
    {
        internal Queue<T> _store = new Queue<T>();

        internal T GetLastMemento()
        {
            return _store.Dequeue();
        }

        internal void AddMemento(T memento)
        {
            _store.Enqueue(memento);
        }
        
    }

}
