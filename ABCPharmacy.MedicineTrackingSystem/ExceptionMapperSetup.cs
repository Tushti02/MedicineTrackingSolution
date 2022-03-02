using ABCPharmacy.MedicineTrackingSystem.Application.Shared;
using ABCPharmacy.MedicineTrackingSystem.Application.Shared.DataError;
using GlobalExceptionHandler.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ABCPharmacy.MedicineTrackingSystem.API
{
    /// <summary>
    /// Custom Mapper to Map Globally Handled Exceptions
    /// To Custom ApiException Model
    /// </summary>
    public static class ExceptionMapper
    {
        public static void MapExceptions(this ExceptionHandlerConfiguration cfg)
        {
            cfg.ContentType = "application/json";

            cfg.ResponseBody(s => JsonSerializer.Serialize(new
            {
                Message = "An error occured while processing your request"
            }));
            cfg.Map<ValidationFailedException>()
               .ToStatusCode(HttpStatusCode.BadRequest)
               .WithBody((ex, ctx) => SerializeException(ex));

            cfg.Map<NotFoundException>()
                    .ToStatusCode(HttpStatusCode.NotFound)
                  .WithBody((ex, ctx) => SerializeException(ex));

            cfg.Map<Exception>()
                .ToStatusCode(HttpStatusCode.InternalServerError)
                .WithBody((ex, ctx) => SerializeException(ex));
        }

        /// <summary>
        /// Serialize Validation Exception Errors
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static string SerializeException(Exception ex)
        {
            var errors = new DataError()
            {
                ErrorCode = DataErrorCodes.InternalServer.Code,
                Message = DataErrorCodes.InternalServer.Description,
            };
            string errorSerialized = JsonSerializer.Serialize(errors);
            return errorSerialized;

        }

        private static string SerializeException(ValidationFailedException ex)
        {
            DataError errors = new DataError()
            {
                ErrorCode = DataErrorCodes.BadRequest.Code,
                Message = DataErrorCodes.BadRequest.Description,
                Details = ex.Errors?.ToList()
            };
            string errorSerialized = JsonSerializer.Serialize(errors);
           
            return errorSerialized;

        }
        /// <summary>
        /// Serialize Validation Exception Errors
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static string SerializeException(NotFoundException ex)
        {
            DataError errors = new DataError()
            {
                ErrorCode = DataErrorCodes.NotFound.Code,
                Message = DataErrorCodes.NotFound.Description,
                Target = ex.Target
            };
            string errorSerialized = JsonSerializer.Serialize(errors);
            
            return errorSerialized;

        }

    }
}
