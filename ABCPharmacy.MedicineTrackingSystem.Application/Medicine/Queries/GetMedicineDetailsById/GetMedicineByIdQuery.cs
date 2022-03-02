using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicineDetailsById
{
    public class GetMedicineByIdQuery : IRequest<MedicineDetails>
    {
        public int MedicineId { get; set; }
    }
}
