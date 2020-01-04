using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Permutations
{
    public class GeneratingElements<T>
    {
        private readonly T[] elements;

        public GeneratingElements(T[] elements)
        {
            this.elements = elements;
        }

        public int Size
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => elements.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T First() => elements[0];

        public IEnumerable<T> DistinctElements => elements.Distinct();
        
        public GeneratingElements<T> WithoutOne(T element)
        {
            var indexToRemove = Array.BinarySearch(elements, element);
            var newElements = new T[Size - 1];
            Array.Copy(elements, 0, newElements, 0, indexToRemove);
            Array.Copy(elements, indexToRemove + 1,
                newElements, indexToRemove,
                Size - indexToRemove - 1
            );
            
            return new GeneratingElements<T>(newElements);
        }
    }
}