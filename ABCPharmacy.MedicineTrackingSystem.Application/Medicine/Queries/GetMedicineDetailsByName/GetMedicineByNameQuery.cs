using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicineDetailsByName
{
    public class GetMedicineByNameQuery : IRequest<List<MedicineDetails>>
    {
        public string MedicineName { get; set; }
    }
}
