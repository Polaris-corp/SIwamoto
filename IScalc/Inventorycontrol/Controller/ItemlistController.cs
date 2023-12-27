using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventorycontrol.Service;
using System.Data;
using Inventorycontrol.Model;

namespace Inventorycontrol.Controller
{
    public class ItemlistController
    {
        ItemlistService itemlistService = new ItemlistService();
        
        public DataTable SearchItems(ItemModel item)
        {
            return itemlistService.ResaultSearchItem(item);
        }

        public bool InsertItemInfo(ItemModel item)
        {
            return itemlistService.RegistrationItemInfo(item);
        }

        public bool UpdateItemInfo(ItemModel items)
        {
            return itemlistService.UpdateItemInfo(items);
        }
        public List<ItemModel> GetItemList()
        {
            return itemlistService.GetItemInfos();
        }
    }
}
