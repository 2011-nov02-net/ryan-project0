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
        private readonly project0Context _dbContext2;
        private readonly project0Context _dbContext3;

        /// <summary>
        /// Constructor to init a db context
        /// </summary>
        /// <param name="dbContext">The db context for getting tables</param>
        public StoreRepository(project0Context dbContext, project0Context dbContext2, project0Context dbContext3)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbContext2 = dbContext2 ?? throw new ArgumentNullException(nameof(dbContext));
            _dbContext3 = dbContext2 ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Method to get all the store locations
        /// </summary>
        public IEnumerable<BusinessLibrary.StoreLocation> GetStoreLocations()
        {
            int id = 0;
            List<BusinessLibrary.StoreLocation> locationList = new List<BusinessLibrary.StoreLocation>();

            IQueryable<Entity.Entities.StoreLocation> locations = _dbContext.StoreLocations;
            foreach (var l in locations)
            {
                BusinessLibrary.StoreLocation sl = new BusinessLibrary.StoreLocation(id, l.Name);
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
            o.StoreId = order.OrderStoreLocationId + 1;
            o.OrderTime = DateTime.Now;
            o.OrderTotal = (decimal)total;

            //add and save
            _dbContext.Orders.Add(o);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method to create the orders items rows in db
        /// </summary>
        /// <param name="products">A list of all the products in the order</param>
        public void CreateOrderProduct(List<BusinessLibrary.Product> products)
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

        /// <summary>
        /// Method to get a customer object by its id
        /// </summary>
        /// <param name="customerId">The id of the customer to get the object from db</param>
        public BusinessLibrary.Customer GetCustomerById(int customerId)
        {
            IQueryable<Entity.Entities.User> customers = _dbContext2.Users.Where(x => x.Id == customerId);
            var c = customers.First();

            BusinessLibrary.Customer customer = new Customer(c.Id, c.FirstName, c.LastName, c.UserType);

            return customer;
        }

        /// <summary>
        /// Method to get a customer object by its first and last name
        /// </summary>
        /// <param name="firstName">The firstname of the customer to get the object from db</param>
        /// <param name="lastName">The firstname of the customer to get the object from db</param>
        public BusinessLibrary.Customer GetCustomerByName(string firstName, string lastName)
        {
            BusinessLibrary.Customer customer = null;

            IQueryable<Entity.Entities.User> customers = _dbContext.Users;
            foreach(var c in customers)
            {
                if(c.FirstName.Equals(firstName, StringComparison.InvariantCultureIgnoreCase) && c.LastName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase))
                {
                    customer = new Customer(c.Id, c.FirstName, c.LastName, c.UserType);
                }
            }

            return customer;
        }

        /// <summary>
        /// Method to get a store object by its id
        /// </summary>
        /// <param name="storeId">The id of the store to get the object from db</param>
        public BusinessLibrary.StoreLocation GetStoreById(int storeId)
        {
            BusinessLibrary.StoreLocation store = null;

            IQueryable<Entity.Entities.StoreLocation> locations = _dbContext3.StoreLocations;
            foreach(var l in locations)
            {
                if (l.Id == storeId)
                {
                    store = new BusinessLibrary.StoreLocation(storeId, l.Name);
                }
            }

            return store;
        }

        /// <summary>
        /// Method to get all orders from a specific store
        /// </summary>
        /// <param name="l">The location object to get orders from</param>
        public IEnumerable<BusinessLibrary.Order> GetOrdersByLocation(BusinessLibrary.StoreLocation l)
        {
            List<BusinessLibrary.Order> ordersList = new List<BusinessLibrary.Order>();

            IQueryable<Entity.Entities.Order> orders = _dbContext.Orders.Where(x => x.StoreId == l.StoreLocationId);
            foreach (var o in orders)
            {
                Customer c = GetCustomerById(o.UserId);
                BusinessLibrary.Order order = new BusinessLibrary.Order(o.Id, c, o.OrderTime, GetStoreById(o.StoreId + 1), o.OrderTotal);
                ordersList.Add(order);
            }

            return ordersList;
        }

        /// <summary>
        /// Method to get all orders from a specific customer
        /// </summary>
        /// <param name="c">The customer object to get orders from</param>
        public IEnumerable<BusinessLibrary.Order> GetOrdersByCustomer(BusinessLibrary.Customer c)
        {
            List<BusinessLibrary.Order> ordersList = new List<BusinessLibrary.Order>();

            IQueryable<Entity.Entities.Order> orders = _dbContext.Orders.Where(x => x.UserId == c.CustomerId);
            foreach (var o in orders)
            {
                Customer cust = GetCustomerById(o.UserId);
                BusinessLibrary.StoreLocation sl = new BusinessLibrary.StoreLocation();
                sl = GetStoreById(o.StoreId + 1);
                BusinessLibrary.Order order = new BusinessLibrary.Order(o.Id, cust, o.OrderTime, sl, o.OrderTotal);
                ordersList.Add(order);
            }

            return ordersList;
        }

        /// <summary>
        /// Method to get the products from an order
        /// </summary>
        /// <param name="orderId">The id of the order to get the products from</param>
        public IEnumerable<BusinessLibrary.Product> GetOrderDetails(int orderId)
        {
            List<BusinessLibrary.Product> orderProductsList = new List<BusinessLibrary.Product>();

            IQueryable<Entity.Entities.OrderProduct> orders = _dbContext.OrderProducts.Include(x => x.Product).Where(x => x.OrderId == orderId);
            foreach(var p in orders)
            {
                BusinessLibrary.Product prod = new BusinessLibrary.Product(p.ProductId, p.Product.Name, (double)p.ProductPricePaid, p.ProductQty);
                orderProductsList.Add(prod);
            }

            return orderProductsList;
        }

        /// <summary>
        /// Method to get the id of the last order
        /// </summary>
        public int GetLastOrderId()
        {
            IQueryable<Entity.Entities.Order> orders = _dbContext.Orders.OrderByDescending(x => x.Id);
            var last = orders.First();

            return last.Id;
        }

    }
}
