using System;
using System.Drawing;
using ProjectVaka.Interfaces;
using ProjectVaka.Log;

namespace ProjectVaka.Entity
{
    public class Location : IEntity
    {
        private bool _isParsed = false;
        public bool IsParsed { get { return _isParsed; } }

        private bool _isEmpty = true;
        public bool IsEmpty { get { return _isEmpty; } }

        public int X { get; set; }
        public int Y { get; set; }

        public Location()
        {

        }

        public Location(int x, int y)
        {
            SetLocationValues(x, y);
        }

        public Location(Point point)
        {
            SetLocationValues(point.X, point.Y);
        }

        public Location(string[] location)
        {
            SetLocationValues(location);
        }

        public Location(string text)
        {
            string[] splittedText = text.Split(Convert.ToChar(ConsoleKey.Spacebar));
            SetLocationValues(splittedText);
        }

        private void SetLocationValues(int x, int y)
        {
            X = x;
            Y = y;
            _isEmpty = false;
            _isParsed = true;
        }

        private bool CheckLocationInformations(string[] location)
        {
            if (location == null)
                throw new ArgumentNullException("location");

            if (location.Length != 2)
            {
                Loger.Write(string.Format("Konum bilgisinin alınabilmesi için 2 boyut değeri girilmelidir. X ve Y: {0} sayıda bilgi girişini denemesi yapıldı.", location.Length));
                return false;
            }

            return true;
        }

        private void SetLocationValues(string[] location)
        {
            if (CheckLocationInformations(location))
            {
                int x, y;
                if (Int32.TryParse(location[0], out x) && Int32.TryParse(location[1], out y))
                    SetLocationValues(x, y);
                else
                    Loger.Write(string.Format("Boyutlar sayı olmalıdır. Girilen değer: {0} {1}", location[0], location[1]));
            }
        }

        public string WriteLocationInformation()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}
