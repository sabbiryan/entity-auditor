namespace Client.MatchTables
{
    public class MatchItem
    {
        public MatchItem(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }

        public string Message { get; set; }
    }
}