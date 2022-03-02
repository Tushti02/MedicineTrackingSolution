using System;
using System.Collections.Generic;
using System.Text;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine
{
    public class MedicineDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
