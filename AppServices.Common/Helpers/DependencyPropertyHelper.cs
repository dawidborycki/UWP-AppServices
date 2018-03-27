#region Using

using System;
using Windows.UI.Xaml;

#endregion

namespace AppServices.Common.Helpers
{
    public static class DependencyPropertyHelper
    {
        #region Methods (Public)

        public static DependencyProperty RegisterDependencyProperty<T>(
            Type registeringType, string dependencyPropertyName)
        {
            return DependencyProperty.Register(dependencyPropertyName,
                typeof(T), registeringType, new PropertyMetadata(null));
        }

        #endregion
    }
}
