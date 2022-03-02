using ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicineDetailsById
{
    public class GetMedicineByIdQueryValidator : AbstractValidator<GetMedicineByIdQuery>
    {
        public GetMedicineByIdQueryValidator()
        {
            RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithErrorCode(DataErrorCodes.NullOrWhiteSpaceValue.Code)
            .WithMessage(DataErrorCodes.NullOrWhiteSpaceValue.Description)
            .Must(y => IsValidId(y.MedicineId))
            .WithMessage(DataErrorCodes.InValidId.Description)
            .WithErrorCode(DataErrorCodes.InValidId.Code);
        }

        private bool IsValidId(int medicineId)
        {
            return medicineId > 0;
        }
    }
}
