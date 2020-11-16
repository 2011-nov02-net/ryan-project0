using System;
using System.Collections.Generic;
using System.Text;
using Project0.Entity.Entities;
using Project0.BusinessLibrary;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project0.ConsoleApp
{
    public class StoreRepository
    {
        private readonly project0Context _dbContext;

        /// <summary>
        /// Constructor to init a db context
        /// </summary>
        /// <param name="dbContext">The db context for getting tables</param>
        public StoreRepository(project0Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Method to get all the store locations
        /// </summary>
        public IEnumerable<BusinessLibrary.StoreLocation> GetStoreLocations()
        {
            int id = 0;
            List<BusinessLibrary.StoreLocation> locationList = new List<BusinessLibrary.StoreLocation>();

            IQueryable<Entity.Entities.StoreLocation> locations = _dbContext.StoreLocations;
            foreach(var l in locations)
            {
                BusinessLibrary.StoreLocation sl = new BusinessLibrary.StoreLocation(id, l.Name, l.InventoryId);
                locationList.Add(sl);
                id++;
            }

            return locationList;
        }

        /// <summary>
        /// Method to get a stores product inventory
        /// </summary>
        /// <param name="l">The stores location object</param>
        public IEnumerable<BusinessLibrary.Product> GetStoreInventory(BusinessLibrary.StoreLocation l)
        {
            //return list to hold all the products
            List<BusinessLibrary.Product> products = new List<BusinessLibrary.Product>();

            //get products from invetory of selected location
            IQueryable<Entity.Entities.StoreInventory> inventory = _dbContext.StoreInventories.Include(x => x.Product)
                .Where(x => x.LocationId == l.StoreLocationId + 1);
            
            //add each product to list
            foreach (var item in inventory)
            {
                BusinessLibrary.Product p = new BusinessLibrary.Product(item.ProductId, item.Product.Name, (double)item.Product.Price, item.ProductQty);
                products.Add(p);
            }

            return products;
        }

        /// <summary>
        /// Method to create an order in the db
        /// </summary>
        /// <param name="order">The order object with order info</param>\
        /// <param name="total">The grand total of order</param>
        public void CreateOrder(BusinessLibrary.Order order, double total)
        {
            //create order
            Entity.Entities.Order o = new Entity.Entities.Order();
            o.UserId = order.OrderCustomerId;
            o.StoreId = order.OrderStoreLocationId;
            o.OrderTime = DateTime.Now;
            o.OrderTotal = (decimal)total;

            //add and save
            _dbContext.Orders.Add(o);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method to create the orders items rows in db
        /// </summary>
        /// <param name="order">The order object with order info</param>
        /// <param name="products">A list of all the products in the order</param>
        public void CreateOrderProduct(BusinessLibrary.Order order, List<BusinessLibrary.Product> products)
        {
            //Get last orders id since all will be from last order
            IQueryable<Entity.Entities.Order> lastOrder = _dbContext.Orders.OrderByDescending(x => x.Id).Take(1);
            var last = lastOrder.First();

            //create order products
            foreach (var product in products)
            {
                Entity.Entities.OrderProduct op = new Entity.Entities.OrderProduct();
                op.OrderId = last.Id;
                op.ProductId = product.ProductId;
                op.ProductQty = product.ProductQty;
                op.ProductPricePaid = (decimal)product.ProductPrice;

                _dbContext.OrderProducts.Add(op);
            }

            //save
            _dbContext.SaveChanges();
        }

    }
}
