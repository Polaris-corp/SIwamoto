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
        
        public DataTable SearchItems(ItemInfoModel item)
        {
            return itemlistService.ResaultSearchItem(item);
        }

        public bool InsertItemInfo(ItemInfoModel item)
        {
            return itemlistService.RegistrationItemInfo(item);
        }

        public bool UpdateItemInfo(ItemInfoModel items)
        {
            return itemlistService.UpdateItemInfo(items);
        }
        public List<ItemInfoModel> GetItemList()
        {
            return itemlistService.GetItemInfos();
        }
    }
}
