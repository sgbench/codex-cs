using System;

namespace Codex {

    public static partial class Extensions {

        /// <summary>
        /// Performs a type-safe, compile time cast of an object.
        /// </summary>
        /// <param name="t">The object to cast.</param>
        /// <typeparam name="T">The target type. <paramref name="t"/> must be implicitly convertible to this type.</typeparam>
        /// <returns>A target-typed reference to <paramref name="t"/>.</returns>
        public static T As<T>(this T t) {
            return t;
        }

        /// <summary>
        /// Gets the current memory address of an object.
        /// </summary>
        /// <param name="t">The object to inspect.</param>
        /// <typeparam name="T">The type of <paramref name="t"/>.</typeparam>
        /// <returns>The current memory address of <paramref name="t"/>.</returns>
        public static IntPtr GetCurrentMemoryAddress<T>(this T t) where T : class {
            return new ObjectPointer(t).Value;
        }

    }

}
