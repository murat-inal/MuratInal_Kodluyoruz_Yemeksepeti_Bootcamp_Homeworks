using Dapper;
using DapperProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperSampleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DapperSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /* Request'in Body'sinden alınan Department objesini Dapper'ın Execute metoduyla db'deki Department tablosuna ekler. */
        [HttpPost]
        public IActionResult DapperInsert([FromBody] Department department)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = @"Insert Into HumanResources.Department (DepartmentID, Name, GroupName, ModifiedDate) 
                                 values (@DepartmentID, @Name, @GroupName, @ModifiedDate);";

                db.Execute(sql, new
                {
                    DepartmentID = department.DepartmentID,
                    Name = department.Name,
                    GroupName = department.GroupName,
                    ModifiedDate = DateTime.Now
                });
            }
            return Ok();
        }

        /* Request'in Body'sinden alınan Department objesindeki Id ile db'deki Id'yi karşılaştırır, GroupName'ini değiştirir. */
        [HttpPut]
        public IActionResult DapperUpdate([FromBody] Department department)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = @"Update HumanResources.Department Set GroupName = @GroupName Where DepartmentID = @DepartmentId;";

                db.Execute(sql, new
                {
                    DepartmentId = department.DepartmentID,
                    GroupName = department.GroupName
                });
            }
            return Ok();
        }

        /* Kullanıcıdan alınan Id ile Db'deki ilgili Id'yi karşılaştırır. O Id'deki satırı siler. */
        [HttpDelete("{id}")]
        public IActionResult DapperDelete(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = @"Delete From HumanResources.Department where DepartmentID = @Id;";
                db.Execute(sql, new
                {
                    Id = id
                });
            }
            return Ok();
        }

        /* Db'deki Department tablosuna Select işlemi uygulanarak dönen veriler belirlenen Department modeline map ediliyor. */
        [HttpGet]
        public IActionResult DapperSelectInQuery()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = "Select * From HumanResources.Department;";
                IEnumerable<Department> department = db.Query<Department>(sql);
            }
            return Ok();
        }

        /* Kullanıcıdan alınan Id'ye göre, Query metodu kullanılarak, Db'deki ilgili satır siliniyor. */
        [HttpDelete("{id}")]
        public IActionResult DapperDeleteInQuery(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = @"Delete From HumanResources.Department where DepartmentID = @Id;";
                db.Query(sql, new
                {
                    Id = id
                });
            }
            return Ok();
        }

        /* Kullanıcıdan alınan Id'ye göre, QueryMultiple metodu kullanılarak, hem Department hem de 
         * EmployeeDepartmentHistory tablolarından ilgili satırlar çekilir. Daha sonra gelen veriler
         * oluşturulan ilgili modellere map edilir. */
        [HttpGet("{id}")]
        public IActionResult DapperQueryMultipleMapping(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = @"Select * From [HumanResources].[Department] where DepartmentID = @DepartmentID;
                               Select * From [HumanResources].[EmployeeDepartmentHistory] where DepartmentID = @DepartmentID;";

                var multipleQuery = db.QueryMultiple(sql, new { DepartmentID = id });

                var departments = multipleQuery.Read<Department>();
                var employeeDepartmentHistories = multipleQuery.Read<EmployeeDepartmentHistory>();
            }
            return Ok();
        }

        /* Açılan bir transaction içerisinde farklı tablolara farklı veriler eklendi. 
         * Transaction commit edilmediği sürece burada yapılan işlemler db'ye yansımaz. 
         * Transaction kod bloğundan çıkıldığı veya commit edildiği zaman yapılan değişiklikler db'ye kaydedilir. */
        [HttpPost]
        public IActionResult DapperTransactionInsert()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                using (var transaction = db.BeginTransaction())
                {
                    string sql1 = @"Insert Into HumanResources.Department (DepartmentID, Name, GroupName, ModifiedDate) 
                                 values (@DepartmentID, @Name, @GroupName, @ModifiedDate);";

                    db.Execute(sql1, new
                    {
                        DepartmentID = 17,
                        Name = "Maintenance",
                        GroupName = "Manufacturing",
                        ModifiedDate = DateTime.Now
                    }, transaction);

                    string sql2 = @"Insert Into [Production].[Culture] (CultureID, Name, ModifiedDate) 
                                 values (@CultureID, @Name, @ModifiedDate);";

                    db.Execute(sql2, new
                    {
                        CultureID = "tr",
                        Name = "Turkish",
                        ModifiedDate = DateTime.Now
                    }, transaction);


                    string sql3 = @"Insert Into [Production].[ProductCategory] (ProductCategoryID, Name, rowguid, ModifiedDate) 
                                 values (@ProductCategoryID, @Name, @rowguid, @ModifiedDate);";

                    db.Execute(sql3, new
                    {
                        ProductCategoryID = 5,
                        Name = "Health Care",
                        rowguid = Guid.NewGuid(),
                        ModifiedDate = DateTime.Now
                    }, transaction);

                    transaction.Commit();
                }
            }
            return Ok();
        }

        /* Query Metodu kullanılarak One-To-One ilişkisi olan strongly type bir liste dönülür. */
        [HttpGet]
        public IActionResult DapperOneToOneMapping()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = @"Select* From [Production].[Product] as product
                            INNER JOIN [Sales].[SalesOrderDetail] as salesOrderDetail
                            on dp.DepartmentID = dpHistory.DepartmentID;";

                var products = db.Query<Product, SalesOrderDetail, Product>(sql, (product, salesOrderDetail) =>
                   {
                       product.ProductID = salesOrderDetail.ProductID;
                       return product;
                   },
                splitOn: "DepartmentID").Distinct().ToList();
            }
            return Ok();
        }

        /* Query Metodu kullanılarak One-To-Many ilişkisi olan strongly type bir liste dönülür. */
        [HttpGet]
        public IActionResult DapperOneToManyMapping()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = @"Select * From [Production].[Product] as product
                            INNER JOIN [Production].[WorkOrder] as workOrder
                            on product.ProductID = workOrder.ProductID;";

                var productDictionary = new Dictionary<int, Product>();

                var result = db.Query<Product, WorkOrder, Product>(sql, (product, workOrder) =>
                     {
                         Product productEntity;

                         if (!productDictionary.TryGetValue(product.ProductID, out productEntity))
                         {
                             productEntity = product;
                             productDictionary.Add(product.ProductID, productEntity);
                         }
                         productEntity.ModifiedDate = DateTime.Now;
                         return productEntity;
                     },
                   splitOn: "ProductID").Distinct().ToList();
            }
            return Ok();
        }

        /* DbCommand nesnelerinin bir özelliği olan commandType default olarak text olarak ayarlanmıştır. Burada
         * Query metodu ve stored procedure kullanılarak db'den 485 id nolu veri alınıp Product modeline maplenmiştir. */
        public IActionResult DapperStoredProcedure()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                var products = db.Query<Product>("Product_Select", new { ProductID = 485 }, commandType: CommandType.StoredProcedure).ToList();
            }

            return Ok();
        }

        /* Db'den gelen sonucu önceden oluşturulmuş model tipinde map eder.  */
        [HttpGet]
        public IActionResult DapperResultMapping()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                {
                    db.Open();
                }

                string sql = @"Select * From [Production].[Product];";

                var products = db.Query<Product>(sql).ToList();
            }
            return Ok();
        }
    }
}
