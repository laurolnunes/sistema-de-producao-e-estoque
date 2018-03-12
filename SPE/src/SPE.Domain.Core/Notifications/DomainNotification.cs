using SPE.Domain.Core.Events;

namespace SPE.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public int Id { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            Version = 1;
        }
    }
}