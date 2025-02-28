using Microsoft.EntityFrameworkCore;
using MyDiary.Db;
using MyDiary.Db.Entities;
using MyDiary.Services.Settings.Models;

namespace MyDiary.Services.Settings
{
    internal class SettingService : ISettingService
    {
        private readonly SqlContext _context;


        public SettingService(
                SqlContext context
            )
        {
            _context = context;
        }


        public async Task<Setting> GetAsync()
        {
            return await EnsureCreatedAsync();
        }

        public Setting Get()
        {
            var task = GetAsync();
            task.Wait();

            return task.Result;
        }

        public async Task UpdateAsync(SettingModel model)
        {
            var setting = await GetAsync();
            setting.Password = model.Password;
            
            await _context.SaveChangesAsync();
        }


        private async Task<Setting> EnsureCreatedAsync()
        {
            var setting = await GetFirstAsync();

            if (setting != null)
            {
                return setting;
            }

            var @new = InitializeNew();

            return await CreateAsync(@new);
        }

        private async Task<Setting?> GetFirstAsync()
        {
            return await _context.Set<Setting>().FirstOrDefaultAsync();
        }

        private Setting InitializeNew()
        {
            return new Setting();
        }

        private async Task<Setting> CreateAsync(Setting setting)
        {
            await _context.AddAsync(setting);
            await _context.SaveChangesAsync();

            return setting;
        }
    }
}
