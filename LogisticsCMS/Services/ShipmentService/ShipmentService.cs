namespace LogisticsCMS.Services.ShipmentService
{
    using AutoMapper;
    using MongoDB.Driver;
    using LogisticsCMS.Dtos.ShipmentDto;
    using LogisticsCMS.Models;
    using LogisticsCMS.Settings;

    public class ShipmentService : IShipmentService
    {
        private readonly IMongoCollection<Shipment> _ShipmentCollection;
        private readonly IMapper _mapper;

        public ShipmentService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ShipmentCollection = database.GetCollection<Shipment>(
                _databaseSettings.ShipmentCollectionName
            );
            _mapper = mapper;
        }

        public async Task CreateShipmentAsync(CreateShipmentDto createShipmentDto)
        {
            var value = _mapper.Map<Shipment>(createShipmentDto);
            await _ShipmentCollection.InsertOneAsync(value);
        }

        public async Task DeleteShipmentAsync(string ShipmentId)
        {
            await _ShipmentCollection.DeleteOneAsync(b => b.ShipmentId == ShipmentId);
        }

        public async Task<List<ResultShipmentDto>> GetAllShipmentsAsync()
        {
            var Shipments = await _ShipmentCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultShipmentDto>>(Shipments);
        }

        public async Task<GetShipmentByIdDto> GetShipmentByIdAsync(string ShipmentId)
        {
            var Shipment = await _ShipmentCollection
                .Find(b => b.ShipmentId == ShipmentId)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetShipmentByIdDto>(Shipment);
        }

        public async Task<GetShipmentByIdDto> GetShipmentByTrackingNumberAsync(
            string trackingNumber
        )
        {
            var value = await _ShipmentCollection
                .Find(b => b.TrackingNumber == trackingNumber)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetShipmentByIdDto>(value);
        }

        public async Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto)
        {
            var Shipment = _mapper.Map<Shipment>(updateShipmentDto);
            await _ShipmentCollection.ReplaceOneAsync(
                b => b.ShipmentId == Shipment.ShipmentId,
                Shipment
            );
        }
    }
}

