using System;
using SPE.Domain.Core.Events;

namespace SPE.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime TimeStamp { get; private set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}