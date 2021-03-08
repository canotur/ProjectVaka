using ProjectVaka.Base;
using ProjectVaka.Entity;

namespace ProjectVaka.Methods
{
    public class GetRobotEntry : MapInfo
    {
        private readonly Planet _planet;

        public GetRobotEntry(Planet planet)
        {
            _planet = planet;
        }

        protected override T ForceAcceptableValueImpl<T>(string userEntry)
        {
            Robot robot = null;
            Position position = new Position(_planet, userEntry);
            if (position.IsParsed)
            {
                bool isRobotAdded = false;
                robot = new Robot(_planet, position);
                isRobotAdded = _planet.AddRobot(robot);
                if (isRobotAdded)
                {
                    string message = "Gezici robotiği yönlendirin. Kullanabileceğiniz özellikler: " + System.Console.Out.NewLine + "L -> Left, R -> Right, M -> Move, Enter -> Add Next Robot | Exit";
                    GetMoveEntry moveEntry = new GetMoveEntry(robot, message);
                    moveEntry.ForceAcceptableValue();
                }
                else
                    robot = null;
            }

            return (T)(object)robot;
        }
    }
}
