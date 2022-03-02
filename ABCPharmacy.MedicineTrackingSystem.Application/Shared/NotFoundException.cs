using System;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Shared
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }
        public NotFoundException(Exception ex) : base(ex.Message, ex)
        {
        }

        public NotFoundException(string target)
        {
            Target = target;
        }

        public string Target { get; }
    }
}
