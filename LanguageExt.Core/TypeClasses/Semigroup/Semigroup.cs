﻿using System.Diagnostics.Contracts;

namespace LanguageExt.TypeClasses
{
    [Typeclass]
    public interface Semigroup<A>
    {
        /// <summary>
        /// An associative binary operation.
        /// </summary>
        /// <param name="x">The first operand to the operation</param>
        /// <param name="y">The second operand to the operation</param>
        /// <returns>The result of the operation</returns>
        [Pure]
        A Append(A x, A y);
    }
}
