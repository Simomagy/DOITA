namespace _04_Utility
{
    public interface IDatabase
    {
        public List<Dictionary<string, string>>? ReadDb(string query);
        public bool UpdateDb(string query);
        public Dictionary<string, string>? ReadOneDb(string query);
    }
}
