using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_list_api.Models
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private List<ShoppingListItem> shoppingList = new List<ShoppingListItem>();

        public IEnumerable<ShoppingListItem> GetAll(int pageNumber, int pageSize)
        {
            var totalCount = shoppingList.Count();

            return shoppingList.Skip(pageSize * pageNumber).Take(pageSize);
        }

        public ShoppingListItem Get(string name)
        {
            return shoppingList.Find(i => i.Name == name);
        }

        public ShoppingListItem Add(ShoppingListItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("shopping list item");
            }

            int index = shoppingList.FindIndex(i => i.Name == item.Name);
            if (index != -1)
            {
                throw new Exception("an item with the same name is already in the list");
            }

            shoppingList.Add(item);
            return item;
        }

        public void Remove(string name)
        {
            shoppingList.RemoveAll(i => i.Name == name);
        }

        public bool Update(ShoppingListItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item can not be null");
            }
            int index = shoppingList.FindIndex(p => p.Name == item.Name);
            if (index == -1)
            {
                return false;
            }
            shoppingList.RemoveAt(index);
            shoppingList.Add(item);
            return true;
        }
    }
}