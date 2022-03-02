using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ABCPharmacy.MedicineTrackingSystem.Application.Medicine;
using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Commands;
using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicineDetailsById;
using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicineDetailsByName;
using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicines;
using ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ABCPharmacy.MedicineTrackingSystem.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MedicinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns the list of All medicines 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<MedicineDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllMedicies()
        {
            var result = await _mediator.Send(new GetAllMedicinesQuery());
            return Ok(result);
        }

        /// <summary>
        /// Get Medicine Details for Medicine Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{medicineId:int}")]
        [ProducesResponseType(typeof(MedicineDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMedicineDetails(int medicineId)
        {
            var result = await _mediator.Send(new GetMedicineByIdQuery { MedicineId=medicineId});
            return Ok(result);
        }

        /// <summary>
        /// Search by Medicine Name
        /// </summary>
        /// <returns></returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(MedicineDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SearchMedicine(string medicineName)
        {
            var result = await _mediator.Send(new GetMedicineByNameQuery { MedicineName = medicineName });
            return Ok(result);
        }

        /// <summary>
        /// Add new medicine to the stock
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        [ProducesResponseType(typeof(List<MedicineDetails>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DataError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add(MedicineDetails medicine)
        {
            var result = await _mediator.Send(new AddMedicineCommand { Medicine = medicine });
            return Created("", result);
        }

    }
}