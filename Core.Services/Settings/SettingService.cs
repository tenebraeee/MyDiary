using Core.Db.Entities;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MyDiary.Services.Settings.Models;

namespace MyDiary.Services.Settings
{
    internal class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;


        public SettingService(
                IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Setting> GetAsync()
        {
            return await EnsureCreatedAsync();
        }

        public Setting Get()
        {
            return EnsureCreated();
        }

        public async Task UpdateAsync(SettingModel model)
        {
            var setting = await GetAsync();
            setting.Password = model.Password;
            
            await _unitOfWork.SaveChangesAsync();
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

        private Setting EnsureCreated()
        {
            var setting = GetFirst();

            if (setting != null)
            {
                return setting;
            }

            var @new = InitializeNew();

            return Create(@new);
        }

        private async Task<Setting?> GetFirstAsync()
        {
            var repository = _unitOfWork.Repository<Setting>();
            var query = repository.SingleResultQuery();

            return await repository.FirstOrDefaultAsync(query);
        }

        private Setting GetFirst()
        {
            var repository = _unitOfWork.Repository<Setting>();
            var query = repository.SingleResultQuery();

            return repository.FirstOrDefault(query);
        }

        private Setting InitializeNew()
        {
            return new Setting();
        }

        private async Task<Setting> CreateAsync(Setting setting)
        {
            var repository = _unitOfWork.Repository<Setting>();

            await repository.AddAsync(setting);
            await _unitOfWork.SaveChangesAsync();

            return setting;
        }

        private Setting Create(Setting setting)
        {
            var repository = _unitOfWork.Repository<Setting>();

            repository.Add(setting);
            _unitOfWork.SaveChanges();

            return setting;
        }
    }
}
