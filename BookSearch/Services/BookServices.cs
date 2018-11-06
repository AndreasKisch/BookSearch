﻿using BookSearch.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BookSearch
{
    /// <summary>
    /// 
    /// </summary>
    public class BookServices : IBookServices
    {
        private readonly Dictionary<string, Models.Book> _bookList;
        XDocument doc;
        /// <summary>
        /// Opens link to Xml file and adds content to a dictionary
        /// </summary>
        public BookServices()
        {
            _bookList = new Dictionary<string, Models.Book>();
            doc = XDocument.Load(Environment.CurrentDirectory + "\\Data\\books.xml");

            FillDictionary(doc);
        }

        /// <summary>
        /// Allows user to create and add new objects
        /// </summary>
        /// <param name="b">object that wish to be added</param>
        /// <returns></returns>
        public Book AddBook(Book b)
        {
            _bookList.Add(b.Title, b);

            return b;
        }

        /// <summary>
        /// Sends back content from Xml
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Book> GetBookList()
        {
            return _bookList;
        }

        public void FillDictionary(XDocument doc)
        {
            foreach (XElement item in GetXmlElement())
            {
                Book b = new Book();


                b.Author = item.Element("author").Value;
                b.Genre = item.Element("genre").Value;
                b.Title = item.Element("title").Value;
                b.Price = decimal.Parse(item.Element("price").Value, CultureInfo.InvariantCulture);
                b.PublishDate = DateTime.Parse(item.Element("publish_date").Value);
                b.Description = item.Element("description").Value;

                AddBook(b);
            }
        }

        private IEnumerable<XElement> GetXmlElement()
        {
            return doc.Root.Elements();
        }
    }
}
