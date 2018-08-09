using CQRS.CommandHandler;
using CQRS.QueryHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.EventHandler
{
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
}
