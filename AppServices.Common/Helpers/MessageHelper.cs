#region Using

using System;
using Windows.ApplicationModel.AppService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;

#endregion

namespace AppServices.Common.Helpers
{
    public static class MessageHelper
    {
        #region Fields

        private static string colorKey = "Color";
        private static string statusCodeKey = "StatusCode";
        private static string getColorMessageKey = "GetColor";

        #endregion

        #region Methods (Public)

        public static IAsyncOperation<AppServiceResponseStatus> SendResponse(
            AppServiceRequest request, Color color, StatusCode statusCode)
        {
            Check.IsNull(request);

            var response = new ValueSet()
            {
                { colorKey, ColorHelper.ColorToByteArray(color) },
                { statusCodeKey, (int)statusCode }
            };

            return request.SendResponseAsync(response);
        }

        public static IAsyncOperation<AppServiceResponse> SendRequest(
            AppServiceConnection appServiceConnection)
        {
            Check.IsNull(appServiceConnection);

            var request = new ValueSet()
            {
                { getColorMessageKey, string.Empty }
            };

            return appServiceConnection.SendMessageAsync(request);
        }

        public static StatusCode ParseRequestMessage(ValueSet message)
        {
            Check.IsNull(message);

            if (message.ContainsKey(getColorMessageKey))
            {
                return StatusCode.OK;
            }
            else
            {
                return StatusCode.UnknownRequest;
            }
        }

        public static StatusCode ParseResponseMessage(
            ValueSet message, ref Color color)
        {
            Check.IsNull(message);

            var statusCode = StatusCode.OK;

            try
            {
                statusCode = (StatusCode)message[statusCodeKey];

                color = ColorHelper.ByteArrayToColor(message[colorKey] as byte[]);
            }
            catch (Exception)
            {
                statusCode = StatusCode.UnexpectedMessageStructure;
            }

            return statusCode;
        }

        #endregion
    }
}
