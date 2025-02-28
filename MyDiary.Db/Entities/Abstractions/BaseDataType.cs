namespace MyDiary.Db.Entities.Abstractions
{
    public class BaseDataType
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
