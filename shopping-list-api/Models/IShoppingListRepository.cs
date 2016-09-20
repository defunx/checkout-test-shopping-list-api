using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_list_api.Models
{
    interface IShoppingListRepository
    {
        IEnumerable<ShoppingListItem> GetAll(int pageNumber, int pageSize);
        ShoppingListItem Get(string id);
        ShoppingListItem Add(ShoppingListItem item);
        void Remove(string id);
        bool Update(ShoppingListItem item);
    }
}
