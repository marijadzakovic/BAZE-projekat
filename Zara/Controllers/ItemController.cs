using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Controllers
{
    public class ItemController : Controller
    {
        IItemService _itemService;
        ISizeService _sizeService;
        ISectorService _sectorService;

        public ItemController(IItemService itemService, ISectorService sectorService, ISizeService sizeService)
        {
            this._itemService = itemService;
            this._sizeService = sizeService;
            this._sectorService = sectorService;
        }

        // GET: Item
        public ActionResult Index()
        {
            List<ItemModel> items = this._itemService.GetItems();
            ViewBag.Items = items;
            return View();
        }
        public ActionResult Man()
        {
            List<ItemModel> items = this._itemService.GetManItems();
            ViewBag.Items = items;
            return View();
        }

        public ActionResult Woman()
        {
            List<ItemModel> items = this._itemService.GetWomanItems();
            ViewBag.Items = items;
            return View();
        }
        public ActionResult Kids()
        {
            List<ItemModel> items = this._itemService.GetKidsItems();
            ViewBag.Items = items;
            return View();
        }
       
        public ActionResult Create()
        {
            List<SectorModel> sectors = this._sectorService.GetSectors();
            List<SizeModel> sizes = this._sizeService.GetSizes();
            ViewBag.Sectors = sectors;
            ViewBag.Sizes = sizes;
            return View("Item");
        }

        public ActionResult Store(ItemModel item)
        {
            bool result = false;
            if (item.Id == 0)
            {
                result = this._itemService.InsertItem(item);
            }
            else
            {
                result = this._itemService.UpdateItem(item);
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Item", item);
            }
        }
      
        public ActionResult Delete(int itemID)
        {
            bool result = this._itemService.DeleteItem(itemID);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return null;
            }
        }

        public ActionResult Edit(int itemID)
        {
            List<SectorModel> sectors = this._sectorService.GetSectors();
            ViewBag.Sectors = sectors;
            List<SizeModel> sizes = this._sizeService.GetSizes();
            ViewBag.Sizes = sizes;
            ItemModel item = this._itemService.GetItemByID(itemID);
            return View("Item", item);
        }
        public ActionResult GetItemFullDetails(int itemID)
        {
            List<SizeModel> sizes = this._itemService.GetSizes(itemID);
            ViewBag.Sizes = sizes;
            List<string> colors = this._itemService.GetColors(itemID);
            ViewBag.Colors = colors;
            ItemModel item = this._itemService.GetItemByID(itemID);
            return View("ItemDetails", item);
        }
        public ActionResult Search(string searchValue, string searchBy)
        {
            List<ItemModel> allItems = this._itemService.GetItems();
            if (string.IsNullOrEmpty(searchValue))
            {
                ViewBag.SearchValue = searchValue;
                return View(allItems);
            }
            else
            {
                if (searchBy.Equals("Naziv"))
                {
                    List<ItemModel> items = this._itemService.GetWomanItemsByName(searchValue);
                    ViewBag.Items = items;
                    return View();
                } else if (searchBy.Equals("Cijena"))
                {
                    List<ItemModel> items = this._itemService.GetWomanItemsByPrice(searchValue);
                    ViewBag.Items = items;
                    return View();
                }
                else
                {
                    return null;
                }

            }
            
        }
        public ActionResult Search1(string searchValue, string searchBy)
        {
            List<ItemModel> allItems = this._itemService.GetItems();
            if (string.IsNullOrEmpty(searchValue))
            {
                ViewBag.SearchValue = searchValue;
                return View(allItems);
            }
            else
            {
                if (searchBy.Equals("Naziv"))
                {
                    List<ItemModel> items = this._itemService.GetWomanItemsByName(searchValue);
                    ViewBag.Items = items;
                    return View("Search");
                }
                else if (searchBy.Equals("Cijena"))
                {
                    List<ItemModel> items = this._itemService.GetWomanItemsByPrice(searchValue);
                    ViewBag.Items = items;
                    return View("Search");
                }
                else
                {
                    return null;
                }
            }

        }
        public ActionResult Search2(string searchValue, string searchBy)
        {
            List<ItemModel> allItems = this._itemService.GetItems();
            if (string.IsNullOrEmpty(searchValue))
            {
                ViewBag.SearchValue = searchValue;
                return View(allItems);
            }
            else
            {
                if (searchBy.Equals("Naziv"))
                {
                    List<ItemModel> items = this._itemService.GetManItemsByName(searchValue);
                    ViewBag.Items = items;
                    return View("Search");
                }
                else if (searchBy.Equals("Cijena"))
                {
                    List<ItemModel> items = this._itemService.GetManItemsByPrice(searchValue);
                    ViewBag.Items = items;
                    return View("Search");
                }
                else
                {
                    return null;
                }
            }

        }
        public ActionResult Search3(string searchValue, string searchBy )
        {
            List<ItemModel> allItems = this._itemService.GetItems();
            if (string.IsNullOrEmpty(searchValue))
            {
                ViewBag.SearchValue = searchValue;
                return View(allItems);
            }
            else
            {
                if (searchBy.Equals("Naziv"))
                {
                    List<ItemModel> items = this._itemService.GetKidsItemsByName(searchValue);
                    ViewBag.Items = items;
                    return View("Search");
                }
                else if (searchBy.Equals("Cijena"))
                {
                    List<ItemModel> items = this._itemService.GetKidsItemsByPrice(searchValue);
                    ViewBag.Items = items;
                    return View("Search");
                }
                else
                {
                    return null;
                }
            }

        }
    }
}