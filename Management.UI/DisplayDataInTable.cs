using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Management.Models;
using Management.Commons;
using Management.BusinessLogic;
using Management.Data;

namespace Management.UI
{
    public class DataDisplayInTable
    {
        public static void DisplayDataTable(List<Store> stores)
        {
            DisplayTable.PrintLine();
            DisplayTable.PrintRow("Store Name", "Store Number", "Store Type", "Products", "UserId");
            DisplayTable.PrintLine();

            foreach (var store in stores)
            {
                DisplayTable.PrintRow(store.StoreName, store.StoreNumber, store.StoreType, store.Products.ToString(), store.UserId.ToString());
                DisplayTable.PrintLine();
            }
        }
    }
}