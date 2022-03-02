using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Commands
{
    public class AddMedicineCommand : IRequest<List<MedicineDetails>>
    {
        public MedicineDetails Medicine { get; set; }
    }
}
