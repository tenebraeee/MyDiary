using MyDiary.Db.Entities.Abstractions;

namespace MyDiary.Db.Entities
{
    public class Setting : BaseDataType
    {
        public string? Password { get; set; }
    }
}
