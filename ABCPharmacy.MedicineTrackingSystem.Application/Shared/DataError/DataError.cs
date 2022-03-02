using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError
{
    public sealed class DataError
    {
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>Gets or sets the target of the particular error.</summary>
        /// <returns>For example, the name of the property in error</returns>
        [JsonPropertyName("target")]
        public string Target { get; set; }

        /// <summary>
        /// A collection of JSON objects that MUST contain name/value pairs for code and message, and MAY contain
        /// a name/value pair for target, as described above.
        /// </summary>
        /// <returns>The error details.</returns>
        [JsonPropertyName("details")]
        public ICollection<DataErrorDetail> Details { get; set; }

        /// <summary>Gets or sets the implementation specific debugging information to help determine the cause of the error.</summary>
        /// <returns>The implementation specific debugging information.</returns>
        [JsonPropertyName("innerError")]
        public DataInnerError InnerError { get; set; }
    }
}
