using App.Domain.Commands.Contracts;

namespace App.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(string message, bool success, object data)
        {
            Message = message;
            Success = success;
            Data = data;
        }
        public string Message { get;  set; }
        public bool Success { get; set; }
        public object Data { get; set; }

    }
}