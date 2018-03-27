#region Using

using Windows.Foundation;
using Windows.UI.ViewManagement;

#endregion

namespace AppServices.Common.Helpers
{
    public static class ViewHelper
    {
        #region Methods (Public)

        public static void SetViewSize(double width, double height)
        {
            ApplicationView.PreferredLaunchViewSize = new Size(width, height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        #endregion
    }
}
