namespace Codex {

    /// <summary>
    /// An object that simply contains (boxes) another object.
    /// </summary>
    /// <typeparam name="T">The type of object contained in this <see cref="Box{T}"/>.</typeparam>
    public class Box<T> {

        private T contents;

        /// <summary>
        /// Gets or sets the object contained in this <see cref="Box{T}"/>.
        /// </summary>
        public virtual T Contents {
            get { return contents; }
            set { contents = value; }
        }

        /// <summary>
        /// Creates a <see cref="Box{T}"/> that contains the default value of <see cref="T"/>.
        /// </summary>
        public Box() { }

        /// <summary>
        /// Creates a <see cref="Box{T}"/> that contains the given object.
        /// </summary>
        /// <param name="contents">The object to contain in this <see cref="Box{T}"/>.</param>
        public Box(T contents) {
            this.contents = contents;
        }

    }

    /// <summary>
    /// The static helper class for <see cref="Box{T}"/>.
    /// </summary>
    public static class Box {

        /// <summary>
        /// Creates a <see cref="Box{T}"/> that contains the given object.
        /// </summary>
        /// <param name="contents">The object to contain in the <see cref="Box{T}"/>.</param>
        /// <typeparam name="T">The type of object to contain in the <see cref="Box{T}"/>.</typeparam>
        /// <returns>A <see cref="Box{T}"/> that contains <paramref name="contents"/>.</returns>
        public static Box<T> Create<T>(T contents) {
            return new Box<T>(contents);
        }

    }

}
