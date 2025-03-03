using EntityFrameworkCore.UnitOfWork.Interfaces;
using MyDiary.Db.Entities;
using MyDiary.Services.Records.Models;

namespace MyDiary.Services.Records
{
    internal class RecordService : IRecordService
    {
        private readonly IUnitOfWork _unitOfWork;


        public RecordService(
                IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }


        public async Task UpdateOrCreateAsync(RecordModel model)
        {
            var repository = _unitOfWork.Repository<Record>();

            var record = await GetByDateAsync(model.Date);

            if (record == null)
            {
                var @new = new Record
                {
                    Text = model.Text,
                    Date = model.Date,
                };
                await repository.AddAsync(@new);
            }
            else
            {
                record.Text = model.Text;
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public void UpdateOrCreate(RecordModel model)
        {
            var task = UpdateOrCreateAsync(model);
            task.Wait();
        }

        public async Task<RecordModel?> GetAsync(DateOnly date)
        {
            var record = await GetByDateAsync(date);

            if (record == null)
            {
                return null;
            }

            return new RecordModel
            {
                Date = record.Date,
                Text = record.Text,
            };
        }

        public RecordModel? Get(DateOnly date)
        {
            var task = GetAsync(date);
            task.Wait();

            return task.Result;
        }

        public ICollection<RecordModel> GetAll()
        {
            var repository = _unitOfWork.Repository<Record>();
            var query = repository.MultipleResultQuery()
                .Select(r => new RecordModel
                {
                    Date = r.Date,
                    Text = r.Text,
                });
            var items = repository.Search(query);

            return items;
        }


        private async Task<Record> GetByDateAsync(DateOnly date)
        {
            var repository = _unitOfWork.Repository<Record>();
            var query = repository.SingleResultQuery()
                .AndFilter(r => r.Date == date);

            return await repository.FirstOrDefaultAsync(query);
        }
    }
}
