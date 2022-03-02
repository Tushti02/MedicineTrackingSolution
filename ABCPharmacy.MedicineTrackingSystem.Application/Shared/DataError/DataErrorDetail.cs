using System.Text.Json.Serialization;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError
{
    public class DataErrorDetail
    {
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>Gets or sets the target of the particular error.
        /// For example, the name of the property in error
        /// </summary>
        [JsonPropertyName("target")]
        public string Target { get; set; }
    }
}
