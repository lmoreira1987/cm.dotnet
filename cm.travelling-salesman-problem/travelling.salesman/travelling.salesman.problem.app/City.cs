using System;

namespace Travelling.Salesman.Problem.App
{
    public class City
    {
        public City(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Name { set; get; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        /// <summary>
        /// Generate the distance from position 
        ///  ps. it can use Dijkstra if necessary
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public double GetDistanceFromPosition(double latitude, double longitude)
        {
            var R = 6371; // radius of the earth in km
            var dLat = DegreesToRadians(latitude - Latitude);
            var dLon = DegreesToRadians(longitude - Longitude);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(Latitude)) * Math.Cos(DegreesToRadians(latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
                ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // distance in km
            return d;
        }

        /// <summary>
        /// Tranform degrees to radians
        /// </summary>
        /// <param name="deg">Degrees</param>
        /// <returns>Radians</returns>
        private static double DegreesToRadians(double deg)
        {
            return deg * (System.Math.PI / 180);
        }
    }
}