#region Using

using AppServices.Client.ViewModel;
using AppServices.Common.Helpers;
using Windows.UI.Xaml.Controls;

#endregion

namespace AppServices.Client
{
    public sealed partial class MainPage : Page
    {
        #region Fields

        private ClientViewModel viewModel = new ClientViewModel();

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
