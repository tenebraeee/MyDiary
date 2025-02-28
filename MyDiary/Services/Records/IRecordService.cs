using MyDiary.Services.Records.Models;

namespace MyDiary.Services.Records
{
    public interface IRecordService
    {
        void UpdateOrCreate(RecordModel model);
        Task UpdateOrCreateAsync(RecordModel model);
        RecordModel? Get(DateOnly date);
        Task<RecordModel?> GetAsync(DateOnly date);
        Task<ICollection<RecordModel>> GetAllAsync();
        ICollection<RecordModel> GetAll();
    }
}