using ProjectVaka.Base;
using ProjectVaka.Entity;
using ProjectVaka.Interfaces;

namespace ProjectVaka.Methods
{
    public class GetPlanetEntry : MapInfo
    {
        IPlanet _planet;

        public GetPlanetEntry(Planet planet)
        {
            _planet = planet;
        }

        protected override T ForceAcceptableValueImpl<T>(string mapInfo)
        {
            _planet.SetTopLocation(mapInfo);
            if (!_planet.PlanetArea.IsAreaDefined)
                _planet = null;

            return (T)(object)_planet;
        }
    }
}
