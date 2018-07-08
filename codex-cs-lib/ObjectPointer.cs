using System;
using System.Runtime.InteropServices;

namespace Codex {

    /// <summary>
    /// A pointer whose target object and value (memory address of the target object) can be freely manipulated.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public class ObjectPointer {

        // Overlapping these Box<T> fields causes their contents to occupy the same location in the managed heap. This
        // allows us to access that location both as an object reference and as an IntPtr struct (which are always the
        // same size, regardless of platform). Since assigning one of these fields also assigns the other, we perform
        // exactly one assignment in each constructor to avoid wasteful object allocations.
        [FieldOffset(0)] private readonly Box<object> targetBox;
        [FieldOffset(0)] private readonly Box<IntPtr> valueBox;

        /// <summary>
        /// Gets or sets the target object of this <see cref="ObjectPointer"/>.
        /// </summary>
        public virtual object Target {
            get { return targetBox.Contents; }
            set { targetBox.Contents = value; }
        }

        /// <summary>
        /// Gets or sets the value of this <see cref="ObjectPointer"/> (the memory address of the target object).
        /// </summary>
        public virtual IntPtr Value {
            get { return valueBox.Contents; }
            set { valueBox.Contents = value; }
        }

        /// <summary>
        /// Creates a null <see cref="ObjectPointer"/>.
        /// </summary>
        public ObjectPointer() : this(null) { }

        /// <summary>
        /// Creates an <see cref="ObjectPointer"/> that has the given target object.
        /// </summary>
        /// <param name="target">The target object of the <see cref="ObjectPointer"/>.</param>
        public ObjectPointer(object target) {
            targetBox = Box.Create(target);
        }

        /// <summary>
        /// Creates an <see cref="ObjectPointer"/> that has the given value (memory address of the target object).
        /// </summary>
        /// <param name="value">The value of the <see cref="ObjectPointer"/> (the memory address of the target object).</param>
        public ObjectPointer(IntPtr value) {
            valueBox = Box.Create(value);
        }

    }

}
