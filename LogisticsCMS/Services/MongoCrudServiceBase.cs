using AutoMapper;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace LogisticsCMS.Services
{
    public abstract class MongoCrudServiceBase<TEntity, TCreateDto, TUpdateDto, TResultDto, TGetByIdDto>
        where TEntity : class
    {
        protected IMongoCollection<TEntity> Collection { get; }
        protected IMapper Mapper { get; }

        protected MongoCrudServiceBase(
            string collectionName,
            IMapper mapper,
            IMongoDbContext mongoDbContext
        )
        {
            Collection = mongoDbContext.GetCollection<TEntity>(collectionName);
            Mapper = mapper;
        }

        protected abstract Expression<Func<TEntity, bool>> BuildIdFilter(string id);
        protected abstract string GetEntityId(TEntity entity);

        public async Task<List<TResultDto>> GetAllAsync()
        {
            var entities = await Collection.Find(_ => true).ToListAsync();
            return Mapper.Map<List<TResultDto>>(entities);
        }

        public async Task CreateAsync(TCreateDto createDto)
        {
            var entity = Mapper.Map<TEntity>(createDto);
            await Collection.InsertOneAsync(entity);
        }

        public async Task<TGetByIdDto?> GetByIdAsync(string id)
        {
            var entity = await Collection.Find(BuildIdFilter(id)).FirstOrDefaultAsync();
            return Mapper.Map<TGetByIdDto>(entity);
        }

        public async Task UpdateAsync(TUpdateDto updateDto)
        {
            var entity = Mapper.Map<TEntity>(updateDto);
            await Collection.ReplaceOneAsync(BuildIdFilter(GetEntityId(entity)), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await Collection.DeleteOneAsync(BuildIdFilter(id));
        }
    }
}
