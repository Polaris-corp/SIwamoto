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
        
        public DataTable SearchItems(string item)
        {
            return itemlistService.ResaultSearchItem(item);
        }

        public DataTable SearchDeletedItems(string item)
        {
            return itemlistService.ResaultSearchDeletedItem(item);
        }

        public void InsertItemInfo(string name)
        {
            itemlistService.RegistrationItemInfo(name);
        }

        public void UpdateItemInfo(ItemInfoModel items)
        {
            itemlistService.UpdateItemInfo(items);
        }

        public void DeleteItemInfo(ItemInfoModel items)
        {
            itemlistService.DeleteItemInfo(items);
        }
    }
}
