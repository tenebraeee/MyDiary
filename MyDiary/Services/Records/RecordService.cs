using Microsoft.EntityFrameworkCore;
using MyDiary.Db;
using MyDiary.Db.Entities;
using MyDiary.Services.Records.Models;
using System.Net.Mime;

namespace MyDiary.Services.Records
{
    internal class RecordService : IRecordService
    {
        private readonly SqlContext _context;


        public RecordService(
                SqlContext context
            )
        {
            _context = context;
        }


        public async Task UpdateOrCreateAsync(RecordModel model)
        {
            var record = await _context.Set<Record>().FirstOrDefaultAsync(r => r.Date == model.Date);

            if (record == null)
            {
                var @new = new Record
                {
                    Text = model.Text,
                    Date = model.Date,
                };
                await _context.AddAsync(@new);
            }
            else
            {
                record.Text = model.Text;
            }

            await _context.SaveChangesAsync();
        }

        public void UpdateOrCreate(RecordModel model)
        {
            var task = UpdateOrCreateAsync(model);
            task.Wait();
        }

        public async Task<RecordModel?> GetAsync(DateOnly date)
        {
            var record = await _context.Set<Record>().FirstOrDefaultAsync(r => r.Date == date);

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
            var record = _context.Set<Record>().FirstOrDefault(r => r.Date == date);

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

        public async Task<ICollection<RecordModel>> GetAllAsync()
        {
            return await _context.Set<Record>().Select(r => new RecordModel
            {
                Date = r.Date,
                Text = r.Text,
            }).ToArrayAsync();
        }

        public ICollection<RecordModel> GetAll()
        {
            var task = GetAllAsync();
            task.Wait();

            return task.Result;
        }
    }
}
