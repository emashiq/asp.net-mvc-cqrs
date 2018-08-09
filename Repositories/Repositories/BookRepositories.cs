using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class BookRepositories : IBookRepositories
    {
        public BookRepositories()
        {
        }
        /// <summary>
        /// Add New Book
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
           
            
        }


        /// <summary>
        /// List of Books
        /// </summary>
        /// <returns></returns>
        public List<Book> AllBooks() => new List<Book>()
        {
            new Book(){Id=Guid.NewGuid(),Name="Java",CreatedOn=DateTime.Now},
            new Book(){Id=Guid.NewGuid(),Name="C#",CreatedOn=DateTime.Now},
            new Book(){Id=Guid.NewGuid(),Name="C++",CreatedOn=DateTime.Now},
            new Book(){Id=Guid.NewGuid(),Name="Socrates",CreatedOn=DateTime.Now},
        };
        /// <summary>
        /// Edit Books
        /// </summary>
        /// <param name="book"></param>
        public void EditBook(Book book)
        {
           
        }



        /// <summary>
        /// Get Books By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book GetBookByID(object id)
        {
            return new Book();
        }
        /// <summary>
        /// Remove Book by ID
        /// </summary>
        /// <param name="id"></param>
        public void RemoveBook(object id)
        {
            var book = this.GetBookByID(id);
        }

        
    }
}
