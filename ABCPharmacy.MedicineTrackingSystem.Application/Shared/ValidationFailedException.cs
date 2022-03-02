using ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Shared
{
    public class ValidationFailedException : Exception
    {
        public ValidationFailedException(string errorMessage, IEnumerable<DataErrorDetail> dataErrors) : base(errorMessage)
        {
            Errors = dataErrors;
        }

        public IEnumerable<DataErrorDetail> Errors { get; }

        public ValidationFailedException()
        {
        }

        public ValidationFailedException(string message) : base(message)
        {
        }

        public ValidationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
