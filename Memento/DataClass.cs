using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Memento
{
    public class DataClass
    {

        private List<Point> _pointData = new List<Point>();
        private static Random _r = new Random();
        private static int _id = 0;

        public DataClass()
        {
            Id = ++_id;
            Label = $"Line {Id}";
            GenerateRandomLine(10);
        }

        public void GenerateRandomLine(int n)
        {
            _pointData.Clear();
            for (int i = 0; i < n; i++)
            {
                Point p = new Point(_r.Next(0, 50), _r.Next(0, 50));
                _pointData.Add(p);
            }
        }

        public int Id { get; set; }

        public string Label { get; set; }

        public void Add(int x, int y)
        {
            _pointData.Add(new Point(x, y));
        }

        public void RemoveLastPoint()
        {
            var p = _pointData[^1];
            _pointData.Remove(p);
        }

        public void Remove(int x, int y)
        {
            var points = _pointData.Where(p => p.X == x && p.Y == y).ToArray();
            for (int i = 0; i < points.Length; i++)
            {
                _pointData.Remove(points[i]);
            }
        }

        public void StoreCheckPoint()
        {
            _mementoStore.AddMemento(CreateMemento());
        }

        public void RestoreLastCheckPoint()
        {
            SetMemento(_mementoStore.GetLastMemento());
        }

        #region Memento internal stuff

        private DataClassMemento CreateMemento()
        {
            return new DataClassMemento(_pointData);
        }

        private void SetMemento(DataClassMemento memento)
        {
            _pointData.Clear();
            _pointData.AddRange(memento.GetState());
        }

        private MementoStore<DataClassMemento> _mementoStore = new MementoStore<DataClassMemento>(); 

        #endregion

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < _pointData.Count; i++)
            {
                b.AppendFormat("{0} {1}", _pointData[i].X, _pointData[i].Y);
                if (i < _pointData.Count - 1)
                    b.Append(",");
            }
            return $"{Id};{Label}; LINESTRING({b.ToString()})";
        }

    }
}
