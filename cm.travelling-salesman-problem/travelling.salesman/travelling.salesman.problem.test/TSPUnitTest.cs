using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Travelling.Salesman.Problem.App;
using GAF;
using GAF.Extensions;

namespace travelling.salesman.problem.test
{
    [TestClass]
    public class TSPUnitTest
    {
        public City CurrentCity { get; set; }

        [TestMethod]
        public void Load_Cities()
        {
            var cities = CreateCities();
            Assert.IsTrue(cities.Count == 16);
        }

        [TestMethod]
        public void Load_Chromosome()
        {
            const int populationSize = 100;

            // Get the cities
            var cities = CreateCities();

            // Initialize a population
            var population = new Population();

            GetPopulation(populationSize, cities, population);

            Assert.IsTrue(population.Solutions[0].Count == cities.Count);
        }

        [TestMethod]
        public void Verify_Calculate_Distance()
        {
            const int populationSize = 100;

            // Get the cities
            var cities = CreateCities();

            // Initialize a population
            var population = new Population();

            GetPopulation(populationSize, cities, population);

            Chromosome chromosome = new Chromosome();
            chromosome = population.Solutions[0];


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

            Assert.IsFalse(distanceToTravel == 0.0);
        }

        private List<City> CreateCities()
        {
            var cities = new List<City>();

            var expected = new City("Sao Bernardo do Campo", 51.289406, 1.075802);

            CurrentCity = expected;
            cities.Add(CurrentCity);

            cities.Add(new City("Diadema", 52.486125, -1.890507));
            cities.Add(new City("Sao Paulo", 51.460852, -2.588139));
            cities.Add(new City("Sao Caetano", 53.803895, -1.549931));
            cities.Add(new City("Santo Andre", 51.512161, -0.116215));
            cities.Add(new City("Maua", 53.478239, -2.258549));
            cities.Add(new City("Riacho Grande", 53.409532, -3.000126));
            cities.Add(new City("New York", 53.751959, -0.335941));
            cities.Add(new City("London", 54.980766, -1.615849));
            cities.Add(new City("Amsterdam", 54.892406, -2.923222));
            cities.Add(new City("Bruges", 55.958426, -3.186893));
            cities.Add(new City("Paris", 55.862982, -4.263554));
            cities.Add(new City("Rome", 51.488224, -3.186893));
            cities.Add(new City("Madrid", 51.624837, -3.94495));
            cities.Add(new City("Edinburgh", 50.726024, -3.543949));
            cities.Add(new City("Dublin", 50.152266, -5.065556));

            Assert.AreSame(expected, CurrentCity);

            return cities;
        }

        private static void GetPopulation(int populationSize, List<City> cities, Population population)
        {
            // Create the chromosomes
            for (var p = 0; p < populationSize; p++)
            {
                var chromosome = new Chromosome();
                foreach (var city in cities)
                {
                    chromosome.Genes.Add(new Gene(city));
                }

                chromosome.Genes.ShuffleFast();
                population.Solutions.Add(chromosome);
            }
        }
    }
}
