using System;
using System.Linq;
using ProjectVaka.Base;
using ProjectVaka.Interfaces;
using ProjectVaka.Keys;
using ProjectVaka.Statics;

namespace ProjectVaka.Entity
{
    public class Robot : IRobot
    {
        public string Name { get; set; }
        public Planet Planet { get; set; }
        public Commands Commands = new Commands();
        private Position _position { get; set; }

        public Position Position
        {
            get { return _position; }
            set
            {
                if (Planet.IsLocationAvailable(value.Location))
                    _position = value;
                else
                    throw new ArgumentOutOfRangeException("Gezici robotu konumlandırmak istediğiniz yer uygun değil!");
            }
        }

        public Robot(Planet planet, Position position)
        {
            Planet = planet;
            Position = position;
        }

        public void Move()
        {
            Location location = new Location(
                Position.Location.X + Position.Direction.LocationMovement.X,
                Position.Location.Y + Position.Direction.LocationMovement.Y
            );

            if (Planet.IsLocationAvailable(location))
                Position.Location = location;
        }

        public void Turn(WayKey way)
        {
            int directionCount = Enum.GetValues(typeof(DirectionKey)).Length;
            int newDirectionKeyIndex = (Position.Direction.Index + (int)way) % directionCount;
            Position.Direction = Planet.Directions.FirstOrDefault(d => d.Index.Equals(newDirectionKeyIndex));
        }

        public bool Movement(MoveKey key)
        {
            bool result = false;
            switch (key)
            {
                case MoveKey.M:
                    Commands.Enqueue(new MoveCommand(this));
                    break;
                case MoveKey.L:
                case MoveKey.R:
                    Commands.Enqueue(new TurnCommand(this, ParseMethods.ConvertMoveKeyToWay(key)));
                    break;
                case MoveKey.Enter:
                    result = true;
                    break;
            }

            return result;
        }
    }
}
