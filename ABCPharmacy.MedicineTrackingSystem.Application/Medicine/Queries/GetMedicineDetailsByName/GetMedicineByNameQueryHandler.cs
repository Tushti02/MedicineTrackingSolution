using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicineDetailsByName
{
    public class GetMedicineByNameQueryHandler :  IRequestHandler<GetMedicineByNameQuery, List<MedicineDetails>>
    {
        private readonly IMedicineStockService _medicineStockService;
        public GetMedicineByNameQueryHandler(IMedicineStockService medicineStockService)
        {
            _medicineStockService = medicineStockService;
        }

        public async Task<List<MedicineDetails>> Handle(GetMedicineByNameQuery request, CancellationToken cancellationToken)
        {
            var medicines = _medicineStockService.GetMedicineByName(request.MedicineName);
            return medicines;
        }
    }
}
