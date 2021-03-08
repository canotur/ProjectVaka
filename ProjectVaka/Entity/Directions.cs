using System.Collections.Generic;
using System.Linq;
using ProjectVaka.Interfaces;
using ProjectVaka.Keys;

namespace ProjectVaka.Entity
{
    public class Directions : List<Direction>, IEntity
    {
        private bool _isParsed = false;
        public bool IsParsed { get { return _isParsed; } }

        public Direction ParseDirection(DirectionKey directionKey)
        {
            return this.FirstOrDefault(d => d.Key == directionKey);
        }

        public Direction ParseDirection(int index)
        {
            return this.FirstOrDefault(d => d.Index.Equals(index));
        }
    }
}
