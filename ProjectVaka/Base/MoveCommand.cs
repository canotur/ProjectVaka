using ProjectVaka.Entity;

namespace ProjectVaka.Base
{
    public class MoveCommand : Command
    {
        public MoveCommand(Robot robot)
            : base(robot)
        {
        }

        public override void Execute()
        {
            Robot.Move();
        }
    }
}
