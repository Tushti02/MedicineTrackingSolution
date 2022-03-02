using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicineDetailsByName
{
    public class GetMedicineByNameQueryValidator : AbstractValidator<GetMedicineByNameQuery>
    {
        public GetMedicineByNameQueryValidator()
        {

        }
    }
}
