using CQRS.Operation;
using CQRS.ViewModels;

namespace CQRS.CommandHandler
{
    public class BookSaveCommand : Command
    {
        public BookOperation BookOperation;
        public BookSaveCommand(BookViewModel book,BookOperation operation)
        {
            BookOperation = operation;
            BookOperation.Target.Name = book.Name;
        }
    }
}
