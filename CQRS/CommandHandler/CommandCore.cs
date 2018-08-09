using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.CommandHandler
{
    public class Command:EventArgs
    {
        public Guid Id { get; set; }
        public bool IsRegister { get; set; }
        public int Version { get; set; }
    }
}
