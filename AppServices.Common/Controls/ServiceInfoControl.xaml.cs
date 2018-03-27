#region Using

using AppServices.Common.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#endregion

namespace AppServices.Common.Controls
{
    public sealed partial class ServiceInfoControl : UserControl
    {
        #region Properties

        public string HostName
        {
            get => (string)GetValue(HostNameProperty);
            set => SetValue(HostNameProperty, value);
        }

        public string ServiceName
        {
            get => (string)GetValue(ServiceNameProperty);
            set => SetValue(ServiceNameProperty, value);
        }

        public string PackageFamilyName
        {
            get => (string)GetValue(PackageFamilyNameProperty);
            set => SetValue(PackageFamilyNameProperty, value);
        }

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        #endregion

        #region Dependency properties

        public static readonly DependencyProperty HostNameProperty =
            DependencyPropertyHelper.RegisterDependencyProperty<string>(
                typeof(ServiceInfoControl), "HostName");

        public static readonly DependencyProperty ServiceNameProperty =
            DependencyPropertyHelper.RegisterDependencyProperty<string>(
                typeof(ServiceInfoControl), "ServiceName");

        public static readonly DependencyProperty PackageFamilyNameProperty =
            DependencyPropertyHelper.RegisterDependencyProperty<string>(
                typeof(ServiceInfoControl), "PackageFamilyName");

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyPropertyHelper.RegisterDependencyProperty<bool>(
                typeof(ServiceInfoControl), "IsReadOnly");

        #endregion                       

        #region Constructor

        public ServiceInfoControl()
        {
            InitializeComponent();
        }

        #endregion        
    }
}
