using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicines
{
    public class GetAllMedicinesQueryHandler : IRequestHandler<GetAllMedicinesQuery, List<MedicineDetails>>
    {
        private readonly IMedicineStockService _medicineStockService;
        public GetAllMedicinesQueryHandler(IMedicineStockService medicineStockService)
        {
            _medicineStockService = medicineStockService;
        }
        public async Task<List<MedicineDetails>> Handle(GetAllMedicinesQuery request, CancellationToken cancellationToken)
        {
            var medicines = _medicineStockService.GetAllMedicines();
            return medicines;
        }
    }
}
