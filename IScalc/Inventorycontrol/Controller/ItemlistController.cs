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

        public void InsertItemInfo(ItemInfoModel item)
        {
            itemlistService.RegistrationItemInfo(item);
        }

        public void UpdateItemInfo(ItemInfoModel items)
        {
            itemlistService.UpdateItemInfo(items);
        }

        public void DeleteItemInfo(ItemInfoModel items)
        {
            itemlistService.DeleteItemInfo(items);
        }

        public List<string> GetItemName()
        {
            return itemlistService.GetItemName();
        }

        public int GetItemId(ItemInfoModel item)
        {
            return itemlistService.GetItemId(item);
        }

        public List<ItemInfoModel> GetItemList()
        {
            return itemlistService.GetItemInfos();
        }
    }
}
