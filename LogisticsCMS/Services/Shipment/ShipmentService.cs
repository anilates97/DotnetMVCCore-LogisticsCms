using AutoMapper;
using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using MongoDB.Driver;
using System.Linq.Expressions;
using ShipmentModel = LogisticsCMS.Models.Shipment;

namespace LogisticsCMS.Services.Shipment
{
    public class ShipmentService
        : MongoCrudServiceBase<
            ShipmentModel,
            CreateShipmentDto,
            UpdateShipmentDto,
            ResultShipmentDto,
            GetShipmentByIdDto
        >,
            IShipmentService
    {
        public ShipmentService(
            DatabaseSettings databaseSettings,
            IMapper mapper,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.ShipmentCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<ShipmentModel, bool>> BuildIdFilter(string id) =>
            shipment => shipment.ShipmentId == id;

        protected override string GetEntityId(ShipmentModel entity) => entity.ShipmentId;

        public Task CreateShipmentAsync(CreateShipmentDto createShipmentDto) => CreateAsync(createShipmentDto);

        public Task DeleteShipmentAsync(string shipmentId) => DeleteAsync(shipmentId);

        public Task<List<ResultShipmentDto>> GetAllShipmentsAsync() => GetAllAsync();

        public async Task<long> GetDeliveredShipmentCountAsync()
        {
            var filter = Builders<ShipmentModel>.Filter.Eq(s => s.CurrentStatus, "Teslim Edildi");
            return await Collection.CountDocumentsAsync(filter);
        }

        public async Task<int> GetDistinctDestinationCityCountAsync()
        {
            var distinctCities = await Collection.DistinctAsync<string>(
                "DestinationCity",
                FilterDefinition<ShipmentModel>.Empty
            );
            return await distinctCities.ToListAsync().ContinueWith(t => t.Result.Count);
        }

        public async Task<long> GetInDistributionShipmentCountAsync()
        {
            var filter = Builders<ShipmentModel>.Filter.Eq(
                s => s.CurrentStatus,
                "Da\u011f\u0131t\u0131mda"
            );
            return await Collection.CountDocumentsAsync(filter);
        }

        public Task<GetShipmentByIdDto?> GetShipmentByIdAsync(string shipmentId) =>
            GetByIdAsync(shipmentId);

        public async Task<GetShipmentByIdDto?> GetShipmentByTrackingNumberAsync(string trackingNumber)
        {
            var value = await Collection.Find(b => b.TrackingNumber == trackingNumber).FirstOrDefaultAsync();
            return Mapper.Map<GetShipmentByIdDto>(value);
        }

        public async Task<long> GetTotalShipmentCountAsync()
        {
            return await Collection.CountDocumentsAsync(FilterDefinition<ShipmentModel>.Empty);
        }

        public Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto) => UpdateAsync(updateShipmentDto);
    }
}
