﻿using System.Collections.Generic;
using EvolveSharp.Individuals;

namespace EvolveSharp.Initializers
{
    /// <summary>
    /// Interface to support implementation of population.
    /// </summary>
    public interface IInitializer<T>
    {
        /// <summary>
        /// Creates a population based in a size
        /// </summary>
        /// <param name="size">Number of individuals should be in this population</param>
        /// <param name="fitnessFunction">Population's fitness function</param>
        /// <returns></returns>
        IEnumerable<IIndividual<T>> Generate(int size, IFitnessFunction<T> fitnessFunction);
    }
}
