using CQRS.CommandHandler;
using CQRS.EventHandler;
using CQRS.QueryHandler;
using CQRS.ViewModels;
using Repositories.Models;
using Repositories.Repositories;
using System;
using System.Linq;

namespace CQRS.Operation
{
    public class BookOperation
    {
        public Book Target { get; set; }
        private EventBroker Broker;
        private BookRepositories _bookRepositories = new BookRepositories();
        public BookOperation(EventBroker broker)
        {
            Broker = broker;
            Target = new Book();
            Broker.Commands += SaveBook;
            Broker.Queries += GetAllBooksQuery;
        }

        private void GetAllBooksQuery(object sender, QueryHandler.Query e)
        {
            var Q = e as AllBooksQuery;
            if (Q != null)
            {
                Q.Result = _bookRepositories.AllBooks().Select(x => new BookViewModel { Id = x.Id, Name = x.Name }).ToList();
            }
        }

        private void SaveBook(object sender, Command command)
        {
            var bookCommand = command as BookSaveCommand;
            if (bookCommand != null && bookCommand.BookOperation == this)
            {
                Target.CreatedOn = DateTime.UtcNow;
                Target.Id = Guid.NewGuid();
                _bookRepositories.AddBook(Target);
            }
        }
    }
}
