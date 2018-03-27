#region Using

using AppServices.Common.Helpers;
using AppServices.Common.ViewModels;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation;
using Windows.Networking;
using Windows.System.RemoteSystems;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

#endregion

namespace AppServices.Client.ViewModel
{
    public class ClientViewModel : ServiceInfoViewModel
    {
        #region Fields

        private bool isConnected;
        private bool isConnectionInProgress;
        private Brush receivedColorBrush;
        private string status;        
        private AppServiceConnection appServiceConnection;

        #endregion

        #region Properties

        public bool IsConnected
        {
            get => isConnected;
            set => SetProperty(ref isConnected, value);
        }
        
        public bool IsConnectionInProgress
        {
            get => isConnectionInProgress;
            set => SetProperty(ref isConnectionInProgress, value);
        }

        public Brush ReceivedColorBrush
        {
            get => receivedColorBrush;
            set => SetProperty(ref receivedColorBrush, value);
        }

        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        #endregion

        #region Methods (Public)

        public async void Connect(object sender, RoutedEventArgs e)
        {
            if (!IsConnected)
            {
                IsConnectionInProgress = true;

                try
                {
                    var access = await RemoteSystem.RequestAccessAsync();

                    if (access == RemoteSystemAccessStatus.Allowed)
                    {
                        await ConnectToRemoteHost();
                    }
                    else
                    {
                        Status = access.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Status = ex.Message;
                }

                IsConnectionInProgress = false;
            }
        }

        public async void SendRequest()
        {
            var response = await MessageHelper.SendRequest(appServiceConnection);

            if (response.Status == AppServiceResponseStatus.Success)
            {
                Color color;

                if (MessageHelper.ParseResponseMessage(response.Message, ref color) == StatusCode.OK)
                {
                    ReceivedColorBrush = new SolidColorBrush(color);
                }
            }
        }

        #endregion

        #region Methods (Private)

        private async Task ConnectToRemoteHost()
        {
            var remoteSystem = await RemoteSystem.FindByHostNameAsync(
                new HostName(HostName));

            if (remoteSystem == null)
            {
                Status = "The specified host could not be found";
            }
            else if (remoteSystem.Status == RemoteSystemStatus.Available)
            {
                var connectionStatus = await OpenConnection(remoteSystem);

                if (connectionStatus == AppServiceConnectionStatus.Success)
                {
                    IsConnected = true;
                    Status = "Connected";
                }
                else
                {
                    Status = connectionStatus.ToString();
                }
            }
            else
            {
                Status = remoteSystem.Status.ToString();
            }
        }

        private IAsyncOperation<AppServiceConnectionStatus> OpenConnection(
            RemoteSystem remoteSystem)
        {
            var request = new RemoteSystemConnectionRequest(remoteSystem);

            appServiceConnection = new AppServiceConnection()
            {
                AppServiceName = ServiceName,
                PackageFamilyName = PackageFamilyName
            };

            return appServiceConnection.OpenRemoteAsync(request);
        }

        #endregion
    }
}
