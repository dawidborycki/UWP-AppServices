#region Using

using Windows.UI;

#endregion

namespace AppServices.Common.Helpers
{
    public static class ColorHelper
    {
        #region Methods (Public)

        public static byte[] ColorToByteArray(Color color)
        {
            return new byte[] { color.A, color.R, color.G, color.B };
        }

        public static Color ByteArrayToColor(byte[] byteArray)
        {
            Check.IsNull(byteArray);
            Check.ArrayLength(byteArray, 4);

            return Color.FromArgb(byteArray[0], byteArray[1], byteArray[2], byteArray[3]);
        }

        #endregion
    }
}
