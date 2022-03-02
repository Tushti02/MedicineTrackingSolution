using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError
{
    public sealed class DataInnerError
    {
        public DataInnerError()
        {
        }

        public DataInnerError(Exception exception)
        {
            if (exception.InnerException != null)
            {
                InnerError = new DataInnerError(exception.InnerException);
            }

            Properties = new Dictionary<string, string>
            {
                { JsonConstants.DataErrorInnerErrorMessageName, exception.Message },
                { JsonConstants.DataErrorInnerErrorTypeNameName, exception.GetType().FullName },
                { JsonConstants.DataErrorInnerErrorStackTraceName, exception.StackTrace }
            };
        }

        public DataInnerError(IDictionary<string, string> properties)
        {
            Properties = new Dictionary<string, string>(properties);
        }

        /// <summary>
        /// Properties to be written for the inner error.
        /// </summary>
        internal IDictionary<string, string> Properties { get; private set; }

        /// <summary>Gets or sets the error message.</summary>
        /// <returns>The error message.</returns>
        [JsonPropertyName("message")]
        public string Message
        {
            get => GetStringValue(JsonConstants.DataErrorInnerErrorMessageName);
            set => SetStringValue(JsonConstants.DataErrorInnerErrorMessageName, value);
        }

        /// <summary>Gets or sets the type name of this error, for example, the type name of an exception.</summary>
        /// <returns>The type name of this error.</returns>
        [JsonPropertyName("typeName")]
        public string TypeName
        {
            get => GetStringValue(JsonConstants.DataErrorInnerErrorTypeNameName);
            set => SetStringValue(JsonConstants.DataErrorInnerErrorTypeNameName, value);
        }

        /// <summary>Gets or sets the stack trace for this error.</summary>
        /// <returns>The stack trace for this error.</returns>
        [JsonPropertyName("stackTrace")]
        public string StackTrace
        {
            get => GetStringValue(JsonConstants.DataErrorInnerErrorStackTraceName);
            set => SetStringValue(JsonConstants.DataErrorInnerErrorStackTraceName, value);
        }

        [JsonPropertyName("innerError")]
        public DataInnerError InnerError { get; set; }

        private string GetStringValue(string propertyKey)
        {
            if (Properties.ContainsKey(propertyKey))
            {
                return Properties[propertyKey]?.ToString();
            }

            return string.Empty;
        }

        private void SetStringValue(string propertyKey, string value)
        {
            if (!Properties.ContainsKey(propertyKey))
            {
                Properties.Add(propertyKey, value);
            }
            else
            {
                Properties[propertyKey] = value;
            }
        }
    }
}
