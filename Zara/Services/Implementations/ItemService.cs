using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.DBOperations;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Services.Implementations
{
    public class ItemService : IItemService
    {
        public bool DeleteItem(int itemID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.DeleteItem(itemID, connectionString);
        }

        public List<string> GetColors(int itemId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetColors(itemId, connectionString);
        }

        public ItemModel GetItemByID(int itemID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetItemByID(itemID, connectionString);
        }

        public List<ItemModel> GetItems()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetItems(connectionString);
        }


        public List<ItemModel> GetKidsItems()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetKidsItems(connectionString);
        }

        public List<ItemModel> GetKidsItemsByName(string naziv)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetKidsItemsByName(naziv, connectionString);
        }

        public List<ItemModel> GetKidsItemsByPrice(string price)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetKidsItemsByPrice(price, connectionString);
        }

        public List<ItemModel> GetManItems()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetManItems(connectionString);
        }

        public List<ItemModel> GetManItemsByName(string naziv)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetManItemsByName(naziv, connectionString);
        }

        public List<ItemModel> GetManItemsByPrice(string price)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetManItemsByPrice(price, connectionString);
        }

        public List<SizeModel> GetSizes(int itemID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetSizes(itemID, connectionString);
        }

        public List<ItemModel> GetWomanItems()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetWomanItems(connectionString);
        }

        public List<ItemModel> GetWomanItemsByName(string naziv)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetWomanItemsByName(naziv, connectionString);
        }

        public List<ItemModel> GetWomanItemsByPrice(string price)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.GetWomanItemsByPrice(price, connectionString);
        }

        public bool InsertItem(ItemModel item)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.InsertItem(item, connectionString);
        }

        public bool UpdateItem(ItemModel item)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ItemOperations.UpdateItem(item, connectionString);
        }
    }
}