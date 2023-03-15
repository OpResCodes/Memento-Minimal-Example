/*
 * The basic idea is: A Memento stores the (private) state of an object without the state becomming external
 * a "caretaker" stores and retrieves mementos 
 * The class can restore itself with a given memento and export its state to a memento
 * Cautio with reference types in the state, they need to be copied
 */

using System.Collections.Generic;

namespace Memento
{
    internal class DataClassMemento : IMemento
    {
        private List<System.Drawing.Point> _state;
        internal DataClassMemento(List<System.Drawing.Point> dataItems)
        {
            _state = new List<System.Drawing.Point>();
            for (int i = 0; i < dataItems.Count; i++)
            {
                _state.Add(dataItems[i]);
            }
        }
        internal List<System.Drawing.Point> GetState()
        {
            return _state;
        }
    }

}
