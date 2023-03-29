using DECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Interfaces
{
    public interface IDECommerceRepository
    {

        //Users

        List<Users> GetUsers();
        bool CreateUsers(Users users);
        Users GetUserByID(int UserID);
        bool DeleteUsers(int UserID);
        Users GetUserByUsername(string userName);

        //UserRole

        List<UserRole> GetUserRole();
        UserRole GetUserRoleByUserId(int UserID);
        bool AddUserRole(UserRole userRole);

        //Roles

        List<Roles>GetRoles();
        Roles GetRoleById(int roleId);

        //Products

        List<Products> GetProducts();
        bool CreateProducts(Products products);
        Products GetProductByID(int ProductID);
        bool DeleteProducts(int ProductID);
        List<Products> GetProductsByCategoriesID(int ProductCategoriesID);
        

        //ProductCategories

        bool CreateProductCategories(ProductCategories productCategories);
        List<ProductCategories> GetProductCategories();
        bool DeleteProductCategories(int ProductCategoriesID);
        ProductCategories GetProductsCategoriesbyId(int ProductCategoriesID);

        //Orders

        bool CreateOrders(Orders orders);
        List<Orders> GetOrders();
        Orders GetOrdersByID(int OrdersID);
        List<Orders> GetOrdersByUserID();
        bool DeleteOrders(int OrderID);

        //OrderDetails

        List<OrderDetails> GetOrderDetails();
        List<OrderDetails> GetOrderDetailsByOrderID(int OrderID);
        OrderDetails GetOrderDetailsByID(int OrderDetailsID);
    }

     
}
