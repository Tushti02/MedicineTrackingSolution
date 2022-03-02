using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries;
using ABCPharmacy.MedicineTrackingSystem.Application.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Services
{
    public class MedicineStockService : IMedicineStockService
    {
        private const string _fileName = @"C:\Downloads\SapientTest\ABCPharmacy.MedicineTrackingSystem.Application\Medicine\Services\Medicines.json";
        public async Task<List<MedicineDetails>> AddMedicineToStockAsync(MedicineDetails medicine)
        {
            try
            {
                List<MedicineDetails> medicines = GetAllMedicines();
                medicines.Add(medicine);
                var jsonString = JsonSerializer.Serialize(medicines);
                using (FileStream fs = File.Create(_fileName))
                {
                    await JsonSerializer.SerializeAsync(fs, medicines);
                }
                return medicines;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<MedicineDetails> GetAllMedicines()
        {
            try
            {
                var jsonString = File.ReadAllText(_fileName);
                var medicines = JsonSerializer.Deserialize<List<MedicineDetails>>(jsonString);
                return medicines;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public MedicineDetails GetMedicineById(int id)
        {
            try
            {
                var medicine = GetAllMedicines().Where(x => x.Id == id).ToList();
                if (medicine.Any())
                {
                    return medicine.FirstOrDefault();
                }
                else
                {
                    throw new NotFoundException();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<MedicineDetails> GetMedicineByName(string name)
        {
            try
            {
                var medicine = GetAllMedicines().Where(x => x.Name.Contains(name)).ToList();
                if (medicine.Any())
                {
                    return medicine;
                }
                else
                {
                    throw new NotFoundException();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
