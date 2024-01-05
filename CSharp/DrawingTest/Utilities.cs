using System;

namespace DrawingTest
{
    internal class Utilities
    {
        /// <summary>
        /// Is the named object's class derived from the clas
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="clas"></param>
        /// <returns></returns>
        static public bool isDerivedFrom(Type obj, Type clas)
        {
            var derived = obj;
            do
            {
                derived = derived.BaseType;
                if (derived != null)
                {
                    if (derived == clas)
                    {
                        return true;
                    }
                }
            } while (derived != null);
            return false;
        }

        /// <summary>
        /// Get a count of the number of items in an enum
        /// </summary>
        /// <param name="obj">The typeof(enum) to count</param>
        /// <returns>A number.</returns>
        static public int EnumCount(Type obj)
        {
            return Enum.GetValues(obj).Length;
        }
    }
}
