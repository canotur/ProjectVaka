using ProjectVaka.Entity;

namespace ProjectVaka.Interfaces
{
    interface IPlanet
    {
        string Name { get; set; }

        PlanetArea PlanetArea { get; }

        void SetTopLocation(string userEntry);

        bool AddRobot(Robot robot);

        Robots GetRobots();

        void AddRobotsToPlanet(int count);

        void DrawPlanet();

        void WriteInformations();
    }
}
