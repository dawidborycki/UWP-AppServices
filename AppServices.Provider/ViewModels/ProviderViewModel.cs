#region Using

using AppServices.Common.ViewModels;
using System.Linq;
using Windows.ApplicationModel;
using Windows.Networking.Connectivity;
using Windows.UI;

#endregion

namespace AppServices.Provider.ViewModels
{
    public class ProviderViewModel : ServiceInfoViewModel
    {
        #region Fields

        private Color currentColor;

        #endregion

        #region Properties

        public Color CurrentColor
        {
            get => currentColor;
            set => currentColor = App.CurrentColor = value;
        }

        #endregion

        #region Constructor

        public ProviderViewModel()
        {
            SetProperty(ref currentColor, Colors.White, "CurrentColor");

            PackageFamilyName = Package.Current.Id.FamilyName;            
            HostName = NetworkInformation.GetHostNames().FirstOrDefault().DisplayName;
            ServiceName = "ColorsService";
        }

        #endregion
    }
}
