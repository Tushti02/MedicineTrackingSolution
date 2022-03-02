namespace ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError
{
    public static class DataErrorCodes
    {
        public static readonly DataErrorCode BadRequest = new DataErrorCode("BadRequest", "There are one or more errors with the data provided for this request.");
        public static readonly DataErrorCode InvalidRequest = new DataErrorCode("InvalidRequest", "Invalid request.");
        public static readonly DataErrorCode InternalServer = new DataErrorCode("InternalServer", "Server encountered an issue trying to fulfil this request");
        public static readonly DataErrorCode ServiceNotAvailable = new DataErrorCode("ServiceNotAvailable", "Service not available.");
        public static readonly DataErrorCode NotFound = new DataErrorCode("NotFound", "No data found.");
        public static readonly DataErrorCode NullOrWhiteSpaceValue = new DataErrorCode("NullOrWhiteSpaceValue", "Value can not be null or whitespace");
        public static readonly DataErrorCode InValidId = new DataErrorCode("InValidId", "Id is invalid");

        public static readonly DataErrorCode ExpiryShouldBeGreaterThan15Days = new DataErrorCode("ExpiryShouldBeGreaterThan15Days", "Expiry Should Be Greater Than 15 Days");

    }
}
