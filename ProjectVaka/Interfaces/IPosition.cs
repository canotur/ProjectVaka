using ProjectVaka.Entity;

namespace ProjectVaka.Interfaces
{
    public interface IPosition
    {
        Location Location { get; set; }

        Direction Direction { get; set; }

        bool IsParsed { get; }
    }
}
