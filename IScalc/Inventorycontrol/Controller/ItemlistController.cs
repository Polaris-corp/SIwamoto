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
        
        public DataTable SearchItems(string item , bool deleted)
        {
            return itemlistService.ResaultSearchItem(item, deleted);
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

        public List<string> GetItemName()
        {
            return itemlistService.GetItemName();
        }

        public int GetItemId(string name)
        {
            return itemlistService.GetItemId(name);
        }
    }
}
