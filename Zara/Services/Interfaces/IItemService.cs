using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.Models.DB;

namespace Zara.Services.Interfaces
{
    public interface IItemService
    {
        List<ItemModel> GetItems();
        ItemModel GetItemByID(int itemID);
        bool InsertItem(ItemModel item);
        bool UpdateItem(ItemModel item);
        bool DeleteItem(int itemID);
        List<ItemModel> GetManItems();
        List<ItemModel> GetWomanItems();
        List<ItemModel> GetKidsItems();
        List<SizeModel> GetSizes(int itemID);
        List<string> GetColors(int itemId);
        List<ItemModel> GetWomanItemsByName(string naziv);
        List<ItemModel> GetManItemsByName(string naziv);

        List<ItemModel> GetKidsItemsByName(string naziv);
        List<ItemModel> GetWomanItemsByPrice(string price);
        List<ItemModel> GetKidsItemsByPrice(string price);
        List<ItemModel> GetManItemsByPrice(string price);
    }
}