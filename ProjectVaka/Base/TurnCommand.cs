using ProjectVaka.Entity;
using ProjectVaka.Keys;

namespace ProjectVaka.Base
{
    class TurnCommand : Command
    {
        private WayKey Way;
        public TurnCommand(Robot robot, WayKey way)
            : base(robot)
        {
            Way = way;
        }

        public override void Execute()
        {
            Robot.Turn(Way);
        }
    }
}
