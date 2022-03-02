
using System.Text.Json;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError
{
    public class DataErrorCode
    {
        public DataErrorCode(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }
        public string Description { get; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
