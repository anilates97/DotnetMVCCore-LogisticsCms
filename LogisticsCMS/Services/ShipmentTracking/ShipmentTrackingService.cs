using AutoMapper;
using LogisticsCMS.Dtos.ShipmentTracking;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using MongoDB.Driver;
using ShipmentModel = LogisticsCMS.Models.Shipment;
using ShipmentTrackingModel = LogisticsCMS.Models.ShipmentTracking;

namespace LogisticsCMS.Services.ShipmentTracking
{
    public class ShipmentTrackingService : IShipmentTrackingService
    {
        private readonly IMongoCollection<ShipmentModel> _shipmentCollection;
        private readonly IMapper _mapper;

        public ShipmentTrackingService(
            DatabaseSettings databaseSettings,
            IMapper mapper,
            IMongoDbContext mongoDbContext
        )
        {
            _shipmentCollection = mongoDbContext.GetCollection<ShipmentModel>(
                databaseSettings.ShipmentCollectionName
            );
            _mapper = mapper;
        }

        public async Task CreateTrackingAsync(CreateShipmentTrackingDto createShipmentTrackingDto)
        {
            var tracking = _mapper.Map<ShipmentTrackingModel>(createShipmentTrackingDto);
            var filter = Builders<ShipmentModel>.Filter.Eq(
                s => s.TrackingNumber,
                createShipmentTrackingDto.TrackingNumber
            );
            var update = Builders<ShipmentModel>
                .Update.Push(s => s.Trackings, tracking)
                .Set(x => x.CurrentStatus, createShipmentTrackingDto.TrackingStatus);

            await _shipmentCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteTrackingAsync(string trackingNumber, int index)
        {
            var shipment = _shipmentCollection
                .Find(s => s.TrackingNumber == trackingNumber)
                .FirstOrDefault();

            if (
                shipment == null
                || shipment.Trackings == null
                || index < 0
                || index >= shipment.Trackings.Count
            )
            {
                return;
            }

            shipment.Trackings.RemoveAt(index);

            var filter = Builders<ShipmentModel>.Filter.Eq(s => s.TrackingNumber, trackingNumber);
            var update = Builders<ShipmentModel>.Update.Set(s => s.Trackings, shipment.Trackings);

            await _shipmentCollection.UpdateOneAsync(filter, update);
        }

        public async Task<List<ResultShipmentTrackingDto>> GetAllTrackingsAsync(string trackingNumber)
        {
            var shipment = _shipmentCollection
                .Find(s => s.TrackingNumber == trackingNumber)
                .FirstOrDefault();

            if (shipment == null || shipment.Trackings == null)
            {
                return new List<ResultShipmentTrackingDto>();
            }

            return _mapper.Map<List<ResultShipmentTrackingDto>>(shipment.Trackings);
        }

        public async Task<ResultShipmentTrackingDto> GetTrackingByIndexAsync(
            string trackingNumber,
            int index
        )
        {
            var shipment = _shipmentCollection
                .Find(s => s.TrackingNumber == trackingNumber)
                .FirstOrDefault();

            if (
                shipment == null
                || shipment.Trackings == null
                || index < 0
                || index >= shipment.Trackings.Count
            )
            {
                return null!;
            }

            return _mapper.Map<ResultShipmentTrackingDto>(shipment.Trackings[index]);
        }

        public async Task UpdateTrackingAsync(UpdateShipmentTrackingDto updateShipmentTrackingDto)
        {
            var filter = Builders<ShipmentModel>.Filter.Eq(
                x => x.TrackingNumber,
                updateShipmentTrackingDto.TrackingNumber
            );
            var update = Builders<ShipmentModel>
                .Update.Set(
                    x => x.Trackings[updateShipmentTrackingDto.TrackingIndex].EventDate,
                    updateShipmentTrackingDto.EventDate
                )
                .Set(
                    x => x.Trackings[updateShipmentTrackingDto.TrackingIndex].Location,
                    updateShipmentTrackingDto.Location
                )
                .Set(
                    x => x.Trackings[updateShipmentTrackingDto.TrackingIndex].Description,
                    updateShipmentTrackingDto.Description
                )
                .Set(
                    x => x.Trackings[updateShipmentTrackingDto.TrackingIndex].TrackingStatus,
                    updateShipmentTrackingDto.TrackingStatus
                )
                .Set(x => x.CurrentStatus, updateShipmentTrackingDto.TrackingStatus);

            await _shipmentCollection.UpdateOneAsync(filter, update);
        }
    }
}

