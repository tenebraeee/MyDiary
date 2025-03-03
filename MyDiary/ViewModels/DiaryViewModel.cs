using MyDiary.Models;
using MyDiary.Services.Records;
using MyDiary.Services.Records.Models;
using Plugin.Maui.Calendar.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyDiary.ViewModels
{
    internal class DiaryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand SaveCommand { get; set; }

        private readonly DiaryModel diary;

        private readonly IRecordService _service;
        public EventCollection Events { get; set; }


        public DiaryViewModel(IRecordService service)
        {
            _service = service;

            SaveCommand = new Command(() => 
            {
                var date = Date;
                var text = Text;

                SaveButtonLabel = "Сохранить";

                _service.UpdateOrCreate(new RecordModel
                {
                    Date = DateOnly.FromDateTime(date),
                    Text = text,
                });
            });


            var today = DateTime.Today;

            diary = new DiaryModel
            {
                Date = today,
                SaveButtonLabel = "Сохранить",
                IsInit = true,
            };

            var recordModel = _service.Get(DateOnly.FromDateTime(today));
            diary.Text = recordModel?.Text;

            var all = _service.GetAll();

            Events = new EventCollection(all.Count);
            foreach (var item in all)
            {
                Events.Add(item.Date.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.Zero)), Array.Empty<object>());
            }
        }


        public DateTime Date
        {
            get => diary.Date;
            set
            {
                diary.Date = value;
                OnPropertyChanged();
            }
        }

        public string? Text
        {
            get => diary.Text;
            set
            {
                diary.Text = value;
                if (!diary.IsInit)
                {
                    IsSaved = false;
                    SaveButtonLabel = "Сохранить*";
                }
                else
                {
                    diary.IsInit = false;
                }
                OnPropertyChanged();
            }
        }

        public string? SaveButtonLabel
        {
            get => diary.SaveButtonLabel;
            set
            {
                IsSaved = true;
                diary.SaveButtonLabel = value;
                OnPropertyChanged();
            }
        }

        private bool _isSaved = true;
        public bool IsSaved
        {
            get {  return _isSaved; }
            set { _isSaved = value; OnPropertyChanged(); }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

            if (prop == nameof(Date))
            {
                var recordModel = _service.Get(DateOnly.FromDateTime(Date));
                Text = recordModel?.Text;
            }
        }
    }
}
