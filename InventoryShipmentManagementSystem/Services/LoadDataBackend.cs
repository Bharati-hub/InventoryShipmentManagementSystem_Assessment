using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryShipmentManagementSystem.Services
{
    class LoadDataBackend
    {
        public string Name { get; set; }

        public string ID
        {
            get; set;
        }


        public class ProductShipmentLoad
        {

            public async Task<DataTable> LoadAPIs()
            {


                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.restful-api.dev/objects");

                HttpResponseMessage response = client.GetAsync("").Result;
                var data = await response.Content.ReadAsStringAsync();
                var dataSet = JsonConvert.DeserializeObject<LoadDataBackend[]>(data);
                
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(string));
                dataTable.Columns.Add("Name", typeof(string));


                dataTable.Rows.Add(dataSet[0].ID.ToString(), dataSet[0].Name);
                dataTable.Rows.Add(dataSet[1].ID, dataSet[1].Name);
                return dataTable;
            }
        }
    }
}
