using CQRS.CommandHandler;
using CQRS.EventHandler;
using CQRS.Operation;
using CQRS.QueryHandler;
using CQRS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CQRS_MVC_APP.Controllers
{
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

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
