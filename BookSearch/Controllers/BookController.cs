using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookSearch.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookServices _services;

        public BookController(IBookServices services)
        {
            _services = services;
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            var bookList = _services.GetBookList();

            if (bookList == null)
            {
                return NotFound();
            }

            return bookList.Values.ToList();
        }

        [Route("Post")]
        [HttpPost]
        public ActionResult<List<Book>> Post(Book b)
        {
            var bookList = _services.AddBook(b);

            if (bookList == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }




}