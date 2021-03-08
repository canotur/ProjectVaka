using ProjectVaka.Entity;
using ProjectVaka.Keys;

namespace ProjectVaka.Interfaces
{
    interface IRobot
    {
        string Name { get; set; }

        Planet Planet { get; set; }

        Position Position { get; set; }

        void Move();

        void Turn(WayKey way);
    }
}
