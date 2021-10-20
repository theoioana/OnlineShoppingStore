﻿using OnlineShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace OnlineShoppingApp.Controllers.API
{
    public class ItemsController : ApiController
    {
        private ApplicationDbContext context;

        public ItemsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return context.Items.Include(m => m.Category).ToList();
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var item = context.Items.SingleOrDefault(i => i.Id == id);

            context.Items.Remove(item);
            context.SaveChanges();

            return Ok();
        }
    }
}
