using Core.Db.Entities;
using MyDiary.Services.Settings.Models;

namespace MyDiary.Services.Settings
{
    public interface ISettingService
    {
        Setting Get();
        Task<Setting> GetAsync();
        Task UpdateAsync(SettingModel model);
    }
}