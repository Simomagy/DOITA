namespace _04_Utility
{
    public interface IDAO
    {
        public List<Entity> GetRecords();
        public bool CreateRecord(Entity entity);
        public bool UpdateRecord(Entity entity);
        public bool DeleteRecord(int recordId);
        public Entity? FindRecord(int recordId);
    }
}
