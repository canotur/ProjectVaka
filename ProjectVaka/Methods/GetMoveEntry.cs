using ProjectVaka.Base;
using ProjectVaka.Entity;
using ProjectVaka.Keys;
using ProjectVaka.Statics;

namespace ProjectVaka.Methods
{
    public class GetMoveEntry : UserKeyEntry
    {
        public GetMoveEntry(Robot robot, string message)
            : base(robot)
        {
            _robot = robot;
            StaticMethods.ShowMessage(message);
        }

        protected override bool ForceAcceptableValueImpl(MoveKey moveKey)
        {
            return _robot.Movement(moveKey);
        }
    }
}
