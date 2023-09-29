namespace AjudanteDBA.Models
{
    public class SqlEvent
    {
        public int Number { get; set; }
        public string Message { get; set; }

        public SqlEvent() { }

        public SqlEvent(int number, string message)
        {
            Number = number;
            Message = message;
        }
    }
}