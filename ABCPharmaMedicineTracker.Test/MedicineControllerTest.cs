using ABCPharmaMedicineTracker.API.Controllers;
using ABCPharmaMedicineTracker.API.DataInterface;
using ABCPharmaMedicineTracker.API.Model;
using ABCPharmaMedicineTracker.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ABCPharmaMedicineTracker.Test
{
    public class MedicineControllerTest
    {
        readonly MedicineController _medicineController;
        public MedicineControllerTest()
        {
            var mockService = new Mock<IMedicineRepository>();
            mockService.Setup(x => x.GetAllMedicines()).ReturnsAsync(GenerateMedicine());
            _medicineController = new MedicineController(mockService.Object);
        }

        [Fact]
        public async void ShouldReturnAllMedicine()
        {
            var result = await _medicineController.GetMedicinesAsync();
            var viewResult = Assert.IsType<List<Medicine>>(result);
            Assert.Equal(3, viewResult.Count);
        }

        [Fact]

        public  void ShouldAddMedicine() { 
            var mockService = new Mock<IMedicineRepository>();
            //mockService.Setup(x => x.AddMedicineDetails(It.IsAny<Medicine>()));
            var medicineController = new MedicineController(mockService.Object);
           
            Medicine m = new Medicine();
            m.Name = "Drug4";
            m.Price = 14;
            m.Quantity = 200;
            m.ExpiryDate = new DateTime(2020, 11, 12);
            m.Brand = "Brand1";

            medicineController.AddMedicine(m);

            mockService.Verify(x => x.AddMedicineDetails(It.IsAny<Medicine>()), Times.Once);
        }

        private List<Medicine> GenerateMedicine()
        {
            List<Medicine> medicines = new List<Medicine>();
            Medicine m = new Medicine();
            m.Name = "Drug1";
            m.Price = 14;
            m.Quantity = 200;
            m.ExpiryDate = new DateTime(2020, 11, 12);
            m.Brand = "Brand1";
            medicines.Add(m);

            m.Name = "Drug2";
            m.Price = 14;
            m.Quantity = 200;
            m.ExpiryDate = new DateTime(2020, 11, 12);
            m.Brand = "Brand1";
            medicines.Add(m);

            m.Name = "Drug3";
            m.Price = 14;
            m.Quantity = 200;
            m.ExpiryDate = new DateTime(2020, 11, 12);
            m.Brand = "Brand1";
            medicines.Add(m);


            return medicines;
        }
    }
}
