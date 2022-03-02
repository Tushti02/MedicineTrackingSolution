using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Services
{
    public interface IMedicineStockService
    {
        List<MedicineDetails> GetAllMedicines();
        MedicineDetails GetMedicineById(int id);
        List<MedicineDetails> GetMedicineByName(string name);
        Task<List<MedicineDetails>> AddMedicineToStockAsync(MedicineDetails medicine);
    }
}
