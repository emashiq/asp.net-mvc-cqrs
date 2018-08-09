using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface IBookRepositories
    {
        /// <summary>
        /// Add New Book
        /// </summary>
        /// <param name="book"></param>
        void AddBook(Book book);
        /// <summary>
        /// Edit Book
        /// </summary>
        /// <param name="id"></param>
        void EditBook(Book book);
        /// <summary>
        /// Get Book By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Book GetBookByID(object id); 
        /// <summary>
        /// Get All Books
        /// </summary>
        /// <returns></returns>
        List<Book> AllBooks();
        /// <summary>
        /// Remove Books By ID
        /// </summary>
        /// <param name="id"></param>
        void RemoveBook(object id);
    }
}
