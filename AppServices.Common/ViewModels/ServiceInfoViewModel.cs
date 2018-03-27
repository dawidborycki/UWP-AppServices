namespace AppServices.Common.ViewModels
{
    public class ServiceInfoViewModel : BaseViewModel
    {
        #region Fields

        private string hostName;

        private string serviceName;

        private string packageFamilyName;

        #endregion

        #region Properties

        public string HostName
        {
            get => hostName;
            set => SetProperty(ref hostName, value);
        }

        public string ServiceName
        {
            get => serviceName;
            set => SetProperty(ref serviceName, value);
        }

        public string PackageFamilyName
        {
            get => packageFamilyName;
            set => SetProperty(ref packageFamilyName, value);
        }

        #endregion        
    }
}
