using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicineDetailsById
{
    public class GetMedicineByIdQueryHandler : IRequestHandler<GetMedicineByIdQuery, MedicineDetails>
    {
        private readonly IMedicineStockService _medicineStockService;
        public GetMedicineByIdQueryHandler(IMedicineStockService medicineStockService)
        {
            _medicineStockService = medicineStockService;
        }
        public async Task<MedicineDetails> Handle(GetMedicineByIdQuery request, CancellationToken cancellationToken)
        {
            var medicine = _medicineStockService.GetMedicineById(request.MedicineId);
            return medicine;
        }
    }
}
