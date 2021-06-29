using System;

namespace TesteFullBar.Domain.Models.Notifications
{
    public class NotificationMessage
    {
        public NotificationMessage(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
        }

        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
