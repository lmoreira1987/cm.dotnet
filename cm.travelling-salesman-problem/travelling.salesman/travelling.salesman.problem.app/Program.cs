using System;
using System.Collections.Generic;
using System.Linq;
using GAF;
using GAF.Extensions;
using GAF.Operators;

/* 
 * ----- DESAFIO -----
 * 
 * Como um programador muito popular, você conhece muitas pessoas em seu país. 
 * Como você viaja muito, você decidiu que seria muito útil de ter um programa que te dissesse quais de seus amigos 
 *  estão mais próximos baseado em qual amigo você está atualmente visitando.
 * Cada um de seus amigos vive em uma posição específica (latitude e longitude) - para os propósitos deste problema 
 *  o mundo é plano e a latitude e a longitude são coordenadas cartesianas em um plano - e você consegue identificá-los de alguma maneira. 
 *  Também cada amigo mora em uma posição diferente (dois amigos nunca estão na mesma latitude e longitude).
 * Escreva um programa que receba a localização de cada um dos seus amigos e, para cada um deles, você indique quais 
 *  são os outros três amigos mais próximos a ele.
 
 * -Criar como Console Application
 * -Queremos avaliar a qualidade do código
 * -Tentar separar o código em classes e métodos
 * -Criar testes unitários será um diferencial 
 */

/* Referencia: johnnewcombe.net 
 *
 * Por se tratar de um algoritmo NP-Hard na qual existe uma DLL muito potente que é o GAF eu decidi utilizar da mesma 
 *  e realizar o desenvolvimento do restante do algoritmo
 */

namespace Travelling.Salesman.Problem.App
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            const int populationSize = 100;
            const int elitismPercentage = 5;
            const double crossoverProbability = 0.8;
            const double mutationProbability = 0.02;

            // Get the cities
            var cities = Helper.CreateCities();

            // Initialize a population
            var population = new Population();

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

            // Create the elite operator
            var elite = new Elite(elitismPercentage);

            // Create the crossover operator
            var crossover = new Crossover(crossoverProbability)
            {
                CrossoverType = CrossoverType.DoublePointOrdered
            };

            // Create the mutation operator
            var mutate = new SwapMutate(mutationProbability);

            // Create the GA
            var ga = new GeneticAlgorithm(population, Helper.CalculateFitness);

            // Hook up to some useful events
            ga.OnGenerationComplete += ga_OnGenerationComplete;
            ga.OnRunComplete += ga_OnRunComplete;

            // Add the operators
            ga.Operators.Add(elite);
            ga.Operators.Add(crossover);
            ga.Operators.Add(mutate);

            // Run the GA
            ga.Run(Helper.Terminate);

            // Finalize the program
            Helper.PrintEnd();
        }

        #region *** Events ***

        private static void ga_OnRunComplete(object sender, GaEventArgs e)
        {
            Helper.PrintTSP(e);
        }

        private static void ga_OnGenerationComplete(object sender, GaEventArgs e)
        {
            Helper.PrintGeneration(e);
        }

        #endregion

    }
}
