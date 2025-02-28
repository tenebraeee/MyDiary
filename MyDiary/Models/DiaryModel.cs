namespace MyDiary.Models
{
    internal class DiaryModel
    {
        public DateTime Date { get; set; }
        public string? Text { get; set; }
        public string? SaveButtonLabel { get; set; }

        public bool IsInit { get; set; }
    }
}
