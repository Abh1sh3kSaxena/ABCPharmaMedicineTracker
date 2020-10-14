using ABCPharmaMedicineTracker.API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPharmaMedicineTracker.API.DataInterface
{
    public interface IMedicineRepository
    {
        Task<Medicine> GetMedicine(string medicineName);

        void AddMedicineDetails(Medicine medicine);

        Task<List<Medicine>> GetAllMedicines();
    }
}
