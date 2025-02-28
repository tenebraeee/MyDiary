using MyDiary.Models;
using MyDiary.Services.Settings;
using MyDiary.Services.Settings.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyDiary.ViewModels
{
    internal class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly SettingsModel _model;
        public ICommand SaveCommand { get; set; }

        private readonly ISettingService _settingService;


        public SettingsViewModel(
                ISettingService settingService
            )
        {
            _settingService = settingService;

            var setting = _settingService.Get();

            _model = new SettingsModel
            {
                Password = setting.Password,
            };

            SaveCommand = new Command(async () =>
            {
                await _settingService.UpdateAsync(new SettingModel
                {
                    Password = Password,
                });
            });
        }


        public string? Password 
        {
            get
            {
                return _model.Password;
            }
            set
            {
                _model.Password = value;
                OnPropertyChanged();
            }
        }


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            
        }
    }
}
