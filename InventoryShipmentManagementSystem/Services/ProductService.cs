
using InventoryShipmentManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryShipmentManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private DataTable table = new DataTable();

        public ProductService()
        {
            table.Columns.Add("Name");
            table.Columns.Add("Quantity");
            table.Columns.Add("Price");
        }
        
        public DataTable GetProductTable()
        {
            return table;
        }

        

        public void InsertRecord(string name, int quantity, double price)
        {
            
             table.Rows.Add(name, quantity, price);
        }

        public void UpdateRecord(int rowIndex,string name, int quantity, double price)
        {
           
                DataRow row = table.Rows[rowIndex];
                row["Name"] = name;
                row["Quantity"] = quantity;
                row["Price"] = price;
            
            
        }

        public void DeleteRecord(int rowIndex, DataGridView dataGridViewInventory = null)
        {
            if (dataGridViewInventory != null)
            {
                if (rowIndex >= 0 && rowIndex < dataGridViewInventory.Rows.Count)
                {
                    dataGridViewInventory.Rows.RemoveAt(rowIndex);
                }
            }
            else
            {
                if (rowIndex >= 0 && rowIndex < table.Rows.Count)
                {
                    table.Rows.RemoveAt(rowIndex);
                }
            }
        }
    }
}
