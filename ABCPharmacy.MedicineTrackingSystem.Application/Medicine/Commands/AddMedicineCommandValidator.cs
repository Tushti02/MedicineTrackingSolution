using ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Commands
{
    public class AddMedicineCommandValidator : AbstractValidator<AddMedicineCommand>
    {
        public AddMedicineCommandValidator()
        {
            RuleFor(x => x.Medicine.ExpiryDate)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithErrorCode(DataErrorCodes.NullOrWhiteSpaceValue.Code)
            .WithMessage(DataErrorCodes.NullOrWhiteSpaceValue.Description)
            .Must(y => IsValidExpiryDate(y))
            .WithMessage(DataErrorCodes.ExpiryShouldBeGreaterThan15Days.Description)
            .WithErrorCode(DataErrorCodes.ExpiryShouldBeGreaterThan15Days.Code);

        }

        private bool IsValidExpiryDate(DateTime x)
        {
            if(x.Year==DateTime.Today.Year)
            {
                return false;
            }
            if (x < DateTime.Today.AddDays(15))
            {
                return false;
            }
            return true;
        }
    }
}
