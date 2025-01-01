
using InventoryShipmentManagementSystem.Services;
using System.Data;

namespace ProductTest
{
    public class Tests
    {
        [TestFixture]
        public class ProductServiceTests
        {
            private ProductService productService;

            [SetUp]
            public void Setup()
            {
                productService = new ProductService();
            }

            [Test]
            public void InsertRecord_ShouldAddRecordToTable()
            {

                // Arrange
                string expectedName = "Product1";
                int expectedQuantity = 10;
                double expectedPrice = 100.0;

                // Act
                productService.InsertRecord(expectedName, expectedQuantity, expectedPrice);
                DataTable table = productService.GetProductTable();
                DataRow insertedRow = table.Rows[0];

                // Assert
                Assert.AreEqual(expectedName, insertedRow["Name"]);
                Assert.AreEqual(expectedQuantity, int.Parse(insertedRow["Quantity"].ToString()));
                Assert.AreEqual(expectedPrice, double.Parse(insertedRow["Price"].ToString()));
                productService.InsertRecord("Product1", 10, 100.0);

                
            }

            [Test]
            public void InsertAndUpdateRecord_ShouldModifyRecordInTable()
            {
                // Arrange
                string initialName = "Product1";
                int initialQuantity = 10;
                double initialPrice = 100.0;

                string updatedName = "Product2";
                int updatedQuantity = 20;
                double updatedPrice = 200.0;

                // Act
                productService.InsertRecord(initialName, initialQuantity, initialPrice);
                productService.UpdateRecord(0, updatedName, updatedQuantity, updatedPrice);

                DataTable table = productService.GetProductTable();

                // Assert
                Assert.AreEqual(1, table.Rows.Count);
                Assert.AreEqual(updatedName, table.Rows[0]["Name"]);
                Assert.AreEqual(updatedQuantity, int.Parse(table.Rows[0]["Quantity"].ToString()));
                Assert.AreEqual(updatedPrice, double.Parse(table.Rows[0]["Price"].ToString()));
            }
            

            [Test]
            public void DeleteRecord_ShouldRemoveRecordFromTable()
            {
                productService.InsertRecord("Product1", 10, 100.0);
                productService.DeleteRecord(0);

                DataTable table = productService.GetProductTable();
                Assert.AreEqual(0, table.Rows.Count);
            }
        }
    }
}