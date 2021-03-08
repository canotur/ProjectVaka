using ProjectVaka.Entity;

namespace ProjectVaka.Interfaces
{
    public interface IPlanetArea
    {
        bool IsAreaDefined { get; }

        Location Location { get; set; }

        Location TopLocation { get; set; }
    }
}
