using Core.Db.Entities.Abstractions;

namespace Core.Db.Entities
{
    public class Record : BaseDataType
    {
        public string? Text { get; set; }

        public DateOnly Date { get; set; }
    }
}
