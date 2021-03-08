using System;
using ProjectVaka.Interfaces;
using ProjectVaka.Keys;
using ProjectVaka.Log;
using ProjectVaka.Statics;

namespace ProjectVaka.Entity
{
public class Position : IPosition
    {
        private bool _isParsed = false;
        public bool IsParsed { get { return _isParsed; } }

        public Location Location { get; set; }
        public Direction Direction { get; set; }

        private static bool CheckPositionInformations(string[] position)
        {
            if (position == null)
                throw new ArgumentNullException("position");

            if (position.Length != 3)
            {
                Loger.Write(string.Format("Sadece 3 adet değer girilebilir. X, Y ve Yön Bilgisi. {0} sayıda boyu girişi denemesi yapıldı", position.Length));
                return false;
            }

            return true;
        }

        internal Position(Planet planet, string text)
        {
            string[] splittedText = text.Split(Convert.ToChar(ConsoleKey.Spacebar));

            if (CheckPositionInformations(splittedText))
            {
                string directionValue = splittedText[2];
                string[] location = { splittedText[0], splittedText[1] };

                DirectionKey directionKey;
                Location = new Location(location);

                if (Location.IsParsed && ParseMethods.ParseText(directionValue, out directionKey))
                {
                    Direction = planet.Directions.ParseDirection(directionKey);

                    _isParsed = true;
                }
            }
        }
    } 
}
