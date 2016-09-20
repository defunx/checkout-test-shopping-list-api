using shopping_list_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shopping_list_api.Controllers
{
    [RoutePrefix("ShoppingList")]
    public class ShoppingListController : ApiController
    {
        static readonly IShoppingListRepository repository = new ShoppingListRepository();

        //GET api/ShoppingList
        [Route("")]
        public IEnumerable<ShoppingListItem> GetShoppingList(int pageNumber= 0 , int pageSize= 10)
        {
            return repository.GetAll(pageNumber, pageSize);
        }

        //GET ShoppingList/Pepsi
        [Route("{name}")]
        public ShoppingListItem GetItem(string name)
        {
            ShoppingListItem item = repository.Get(name);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        //POST ShoppingList
        [Route("", Name="PostItem")]
        public HttpResponseMessage PostItem(ShoppingListItem item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<ShoppingListItem>(HttpStatusCode.Created, item);

            string uri = Url.Link("PostItem", new { name = item.Name });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //PUT ShoppingList
        [Route("")]
        public void PutItem(ShoppingListItem item)
        {
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //DELETE ShoppingList/delete/Pepsi
        [Route("delete/{name}")]
        public void DeleteItem(string name)
        {
            repository.Remove(name);
        }
    }
}
