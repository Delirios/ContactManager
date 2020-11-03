using ContactManager.ViewModels;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    public class ContactManagerService : IContactManagerService
    {
        public IEnumerable<UserViewModel> ReadCSV(IFormFile file)
        {
            using (StreamReader streamReader = new StreamReader(file.OpenReadStream()))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var result = csvReader.GetRecords<UserViewModel>().ToList();
                    return result;
                }
            }

        }
    }
}
