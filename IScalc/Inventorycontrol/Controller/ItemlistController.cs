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

        public void InsertItemInfo(string name,int count)
        {
            itemlistService.RegistrationItemInfo(name, count);
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
