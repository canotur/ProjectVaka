using System.Drawing;
using ProjectVaka.Interfaces;
using ProjectVaka.Keys;

namespace ProjectVaka.Entity
{
    public class Direction : IEntity
    {
        private readonly bool _isParsed = false;
        public bool IsParsed { get { return _isParsed; } }

        public DirectionKey Key { get; set; }
        public Point LocationMovement { get; set; }
        public int Index { get; set; }

        public Direction(DirectionKey key, Point point, int i)
        {
            Key = key;
            LocationMovement = point;
            Index = i;
            _isParsed = true;
        }
    }
}
