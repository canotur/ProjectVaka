using System;
using ProjectVaka.Entity;
using ProjectVaka.Interfaces;
using ProjectVaka.Methods;

namespace ProjectVaka
{
    class Program
    {
        private const int RobotCount = 2;

        static void Main()
        {
            // Buradaki yapıyı MicroServis yapısına çevirirsek nasıl olur?

            Console.Title = " The Return of the King! ------ Vaka Project - Lets Do it! ";

            GetPlanetEntry marsEntry = new GetPlanetEntry(new Mars());
            // Ya venüs e gidecekse
            // Ya robot fakat uçabilen bir robot da varsa? hem marsa hem de venüs e istediğini gönderebilirsin
            string mapInfo = "\nGezilebilecek alanının sırasıyla arasında bir boşluk bırakarak 5 veya 5ten büyük olacak şekilde En uç X ve Y koordinatlarını giriniz!\nÖrnek: 10 15";
            IPlanet mars = marsEntry.ForceAcceptableValue<IPlanet>(mapInfo); 
            mars.AddRobotsToPlanet(RobotCount);
            mars.DrawPlanet();
            mars.WriteInformations();

            Console.WriteLine("Çıkmak için bir tuşa basınız!");
            Console.ReadLine();
        }
    }
}
