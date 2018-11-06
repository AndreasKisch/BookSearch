﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookSearch.Models;


namespace BookSearch
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookServices
    {
        Book AddBook(Book b);
        Dictionary<string, Book> GetBookList();
        void FillDictionary(XDocument doc);

    }
}