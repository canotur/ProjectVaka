using System;
using ProjectVaka.Interfaces;
using ProjectVaka.Keys;
using ProjectVaka.Statics;

namespace ProjectVaka.Entity
{
    public class PlanetArea : IPlanetArea
    {
        private bool _isAreaDefined = false;
        public bool IsAreaDefined { get { return _isAreaDefined; } }

        private Location _location = new Location();
        private Location _topLocation = new Location();

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (value.IsParsed)
                {
                    _location = value;
                    if (_topLocation.IsParsed)
                        _isAreaDefined = true;
                }
            }
        }

        public Location TopLocation
        {
            get
            {
                return _topLocation;
            }
            set
            {
                if (value.IsParsed)
                {
                    _topLocation = value;
                    if (_location.IsParsed)
                        _isAreaDefined = true;
                }
            }
        }

        internal string GetPositionInform()
        {
            if (!IsAreaDefined) return "Henüz alan belirlenmemiş"; // Burası neden Ters

            string message =
                        string.Format(
                            "Lütfen ({0},{1}) ve ({2},{3}) arasında boş bir lokasyon seçiniz",
                            _location.X, _location.Y, _topLocation.X, _topLocation.Y);

            Random r = new Random();

            int x = r.Next(_location.X, _topLocation.X);
            int y = r.Next(_location.Y, _topLocation.Y);

            DirectionKey directionKey;
            int directionCount = Enum.GetValues(typeof(DirectionKey)).Length;
            string d = r.Next(0, directionCount - 1).ToString();
            ParseMethods.ParseEnum(d, out directionKey);

            string inform = System.Environment.NewLine + string.Format(@"Gezici robotiğin başlangıç konumunu ve yönünü arasında birer boşluk bırakarak giriniz! Örnek: {0} {1} {2}", x, y, directionKey);
            message += inform;

            return message;
        }
    }
}
