#region Using

using AppServices.Common.Helpers;
using AppServices.Provider.ViewModels;
using Windows.UI.Xaml.Controls;

#endregion

namespace AppServices.Provider
{
    public sealed partial class MainPage : Page
    {
        #region Fields

        private ProviderViewModel viewModel = new ProviderViewModel();

        #endregion

        #region Constructor

        public MainPage()
        {
            InitializeComponent();

            ViewHelper.SetViewSize(500, 550);
        }

        #endregion
    }
}