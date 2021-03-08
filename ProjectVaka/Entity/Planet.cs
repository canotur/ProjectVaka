using System;
using System.Linq;
using ProjectVaka.Interfaces;
using ProjectVaka.Methods;

namespace ProjectVaka.Entity
{
    public abstract class Planet : IPlanet
    {
        protected int MinPlanetTopX;
        protected int MinPlanetTopY;
        protected int MaxPlanetTopX;
        protected int MaxPlanetTopY;
        
        public string Name { get; set; }

        protected static Directions _directions { get; set; }

        public Directions Directions
        {
            get { return _directions; }
        }

        private readonly Robots Robots = new Robots();
        private static PlanetArea _planetArea = new PlanetArea();

        public PlanetArea PlanetArea
        {
            get { return _planetArea; }
        }

        public void SetTopLocation(string information)
        {
            Location location = new Location(information);
            if (CheckTopLocationAvailable(location))
                PlanetArea.TopLocation = location;
        }

        private bool CheckTopLocationAvailable(Location location)
        {
            if (location.X < MinPlanetTopX || location.Y < MinPlanetTopY || location.X > MaxPlanetTopX || location.Y > MaxPlanetTopY)
                return false;
            return true;
        }

        public void AddRobotsToPlanet(int robotCount)
        {
            for (int i = 0; i < robotCount; i++)
            {
                GetRobotEntry robotEntry = new GetRobotEntry(this);
                string message = PlanetArea.GetPositionInform();
                robotEntry.ForceAcceptableValue<Robot>(message);
            }
        }

        public bool AddRobot(Robot robot)
        {
            if (robot == null)
                throw new ArgumentNullException("robot");

            bool isRobotAdded = IsLocationAvailable(robot.Position.Location);
            if (isRobotAdded)
                Robots.Add(robot);

            return isRobotAdded;
        }

        public Robots GetRobots()
        {
            return Robots;
        }

        /// <summary>
        /// We can call it "MoveValidation" too.
        /// </summary>
        /// <param name="location">Kontrol edilecek konum bilgisi</param>(Bu bilgi yanlış olabilir mi?
        /// <returns></returns>
        public bool IsLocationAvailable(Location location)
        {
            bool result = true;

            //Check navigable plane
            if (PlanetArea.Location.X <= location.X && PlanetArea.Location.Y <= location.Y && //Check Planet Location StartPoint
                location.X <= PlanetArea.TopLocation.X && location.Y <= PlanetArea.TopLocation.Y) // Check Planet Location TopPoint
            {
                // Check other robots
                Robots Robots = GetRobots();
                if (Robots.Any(robot => robot.Position.Location.X.Equals(location.X) && robot.Position.Location.Y.Equals(location.Y)))
                    result = false;
            }
            else
                result = false;

            return result;
        }

        public void DrawPlanet()
        {
            Console.WriteLine("Map\n");

            int X = _planetArea.Location.X;
            int Y = _planetArea.Location.Y;

            int TopX = _planetArea.TopLocation.X;
            int TopY = _planetArea.TopLocation.Y;

            string[,] plane = new string[TopX + 1, TopY + 1];

            for (int x = TopX - X; x >= 0; x--)
            {
                for (int y = 0; y <= TopY - Y; y++)
                {
                    bool robotExists = false;
                    foreach (var robot in GetRobots())
                    {
                        if (robot.Position.Location.X == x && robot.Position.Location.Y == y)
                        {
                            plane[x - X, y] = "X"; // Yönünü de belirtecek şekilde bir güncellemeye ihtiyaç var
                            robotExists = true;
                        }
                    }

                    if (!robotExists)
                    {
                        if ((x == X && y == Y) || (x == X && y == TopY) || (x == TopX && y == Y) ||
                            (x == TopX && y == TopY))
                            plane[x - X, y] = "+";
                        else if (x == X || x == TopX)
                            plane[x - X, y] = "-";
                        else if (y == Y || y == TopY)
                            plane[x - X, y] = "|";
                        else
                            plane[x - X, y] = " ";
                    }
                }
            }

            for (int x = TopX - X; x >= 0; x--)
            {
                Console.WriteLine();
                for (int y = 0; y <= TopY - Y; y++)
                {
                    Console.Write(plane[x - X, y]);
                }
            }
            Console.WriteLine();
        }

        public void WriteInformations()
        {
            Console.WriteLine(string.Format("{0} gezegeninde gezilecek alanın başlangıç noktası: ({1}), bitiş noktası:({2})",
                Name,
                PlanetArea.Location.WriteLocationInformation(),
                PlanetArea.TopLocation.WriteLocationInformation()));

            int i = 0;
            foreach (var robot in GetRobots())
                Console.WriteLine(string.Format("{0}. Robotun Adı: {1}, Konumu: {2}, Yönü: {3}",
                    ++i,
                    robot.Name,
                    robot.Position.Location.WriteLocationInformation(),
                    robot.Position.Direction.Key));
        }
    }
}
