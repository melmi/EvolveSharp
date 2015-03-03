﻿using System;
using System.Collections.Generic;

namespace EvolveSharp.Individuals
{
    /// <summary>
    /// Interface to support implementation of several kind of individuals
    /// </summary>
    public interface IIndividual<T> : IComparable<IIndividual<T>>, ICloneable
    {
        /// <summary>
        /// Length of individual's gene
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Get the gene list
        /// </summary>
        IList<T> Genes { get; }

        /// <summary>
        /// Returns the Fitness of this individual
        /// </summary>
        double Fitness { get; }

        /// <summary>
        /// Compare if the Fitness this individual is equal, smaller or larger than Fitness other individual
        /// </summary>
        /// <param name="other">Individual that want to compare with this</param>
        new int CompareTo(IIndividual<T> other);

        /// <summary>
        /// Fitness Function for the Individual
        /// </summary>
        IFitnessFunction<T> FitnessFunction { get; set; }
    }
}
