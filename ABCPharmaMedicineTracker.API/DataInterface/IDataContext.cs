using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPharmaMedicineTracker.API.DataInterface
{
    public interface IDataContext
    {
        Task<string> ReadJsonValue();
        void SaveJsonValue(string UpdatedJson);
    }
}
