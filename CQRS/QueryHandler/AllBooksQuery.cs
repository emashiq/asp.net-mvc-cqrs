using CQRS.ViewModels;
using System.Collections.Generic;

namespace CQRS.QueryHandler
{
    public class AllBooksQuery:Query
    {
        public List<BookViewModel> AllBooks;
    }
}
