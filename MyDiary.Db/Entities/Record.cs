using MyDiary.Db.Entities.Abstractions;

namespace MyDiary.Db.Entities
{
    public class Record : BaseDataType
    {
        public string? Text { get; set; }

        public DateOnly Date { get; set; }
    }
}
