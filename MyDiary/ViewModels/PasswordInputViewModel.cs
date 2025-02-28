using MyDiary.Models;
using MyDiary.Services.Settings;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyDiary.ViewModels
{
    public class PasswordInputViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly PasswordInputModel model;

        public ICommand PasswordCheckCommand { get; set; }


        public PasswordInputViewModel(ISettingService settingService, Action action)
        {
            model = new PasswordInputModel();

            PasswordCheckCommand = new Command(() =>
            {
                var setting = settingService.Get();
                if (setting.Password == Password)
                {
                    action();
                    Password = null;
                }
            });

        }

        public string? Password 
        {
            get
            {
                return model.Password;
            }
            set
            {
                model.Password = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
