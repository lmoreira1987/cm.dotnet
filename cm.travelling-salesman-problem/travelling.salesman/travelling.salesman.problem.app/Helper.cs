using GAF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling.Salesman.Problem.App
{
    public static class Helper
    {
        public static City CurrentCity { set; get; }

        /// <summary>
        /// Private method to calculate the distance
        /// </summary>
        /// <param name="chromosome">Chromosome used to calculate the distance</param>
        /// <returns>A double distance to travel</returns>
        private static double CalculateDistance(Chromosome chromosome)
        {
            var distanceToTravel = 0.0;
            City previousCity = null;

            // Run through each city in the order specified in the chromosome
            foreach (var gene in chromosome.Genes)
            {
                var currentCity = (City)gene.ObjectValue;

                if (previousCity != null)
                {
                    distanceToTravel += previousCity.GetDistanceFromPosition(currentCity.Latitude, currentCity.Longitude);
                }

                previousCity = currentCity;
            }

            // Add distance back to the starting point
            var firstCity = CurrentCity;
            distanceToTravel += previousCity.GetDistanceFromPosition(firstCity.Latitude, firstCity.Longitude);

            return distanceToTravel;
        }

        /// <summary>
        /// Load the cities to be used in the program
        /// </summary>
        /// <returns>List of Cities</returns>
        public static List<City> CreateCities()
        {
            var cities = new List<City>();

            string exit = String.Empty;
            int mininumCities = 1;

            Console.WriteLine("----- Cidade onde você está -----");

            Console.Write("Digite o nome da Cidade: ");
            string firstCityName = Console.ReadLine().ToString();

            Console.Write("Digite a Latitude: ");
            double firstCityLatitude = Convert.ToDouble(Console.ReadLine().Replace(".", ","));

            Console.Write("Digite a Longitude: ");
            double firstCityLongitude = Convert.ToDouble(Console.ReadLine().Replace(".", ","));

            CurrentCity = new City(firstCityName, firstCityLatitude, firstCityLongitude);
            cities.Add(CurrentCity);

            Console.Write(Environment.NewLine);

            do
            {
                mininumCities++;
                Console.WriteLine(string.Format("----- Cidade - {0} -----", mininumCities - 1));

                Console.Write("Digite o nome da Cidade: ");
                string cityName = Console.ReadLine().ToString();

                Console.Write("Digite a Latitude: ");
                double cityLatitude = Convert.ToDouble(Console.ReadLine().Replace(".", ","));

                Console.Write("Digite a Longitude: ");
                double cityLongitude = Convert.ToDouble(Console.ReadLine().Replace(".", ","));

                cities.Add(new City(cityName, cityLatitude, cityLongitude));

                Console.Write(Environment.NewLine);

                if (mininumCities > 2)
                {
                    if (mininumCities == 3)
                        Console.WriteLine("Numero minimo de cidades adicionado");

                    Console.Write("Cidade adicionada com sucesso! Deseja continuar (S - Sim, N - Nao)? ");
                    exit = Console.ReadKey().KeyChar.ToString();

                    Console.Write(Environment.NewLine);
                }
                else
                {
                    exit = "s";
                }

            } while (exit.Contains("s") || exit.Contains("S"));

            return cities;
        }

        /// <summary>
        /// Calculate the fitness
        /// </summary>
        /// <param name="chromosome">Chromosome to calculate the distance</param>
        /// <returns>Fitness</returns>
        public static double CalculateFitness(Chromosome chromosome)
        {
            var distanceToTravel = CalculateDistance(chromosome);
            return 1 - distanceToTravel / 10000;
        }

        /// <summary>
        /// Terminate method
        /// </summary>
        /// <param name="population">Required param</param>
        /// <param name="currentGeneration">Required param</param>
        /// <param name="currentEvaluation">Required param</param>
        /// <returns></returns>
        public static bool Terminate(Population population, int currentGeneration, long currentEvaluation)
        {
            return currentGeneration > 0;
        }

        /// <summary>
        /// Method to print the Route starting and ending by the current location
        /// </summary>
        /// <param name="e">GA Event argumment</param>
        public static void PrintTSP(GaEventArgs e)
        {
            var fittest = e.Population.GetTop(1)[0];

            Console.WriteLine(string.Format("Início: {0}", CurrentCity.Name));

            foreach (var gene in fittest.Genes)
            {
                if (!CurrentCity.Equals((City)gene.ObjectValue))
                    Console.WriteLine(((City)gene.ObjectValue).Name);
            }

            Console.WriteLine(string.Format("Fim: {0}", CurrentCity.Name));
        }

        /// <summary>
        /// Method to print the Gereneration, Fitness and Distance information
        /// </summary>
        /// <param name="e">GA Event argumment</param>
        public static void PrintGeneration(GaEventArgs e)
        {
            var fittest = e.Population.GetTop(1)[0];
            var distanceToTravel = CalculateDistance(fittest);
            Console.WriteLine("Generation: {0}, Fitness: {1}, Distance: {2}", e.Generation, fittest.Fitness, distanceToTravel);
        }

        /// <summary>
        /// Finalize the program
        /// </summary>
        public static void PrintEnd()
        {
            Console.Write(Environment.NewLine);
            Console.Write("Digite qualquer tecla para finalizar... ");
            Console.Read();
        }
    }
}
