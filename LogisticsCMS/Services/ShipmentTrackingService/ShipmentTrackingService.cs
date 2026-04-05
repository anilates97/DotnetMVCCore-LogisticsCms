using AutoMapper;
using MongoDB.Driver;
using LogisticsCMS.Dtos.ShipmentTrackingDto;
using LogisticsCMS.Models;
using LogisticsCMS.Services.ShipmentTrackingService;
using LogisticsCMS.Settings;

public class ShipmentTrackingService : IShipmentTrackingService
{
    private readonly IMongoCollection<Shipment> _shipmentCollection;
    private readonly IMapper _mapper;

    public ShipmentTrackingService(IDatabaseSettings databaseSettings, IMapper mapper)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _shipmentCollection = database.GetCollection<Shipment>("Shipments");
        _mapper = mapper;
    }

    public async Task CreateTrackingAsync(CreateShipmentTrackingDto createShipmentTrackingDto)
    {
        var tracking = _mapper.Map<ShipmentTracking>(createShipmentTrackingDto); // CreateShipmentTrackingDto'yu ShipmentTracking modeline dÃ¶nÃ¼ÅŸtÃ¼r
        var filter = Builders<Shipment>.Filter.Eq(
            s => s.TrackingNumber,
            createShipmentTrackingDto.TrackingNumber
        ); // Belirli bir takip numarasÄ±na sahip gÃ¶nderiyi bulmak iÃ§in filtre oluÅŸtur
        var update = Builders<Shipment>
            .Update.Push(s => s.Trackings, tracking)
            .Set(x => x.CurrentStatus, createShipmentTrackingDto.TrackingStatus); // Yeni takip bilgisini gÃ¶nderinin Trackings listesine ekle ve CurrentStatus'u gÃ¼ncelle
        await _shipmentCollection.UpdateOneAsync(filter, update); // MongoDB koleksiyonunda gÃ¼ncelleme iÅŸlemini gerÃ§ekleÅŸtir
    }

    public async Task DeleteTrackingAsync(string trackingNumber, int index)
    {
        var shipment = _shipmentCollection
            .Find(s => s.TrackingNumber == trackingNumber)
            .FirstOrDefault(); // Belirli bir takip numarasÄ±na sahip gÃ¶nderiyi bul
        if (
            shipment == null
            || shipment.Trackings == null
            || index < 0
            || index >= shipment.Trackings.Count
        )
        {
            return; // GÃ¶nderi bulunamazsa, takip bilgisi yoksa veya geÃ§ersiz bir indeks saÄŸlanÄ±rsa iÅŸlemi sonlandÄ±r
        }
        shipment.Trackings.RemoveAt(index); // Belirtilen indeksdeki takip bilgisini sil

        var filter = Builders<Shipment>.Filter.Eq(s => s.TrackingNumber, trackingNumber);
        var update = Builders<Shipment>.Update.Set(s => s.Trackings, shipment.Trackings); // Belirtilen indeksdeki takip bilgisini sil
        await _shipmentCollection.UpdateOneAsync(filter, update); // MongoDB koleksiyonunda gÃ¼ncelleme iÅŸlemini gerÃ§ekleÅŸtir
    }

    public async Task<List<ResultShipmentTrackingDto>> GetAllTrackingsAsync(string trackingNumber)
    {
        var shipment = _shipmentCollection
            .Find(s => s.TrackingNumber == trackingNumber)
            .FirstOrDefault(); // Belirli bir takip numarasÄ±na sahip gÃ¶nderiyi bul
        if (shipment == null || shipment.Trackings == null)
        {
            return new List<ResultShipmentTrackingDto>(); // GÃ¶nderi bulunamazsa veya takip bilgisi yoksa boÅŸ bir liste dÃ¶ndÃ¼r
        }
        var trackings = _mapper.Map<List<ResultShipmentTrackingDto>>(shipment.Trackings);
        return trackings; // GÃ¶nderinin Trackings listesini ResultShipmentTrackingDto listesine dÃ¶nÃ¼ÅŸtÃ¼r ve dÃ¶ndÃ¼r
    }

    public async Task<ResultShipmentTrackingDto> GetTrackingByIndexAsync(
        string trackingNumber,
        int index
    )
    {
        var shipment = _shipmentCollection
            .Find(s => s.TrackingNumber == trackingNumber)
            .FirstOrDefault(); // Belirli bir takip numarasÄ±na sahip gÃ¶nderiyi bul
        if (
            shipment == null
            || shipment.Trackings == null
            || index < 0
            || index >= shipment.Trackings.Count
        )
        {
            return null!; // GÃ¶nderi bulunamazsa, takip bilgisi yoksa veya geÃ§ersiz bir indeks saÄŸlanÄ±rsa null dÃ¶ndÃ¼r
        }
        var tracking = _mapper.Map<ResultShipmentTrackingDto>(shipment.Trackings[index]);
        return tracking; // Belirtilen indeksdeki takip bilgisini ResultShipmentTrackingDto'ya dÃ¶nÃ¼ÅŸtÃ¼r ve dÃ¶ndÃ¼r
    }

    public async Task UpdateTrackingAsync(UpdateShipmentTrackingDto updateShipmentTrackingDto)
    {
        var filter = Builders<Shipment>.Filter.Eq(
            x => x.TrackingNumber,
            updateShipmentTrackingDto.TrackingNumber
        ); // Belirli bir takip numarasÄ±na sahip gÃ¶nderiyi bulmak iÃ§in filtre oluÅŸtur
        var update = Builders<Shipment>
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
            .Set(x => x.CurrentStatus, updateShipmentTrackingDto.TrackingStatus); // Belirtilen indeksdeki takip bilgisini gÃ¼ncelle ve CurrentStatus'u da gÃ¼ncelle
        await _shipmentCollection.UpdateOneAsync(filter, update); // MongoDB koleksiyonunda gÃ¼ncelleme iÅŸlemini gerÃ§ekleÅŸtir
    }
}

