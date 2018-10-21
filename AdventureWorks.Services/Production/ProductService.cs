using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks.Services.Production
{
    public class ProductService : IProductService
    {
        private readonly DbModel.Entities _entities = new DbModel.Entities();

        public void CreateProduct(Product productToCreate)
        {
            var newProduct = _entities.Products.Create();

            newProduct.Name = productToCreate.Name;
            newProduct.Class = productToCreate.Class;
            newProduct.Color = productToCreate.Color;
            newProduct.DaysToManufacture = productToCreate.DaysToManufacture;
            newProduct.DiscontinuedDate = productToCreate.DiscontinuedDate;
            newProduct.FinishedGoodsFlag = productToCreate.FinishedGoodsFlag;
            newProduct.ListPrice = productToCreate.ListPrice;
            newProduct.MakeFlag = productToCreate.MakeFlag;
            newProduct.ProductLine = productToCreate.ProductLine;
            newProduct.ProductModelID = productToCreate.ProductModelID;
            newProduct.ProductNumber = productToCreate.ProductNumber;
            newProduct.ProductSubcategoryID = productToCreate.ProductSubcategoryID;
            newProduct.ReorderPoint = productToCreate.ReorderPoint;
            newProduct.SafetyStockLevel = productToCreate.SafetyStockLevel;
            newProduct.SellEndDate = productToCreate.SellEndDate;
            newProduct.SellStartDate = productToCreate.SellStartDate;
            newProduct.Size = productToCreate.Size;
            newProduct.SizeUnitMeasureCode = productToCreate.SizeUnitMeasureCode;
            newProduct.StandardCost = productToCreate.StandardCost;
            newProduct.Style = productToCreate.Style;
            newProduct.Weight = productToCreate.Weight;
            newProduct.WeightUnitMeasureCode = productToCreate.WeightUnitMeasureCode;

            newProduct.rowguid = Guid.NewGuid();
            newProduct.ModifiedDate = DateTime.UtcNow;

            _entities.Products.Add(newProduct);
            _entities.SaveChanges();
        }

        public bool DeleteProduct(int productId)
        {
            var product = _entities.Products.Find(productId);
            if (product != null)
            {
                _entities.Products.Remove(product);
                _entities.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<Product> GetProducts()
        {
            var query = from p in _entities.Products
                        select new Product
                        {
                            Id = p.ProductID,
                            Name = p.Name,
                            Class = p.Class,
                            Color = p.Color,
                            DaysToManufacture = p.DaysToManufacture,
                            DiscontinuedDate = p.DiscontinuedDate,
                            FinishedGoodsFlag = p.FinishedGoodsFlag,
                            ListPrice = p.ListPrice,
                            MakeFlag = p.MakeFlag,
                            ProductLine = p.ProductLine,
                            ProductModelID = p.ProductModelID,
                            ProductNumber = p.ProductNumber,
                            ProductSubcategoryID = p.ProductSubcategoryID,
                            ReorderPoint = p.ReorderPoint,
                            SafetyStockLevel = p.SafetyStockLevel,
                            SellEndDate = p.SellEndDate,
                            SellStartDate = p.SellStartDate,
                            Size = p.Size,
                            SizeUnitMeasureCode = p.SizeUnitMeasureCode,
                            StandardCost = p.StandardCost,
                            Style = p.Style,
                            Weight = p.Weight,
                            WeightUnitMeasureCode = p.WeightUnitMeasureCode,

                            ModifiedDate = p.ModifiedDate
                        };

            return query.ToArray();
        }

        public Product GetProduct(int productId)
        {
            var product = _entities.Products.Find(productId);
            if (product == null)
            {
                return null;
            }

            return new Product
            {
                Id = product.ProductID,
                Name = product.Name,
                Class = product.Class,
                Color = product.Color,
                DaysToManufacture = product.DaysToManufacture,
                DiscontinuedDate = product.DiscontinuedDate,
                FinishedGoodsFlag = product.FinishedGoodsFlag,
                ListPrice = product.ListPrice,
                MakeFlag = product.MakeFlag,
                ProductLine = product.ProductLine,
                ProductModelID = product.ProductModelID,
                ProductNumber = product.ProductNumber,
                ProductSubcategoryID = product.ProductSubcategoryID,
                ReorderPoint = product.ReorderPoint,
                SafetyStockLevel = product.SafetyStockLevel,
                SellEndDate = product.SellEndDate,
                SellStartDate = product.SellStartDate,
                Size = product.Size,
                SizeUnitMeasureCode = product.SizeUnitMeasureCode,
                StandardCost = product.StandardCost,
                Style = product.Style,
                Weight = product.Weight,
                WeightUnitMeasureCode = product.WeightUnitMeasureCode,

                ModifiedDate = product.ModifiedDate
            };
        }

        public bool UpdateProduct(Product updatedProduct)
        {
            var product = _entities.Products.Find(updatedProduct.Id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Class = updatedProduct.Class;
                product.Color = updatedProduct.Color;
                product.DaysToManufacture = updatedProduct.DaysToManufacture;
                product.DiscontinuedDate = updatedProduct.DiscontinuedDate;
                product.FinishedGoodsFlag = updatedProduct.FinishedGoodsFlag;
                product.ListPrice = updatedProduct.ListPrice;
                product.MakeFlag = updatedProduct.MakeFlag;
                product.ProductLine = updatedProduct.ProductLine;
                product.ProductModelID = updatedProduct.ProductModelID;
                product.ProductNumber = updatedProduct.ProductNumber;
                product.ProductSubcategoryID = updatedProduct.ProductSubcategoryID;
                product.ReorderPoint = updatedProduct.ReorderPoint;
                product.SafetyStockLevel = updatedProduct.SafetyStockLevel;
                product.SellEndDate = updatedProduct.SellEndDate;
                product.SellStartDate = updatedProduct.SellStartDate;
                product.Size = updatedProduct.Size;
                product.SizeUnitMeasureCode = updatedProduct.SizeUnitMeasureCode;
                product.StandardCost = updatedProduct.StandardCost;
                product.Style = updatedProduct.Style;
                product.Weight = updatedProduct.Weight;
                product.WeightUnitMeasureCode = updatedProduct.WeightUnitMeasureCode;

                product.ModifiedDate = DateTime.UtcNow;

                _entities.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
