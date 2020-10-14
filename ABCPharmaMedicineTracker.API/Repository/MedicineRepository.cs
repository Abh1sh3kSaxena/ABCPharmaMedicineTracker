using ABCPharmaMedicineTracker.API.DataInterface;
using ABCPharmaMedicineTracker.API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace ABCPharmaMedicineTracker.API.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly IDataContext _dataContext;

        public MedicineRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<ActionResult> AddMedicineDetails(Medicine medicine)
        {
            throw NotImplementedException;
        }

        public async Task<List<Medicine>> GetAllMedicines()
        {
            string jsonString = await _dataContext.ReadJsonValue();
            return StringToJson(jsonString);
        }

        public async Task<Medicine> GetMedicine(string medicineName)
        {
            string jsonString = await _dataContext.ReadJsonValue();
            Medicine mc = StringToJson(jsonString).FirstOrDefault(x => x.Name.Equals(medicineName));
            return mc;
        }

        private List<Medicine> StringToJson(string jsonString)
        {
            List<Medicine> medicineList = new List<Medicine>();
            try
            {
                var jObject = JObject.Parse(jsonString);

                foreach( var item in jObject["medicine"])
                {
                    Medicine medicine = new Medicine();
                    if(item != null)
                    {
                        medicine.Name = item["name"].ToString();
                        medicine.Brand = item["brand"].ToString();
                        medicine.Price = Decimal.Parse(item["price"].ToString());
                        medicine.Quantity = Int32.Parse(item["quantity"].ToString());
                        medicine.ExpiryDate = DateTime.Parse(item["expirydate"].ToString());
                        medicine.Notes = item["note"].ToString();
                    }
                    medicineList.Add(medicine);
                }
            }
            catch(Exception)
            {
                throw;
            }
            return medicineList;
        }

        private string JsonToString(Medicine medicine)
        {
            StringBuilder builderMachine = new StringBuilder();
            builderMachine.Append("{");
            builderMachine.Append("'brand'" + ": '" + medicine.Brand + "',");
            builderMachine.Append("'expirydate'" + ": '" + medicine.ExpiryDate.ToString() + "',");
            builderMachine.Append("'name'" + ": '" + medicine.Name + "',");
            builderMachine.Append("'price'" + ": '" + medicine.Price.ToString() + "',");
            builderMachine.Append("'quantity'" + ": '" + medicine.Quantity.ToString() + "',");
            builderMachine.Append("'note'" + ": '" + medicine.Notes + "'");
            builderMachine.Append("}");
            return builderMachine.ToString();
        }
    }
}
