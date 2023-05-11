using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Repository
{
    public class DECommerceRepository : IDECommerceRepository
    {
        private IConfiguration _configuration;
        private DECommerceDb _model;

        public DECommerceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _model = new DECommerceDb(_configuration.GetSection("ConnectionStrings:DynamicECommerce").Value);
        }

        //--------------------Users---------------------//ù

        bool IDECommerceRepository.CreateUsers(Users users)
        {
            bool result = false;


            _model.Users.Add(users);
            result = _model.SaveChanges() > 0;

            return result;
        }

        List<Users> IDECommerceRepository.GetUsers()
        {
            List<Users> users = new List<Users>();

            users = _model.Users.ToList();
            return users;
        }

        Users IDECommerceRepository.GetUserByID(int UserID)
        {
            Users user = _model.Users.FirstOrDefault(x => x.UserID == UserID);
            return user;
        }

        bool IDECommerceRepository.DeleteUsers(int UserID)
        {
            bool result = false;
            Users user = _model.Users.FirstOrDefault(x => x.UserID == UserID);

            _model.Remove(user);
            result = _model.SaveChanges() > 0;
            return result;
        }

        public Users GetUserByUsername(string username)
        {
            Users user = _model.Users.FirstOrDefault(u => u.Username == username);
            return user;
        }

        //-------------------------UserRole---------------------------//


        List<UserRole> IDECommerceRepository.GetUserRole()
        {
            List<UserRole> userList = new List<UserRole>();

            userList = _model.UserRole.ToList();
            return userList;
        }

        public UserRole GetUserRoleByUserId(int userId)
        {
            UserRole userRole = _model.UserRole.FirstOrDefault(x => x.UserID == userId);
            return userRole;

        }

        bool IDECommerceRepository.AddUserRole(UserRole userRole)
        {
            bool result = false;

            _model.UserRole.Add(userRole);
            result = _model.SaveChanges() > 0;
            return result;
        }

        //---------------------------Roles---------------------------//

        List<Roles> IDECommerceRepository.GetRoles()
        {
            List<Roles> roles = new List<Roles>();

            roles = _model.Roles.ToList();
            return roles;
        }

        public Roles GetRoleById(int roleId)
        {
            Roles role = _model.Roles.FirstOrDefault(u => u.RoleID == roleId);
            return role;
        }


        ////-------------------------Products---------------------------//

        bool IDECommerceRepository.CreateProducts(Products product)
        {
            bool result = false;


            _model.Products.Add(product);
            result = _model.SaveChanges() > 0;

            return result;
        }

        List<Products> IDECommerceRepository.GetProducts()
        {
            List<Products> products = new List<Products>();

            products = _model.Products.ToList();
            return products;
        }

        Products IDECommerceRepository.GetProductByID(int ProductID)
        {
            Products products = _model.Products.FirstOrDefault(x => x.ProductID == ProductID);
            return products;
        }

        bool IDECommerceRepository.DeleteProducts(int ProductID)
        {
            bool result = false;
            Products products = _model.Products.FirstOrDefault(x => x.ProductID == ProductID);

            _model.Remove(products);
            result = _model.SaveChanges() > 0; 
            return result;
        }

        List<Products> IDECommerceRepository.GetProductsByCategoriesID(int ProductCategoriesID)
        {
            List<Products> products = new List<Products>();

            products= _model.Products.ToList();

            return products;
        }




        //----------------------------ProductCategories--------------------------------//

        bool IDECommerceRepository.CreateProductCategories(ProductCategories productCategories)
        {
            bool result = false;


            _model.ProductCategories.Add(productCategories);
            result = _model.SaveChanges() > 0;

            return result;
        }

        List<ProductCategories> IDECommerceRepository.GetProductCategories()
        {
            List<ProductCategories> productCategories = new List<ProductCategories>();

            productCategories = _model.ProductCategories.ToList();
            return productCategories;
        }

        bool IDECommerceRepository.DeleteProductCategories(int ProductCategoriesID)
        {
            bool result = false;
            ProductCategories productCategories = _model.ProductCategories.FirstOrDefault(x => x.ProductCategoriesID == ProductCategoriesID);

            _model.Remove(productCategories);
            result = _model.SaveChanges() > 0;
            return result;
        }

        public ProductCategories GetProductsCategoriesbyId(int ProductsCategoriesID)
        {
            ProductCategories productCategories = _model.ProductCategories.FirstOrDefault(x => x.ProductCategoriesID == ProductsCategoriesID);
            return productCategories;
        }

        //------------------------------Orders-----------------------------//

        int IDECommerceRepository.CreateOrders(Orders orders)
        {
            bool results = false;

            _model.Orders.Add(orders);
            results = _model.SaveChanges() > 0;
            return orders.OrderID;
        }

        List<Orders> IDECommerceRepository.GetOrders()
        {
            List<Orders> orders = new List<Orders>();

            orders = _model.Orders.ToList();
            return orders;
        }

        bool IDECommerceRepository.DeleteOrders(int OrderID)
        {
            bool result = false;
            Orders orders = _model.Orders.FirstOrDefault(x => x.OrderID == OrderID);

            _model.Remove(orders);
            result = _model.SaveChanges() > 0;
            return result;
        }

        List<Orders> IDECommerceRepository.GetOrdersByUserID()
        {
            List<Orders> orders = new List<Orders>();

            orders = _model.Orders.ToList();

            return orders;
        }

        Orders IDECommerceRepository.GetOrdersByID(int OrderID)
        {
            Orders orders = _model.Orders.FirstOrDefault(x => x.OrderID == OrderID);
            return orders;
        }

        //-------------------------------OrderDetails--------------------------------//

        List<OrderDetails> IDECommerceRepository.GetOrderDetails()
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            orderDetails = _model.OrderDetails.ToList();
            return orderDetails;
        }

        bool IDECommerceRepository.CreateOrderDetail(OrderDetails orderDetail)
        {
            bool results = false;

            _model.OrderDetails.Add(orderDetail);
            results = _model.SaveChanges() > 0;
            return results;
        }
        List<OrderDetails> IDECommerceRepository.GetOrderDetailsByOrderID(int OrderID)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            orderDetails = _model.OrderDetails.Where(x => x.OrderID == OrderID).ToList();
            return orderDetails;
        }
        OrderDetails IDECommerceRepository.GetOrderDetailsByID(int OrderDetailsID)
        {
            OrderDetails orderDetails = _model.OrderDetails.FirstOrDefault(x => x.OrderDetailsID == OrderDetailsID);
            return orderDetails;
        }

        Configurations IDECommerceRepository.GetConfiguration()
        {
            Configurations configuration = _model.Configurations.FirstOrDefault();
            return configuration;
        }
    }
}
