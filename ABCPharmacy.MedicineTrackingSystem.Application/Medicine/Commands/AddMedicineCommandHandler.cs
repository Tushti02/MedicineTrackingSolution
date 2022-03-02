using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Services;
using ABCPharmacy.MedicineTrackingSystem.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Commands
{
    public class AddMedicineCommandHandler : IRequestHandler<AddMedicineCommand, List<MedicineDetails>>
    {
        private readonly IMedicineStockService _medicineStockService;
        public AddMedicineCommandHandler(IMedicineStockService medicineStockService)
        {
            _medicineStockService = medicineStockService;
        }
        public async Task<List<MedicineDetails>> Handle(AddMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicines = await _medicineStockService.AddMedicineToStockAsync(request.Medicine);
            return medicines;
        }
    }
}
