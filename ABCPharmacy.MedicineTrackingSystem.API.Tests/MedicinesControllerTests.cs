using ABCPharmacy.MedicineTrackingSystem.API.API.Controllers;
using ABCPharmacy.MedicineTrackingSystem.Application.Medicine;
using ABCPharmacy.MedicineTrackingSystem.Application.Medicine.Queries.GetMedicines;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ABCPharmacy.MedicineTrackingSystem.API.Tests
{
    public class MedicinesControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private MedicinesController _controller;

        public MedicinesControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new MedicinesController(_mockMediator.Object);
        }
        [Fact]
        public async Task GetAllMedicies_Returns_All_MedicinesAsync()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllMedicinesQuery>(), CancellationToken.None)).
                ReturnsAsync(new List<MedicineDetails>());

            var result = await _controller.GetAllMedicies();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllMedicinesQuery>(), CancellationToken.None), Times.Once);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
