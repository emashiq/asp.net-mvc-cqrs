# ASP.NET MVC Application using CQRS Pattern - Command Query Responsibility Segregation

### Event Class For Performing Event
```
public class Event:EventArgs
{
     
}
```
### Query Class For Performing Query
```
public class Query
{
        public object Result;
}
```
### Query Class For Performing Command
```
public class Command:EventArgs
{
        public Guid Id { get; set; }
        public bool IsRegister { get; set; }
        public int Version { get; set; }
}
```
### Event Broker Class For Performing events
```
public class EventBroker
{
        //All Event That Happens
        public IList<Event> AllEvents = new List<Event>();
        //Commands
        public event EventHandler<Command> Commands;
        //Query
        public event EventHandler<Query> Queries;

        public void Execute(Command command) => Commands.Invoke(this, command);
        public T Query<T>(Query query)
        {
            Queries.Invoke(this, query);
            return (T)query.Result;
        }
}
```
### View Model Class
```
public class BookViewModel
{
        public Guid Id { get; set; }
        public string Name { get; set; }
     
}
```
### Simple Command and Query Demo
```
public class BookSaveCommand : Command
{
        public BookOperation BookOperation;
        public BookSaveCommand(BookViewModel book,BookOperation operation)
        {
            BookOperation = operation;
            BookOperation.Target.Name = book.Name;
        }
}
public class AllBooksQuery:Query
{
        public List<BookViewModel> AllBooks;
}
```
## Performing Operation using CQRS
```
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
```


### Performing ASP.NET MVC Controller
```
public class BooksController : Controller
{
        private EventBroker eventBroker;
        private BookOperation bookOperation;
        public BooksController()
        {
            eventBroker = new EventBroker();
            bookOperation = new BookOperation(eventBroker);
        }
        // GET: Books
        public ActionResult Index()
        {
            var bookList = eventBroker.Query<List<BookViewModel>>(new AllBooksQuery()).ToList();
            return View(bookList);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(BookViewModel book)
        {
            try
            {
                // TODO: Add insert logic here
                eventBroker.Execute(new BookSaveCommand(book,bookOperation));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
}
```
