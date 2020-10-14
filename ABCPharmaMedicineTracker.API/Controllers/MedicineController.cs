using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCPharmaMedicineTracker.API.DataInterface;
using ABCPharmaMedicineTracker.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABCPharmaMedicineTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Medicine>> GetMedicinesAsync()
        {
            return await _medicineRepository.GetAllMedicines();
        }
    }
}
