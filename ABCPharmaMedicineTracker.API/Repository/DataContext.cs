using ABCPharmaMedicineTracker.API.DataInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPharmaMedicineTracker.API.Repository
{
    public class DataContext : IDataContext
    {
        private string _jsonPath = @"./MedicineDataJson/MedicineData.json";
        public DataContext()
        {
        }

        public Task<string> ReadJsonValue()
        {
            try
            {
                return File.ReadAllTextAsync(_jsonPath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveJsonValue(string UpdatedJson)
        {
            try
            {
                File.WriteAllTextAsync(_jsonPath, UpdatedJson);
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}
