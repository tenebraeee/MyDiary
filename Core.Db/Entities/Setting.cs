using Core.Db.Entities.Abstractions;

namespace Core.Db.Entities
{
    public class Setting : BaseDataType
    {
        public string? Password { get; set; }

        public bool IsPasswordDefined => !string.IsNullOrWhiteSpace(Password);
    }
}
