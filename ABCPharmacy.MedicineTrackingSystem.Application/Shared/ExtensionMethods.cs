using ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Shared
{
    public static class ExtensionMethods
    {
        public static List<DataErrorDetail> MapToDataError(this IEnumerable<ValidationFailure> validationFailures)
        {
            return validationFailures.Select(x => {
                return new DataErrorDetail
                {
                    ErrorCode = x.ErrorCode,
                    Message = x.ErrorMessage,
                    Target = x.PropertyName
                };
            }).ToList();
        }
    }
}
