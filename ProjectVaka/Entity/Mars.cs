using System.Drawing;
using ProjectVaka.Keys;

namespace ProjectVaka.Entity
{
    public class Mars : Planet
    {
        private string PlanetName = "Mars";

        private static readonly Direction North = new Direction(DirectionKey.N, new Point(0, 1), 0); // Gezegende bulunan yönler. 3 boyutlu bir gezegende direction a 2(içeri ve dışarı) boyut daha gelebilir. Bu da gezegenin yeteneğine eklenmelidir.
        private static readonly Direction East = new Direction(DirectionKey.E, new Point(1, 0), 1); // Cisimler gezegenin imkanı ve kendi yeteneğine göre hareket edebilirler.
        private static readonly Direction South = new Direction(DirectionKey.S, new Point(0, -1), 2);
        private static readonly Direction West = new Direction(DirectionKey.W, new Point(-1, 0), 3);
        private static readonly Directions MarsDirections = new Directions() { North, East, South, West };

        // Peki uçan bir cisim gönderildi ilk defa onun için de yukarı aşağıya gitmesi söz konusu.
        // Mevcut yükseklik bilgisinin saklanması da gerekmektedir bunun için.

        // Robotun bir çember alanda gezmesi değerlendirilebilir.

        // Robotun tüm Mart yüzeyinde gezebildiğini hesapla bu durumda yüzeyi nasıl işlemen gerekir?

        public Mars()
        {
            _directions = MarsDirections;
            Name = PlanetName;
            MinPlanetTopX = 5; // Dokümanda belirtilmemiş ama konumlandırılacak robotlar için mutlaka belirli bir alan ayırılmalıdır.
            MinPlanetTopY = 5; // Dokümanda belirtilmemiş ama konumlandırılacak robotlar için mutlaka belirli bir alan ayırılmalıdır.
            MaxPlanetTopX = 5000; // Dokümanda belirtilmemiş ama belirli bir alan belirtilmelidir.
            MaxPlanetTopY = 5000; // Dokümanda belirtilmemiş ama belirli bir alan belirtilmelidir.
            PlanetArea.Location = new Location(0, 0); // Dokümanda belirtildiği şekilde değerler belirlendi.
        }
    }
}
