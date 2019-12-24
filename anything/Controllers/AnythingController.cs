using anything.DTO.Response;
using AnythingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace anything.Controllers
{
    public class AnythingController : ApiController
    {
        WideWorldImportersEntities db = new WideWorldImportersEntities();
        public AnythingController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IEnumerable<StockItemDTO> GetStockItems()
        {
            using (WideWorldImportersEntities entities = new WideWorldImportersEntities())
            {
                //Retrieving all items from  the database
                var StockItemsFromDB = entities.StockItems.ToList();

                //filling the retirieved item into a DTO list
                var ListOfStockItemsDTO = new List<StockItemDTO>();
                foreach (var stockItem in StockItemsFromDB)
                {
                    ListOfStockItemsDTO.Add(new StockItemDTO()
                    {
                        ColorID = stockItem.ColorID,
                        Barcode = stockItem.Barcode,
                        Brand = stockItem.Brand,
                        CustomFields = stockItem.CustomFields,
                        InternalComments = stockItem.InternalComments,
                        IsChillerStock = stockItem.IsChillerStock,
                        LastEditedBy = stockItem.LastEditedBy,
                        LeadTimeDays = stockItem.LeadTimeDays,
                        MarketingComments = stockItem.MarketingComments,
                        OuterPackageID = stockItem.OuterPackageID,
                        Photo = stockItem.Photo,
                        QuantityPerOuter = stockItem.QuantityPerOuter,
                        RecommendedRetailPrice = stockItem.RecommendedRetailPrice,
                        SearchDetails = stockItem.SearchDetails,
                        Size = stockItem.Size,
                        StockItemID = stockItem.StockItemID,
                        StockItemName = stockItem.StockItemName,
                        SupplierID = stockItem.SupplierID,
                        Tags = stockItem.Tags,
                        TaxRate = stockItem.TaxRate,
                        TypicalWeightPerUnit = stockItem.TypicalWeightPerUnit,
                        UnitPackageID = stockItem.UnitPackageID,
                        UnitPrice = stockItem.UnitPrice,
                        ValidFrom = stockItem.ValidFrom,
                        ValidTo = stockItem.ValidTo
                    });
                }

                return ListOfStockItemsDTO;
            }
        }

        [HttpGet]
        public StockItemDTO GetStockItems(int id)
        {
            using (WideWorldImportersEntities entities = new WideWorldImportersEntities())
            {
                var StockItemInDB = entities.StockItems.FirstOrDefault(e => e.StockItemID == id);
                return new StockItemDTO()
                {
                    ColorID = StockItemInDB.ColorID,
                    Barcode = StockItemInDB.Barcode,
                    Brand = StockItemInDB.Brand,
                    CustomFields = StockItemInDB.CustomFields,
                    InternalComments = StockItemInDB.InternalComments,
                    IsChillerStock = StockItemInDB.IsChillerStock,
                    LastEditedBy = StockItemInDB.LastEditedBy,
                    LeadTimeDays = StockItemInDB.LeadTimeDays,
                    MarketingComments = StockItemInDB.MarketingComments,
                    OuterPackageID = StockItemInDB.OuterPackageID,
                    Photo = StockItemInDB.Photo,
                    QuantityPerOuter = StockItemInDB.QuantityPerOuter,
                    RecommendedRetailPrice = StockItemInDB.RecommendedRetailPrice,
                    SearchDetails = StockItemInDB.SearchDetails,
                    Size = StockItemInDB.Size,
                    StockItemID = StockItemInDB.StockItemID,
                    StockItemName = StockItemInDB.StockItemName,
                    SupplierID = StockItemInDB.SupplierID,
                    Tags = StockItemInDB.Tags,
                    TaxRate = StockItemInDB.TaxRate,
                    TypicalWeightPerUnit = StockItemInDB.TypicalWeightPerUnit,
                    UnitPackageID = StockItemInDB.UnitPackageID,
                    UnitPrice = StockItemInDB.UnitPrice,
                    ValidFrom = StockItemInDB.ValidFrom,
                    ValidTo = StockItemInDB.ValidTo
                };
            }
        }

        [HttpDelete]
        public StockItem DeleteStockItem(int id)
        {
            using (WideWorldImportersEntities entities = new WideWorldImportersEntities())
            {
                var StockItemInDB = entities.StockItems.FirstOrDefault(e => e.StockItemID == id);
                return entities.StockItems.Remove(StockItemInDB);
            }

        }

        [HttpPost]
        public StockItemDTO CreateStockItem(StockItemDTO NewstockItem)
        {
            using (WideWorldImportersEntities entities = new WideWorldImportersEntities())
            {
                var NewItem = new StockItemDTO()
                {
                    ColorID = NewstockItem.ColorID,
                    Barcode = NewstockItem.Barcode,
                    Brand = NewstockItem.Brand,
                    CustomFields = NewstockItem.CustomFields,
                    InternalComments = NewstockItem.InternalComments,
                    IsChillerStock = NewstockItem.IsChillerStock,
                    LastEditedBy = NewstockItem.LastEditedBy,
                    LeadTimeDays = NewstockItem.LeadTimeDays,
                    MarketingComments = NewstockItem.MarketingComments,
                    OuterPackageID = NewstockItem.OuterPackageID,
                    Photo = NewstockItem.Photo,
                    QuantityPerOuter = NewstockItem.QuantityPerOuter,
                    RecommendedRetailPrice = NewstockItem.RecommendedRetailPrice,
                    SearchDetails = NewstockItem.SearchDetails,
                    Size = NewstockItem.Size,
                    StockItemID = NewstockItem.StockItemID,
                    StockItemName = NewstockItem.StockItemName,
                    SupplierID = NewstockItem.SupplierID,
                    Tags = NewstockItem.Tags,
                    TaxRate = NewstockItem.TaxRate,
                    TypicalWeightPerUnit = NewstockItem.TypicalWeightPerUnit,
                    UnitPackageID = NewstockItem.UnitPackageID,
                    UnitPrice = NewstockItem.UnitPrice,
                    ValidFrom = NewstockItem.ValidFrom,
                    ValidTo = NewstockItem.ValidTo
                };

                return NewItem;
                }
            
            }
                
        

        [HttpPut]
        public AddUpdateItemResponse UpdatestockItem (StockItemDTO item)
        {
            try
            {
                using (WideWorldImportersEntities entities = new WideWorldImportersEntities())
                {
                    var originalItem = entities.StockItems.FirstOrDefault(s=>s.StockItemID==item.StockItemID);
   
                    originalItem.Barcode = item.Barcode;
                    originalItem.Brand = item.Brand;
                    originalItem.ColorID = item.ColorID;
                    originalItem.CustomFields = item.CustomFields;
                    originalItem.InternalComments = item.InternalComments;
                    originalItem.IsChillerStock = item.IsChillerStock;
                    originalItem.LastEditedBy = item.LastEditedBy;
                    originalItem.LeadTimeDays = item.LeadTimeDays;
                    originalItem.MarketingComments = item.MarketingComments;
                    originalItem.OuterPackageID = item.OuterPackageID;
                    originalItem.Photo = item.Photo;
                    originalItem.QuantityPerOuter = item.QuantityPerOuter;
                    originalItem.RecommendedRetailPrice = item.RecommendedRetailPrice;
                    originalItem.SearchDetails = item.SearchDetails;
                    originalItem.Size = item.Size;
                    originalItem.StockItemName = item.StockItemName;
                    originalItem.SupplierID = item.SupplierID;
                    originalItem.Tags = item.Tags;
                    originalItem.TaxRate = item.TaxRate;
                    originalItem.TypicalWeightPerUnit = item.TypicalWeightPerUnit;
                    originalItem.UnitPackageID = item.UnitPackageID;
                    originalItem.UnitPrice = item.UnitPrice;
                    originalItem.ValidFrom = item.ValidFrom;
                    originalItem.ValidTo = item.ValidTo;

                    //entities.Entry(originalItem).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();

                    return new AddUpdateItemResponse() {
                        ItemId=originalItem.StockItemID,
                        ErrorMessage="",
                        Success=true
                    };

                }
            }
            catch (Exception ex)
            {
                return new AddUpdateItemResponse()
                {
                    ItemId = item.StockItemID,
                    ErrorMessage = ex.ToString(),
                    Success = false
                };
            }
        }
    }
    }

