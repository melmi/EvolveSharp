﻿using System.Collections.Generic;
using System.Text;

namespace EvolveSharp.Individuals
{
    public class Individual<T> : IIndividual<T>
    {
        private readonly IList<T> genes;
        private IFitnessFunction<T> fitnessFunction;

        /// <summary>
        /// Builds a new individual from a list of genes
        /// </summary>
        /// <param name="genes">List of genes which forms a Individual</param>
        public Individual(IList<T> genes)
        {
            this.genes = genes;
        }

        /// <summary>
        /// Builds a new individual from another
        /// </summary>
        /// <param name="individual">Individual</param>
        public Individual(Individual<T> individual)
        {
            genes = individual.genes;
            fitnessFunction = individual.fitnessFunction;
        }

        public int Length
        {
            get { return genes.Count; }
        }

        /// <summary>
        /// Get the last fitness evaluated
        /// </summary>
        private double? fitness;

        public double Fitness
        {
            get
            {
                if (fitness.HasValue) return fitness.Value;
                fitness = fitnessFunction.Evaluate(this);
                return fitness.Value;
            }
        }

        /// <summary>
        /// Compare if the value this individual is equal to other individual
        /// </summary>
        /// <param name="obj">The individual to compare with this</param>
        /// <returns>if the individuals are equal or not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var individual = obj as Individual<T>;
            if (individual == null)
                return false;

            for (var locus = 0; locus != genes.Count; locus++)
            {
                if (!EqualityComparer<T>.Default.Equals(genes[locus], individual.genes[locus]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            foreach (var gene in genes)
            {
                hash = hash * 31 + gene.GetHashCode();
            }
            return hash;
        }

        /// <summary>
        /// Print the values of each gene of individual
        /// </summary>
        /// <returns>Values of individual in a string</returns>
        public override string ToString()
        {
            var output = new StringBuilder(genes.Count);
            foreach (var gene in genes)
                output.AppendFormat(" {0:0.00}", gene);

            return output.ToString();
        }

        public IList<T> Genes
        {
            get { return genes; }
        }

        public int CompareTo(IIndividual<T> other)
        {
            if (Fitness > other.Fitness) return +1;
            if (Fitness < other.Fitness) return -1;

            return 0;
        }

        /// <summary>
        /// Fitness Function for the Individual
        /// </summary>
        public IFitnessFunction<T> FitnessFunction
        {
            get { return fitnessFunction; }
            set
            {
                if (fitnessFunction == value) return;
                fitnessFunction = value;
                fitness = null;
            }
        }

        /// <summary>
        /// Create a identical Individual with other memory address
        /// </summary>
        /// <returns>A copy of individual</returns>
        public object Clone()
        {
            var newGenes = new T[genes.Count];
            for (var i = 0; i < genes.Count; i++)
            {
                newGenes[i] = genes[i];
            }
            return new Individual<T>(genes) { fitnessFunction = fitnessFunction };
        }
    }
}
