using System.Collections.Generic;

namespace ProjectVaka.Entity
{
    public class Robots : List<Robot>
    {
        private const string RobotNameTemplate = @"Robot_{0}";
        public new void Add(Robot robot)
        {
            robot.Name = string.Format(RobotNameTemplate, Count + 1);

            base.Add(robot);
        }
    }
}
