using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicines
{
    public class GetAllMedicinesQuery :IRequest<List<MedicineDetails>>
    {
    }
}
