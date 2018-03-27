#region Using

using System;

#endregion

namespace AppServices.Common.Helpers
{
    public static class Check
    {
        #region Methods 

        public static void IsNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static void ArrayLength(Array array, int expectedLength)
        {
            if (array.Length != expectedLength)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
