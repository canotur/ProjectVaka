using ProjectVaka.Entity;

namespace ProjectVaka.Base
{
    public abstract class Command
    {
        protected Robot Robot;

        protected Command(Robot robot)
        {
            Robot = robot;
        }

        public abstract void Execute();
    }
}
