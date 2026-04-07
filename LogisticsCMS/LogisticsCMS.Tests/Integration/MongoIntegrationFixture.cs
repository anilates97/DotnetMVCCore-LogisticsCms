using AutoMapper;
using LogisticsCMS.Mapping;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using Microsoft.Extensions.Logging.Abstractions;
using Mongo2Go;
using MongoDB.Driver;

namespace LogisticsCMS.Tests.Integration;

public sealed class MongoIntegrationFixture : IDisposable
{
    private readonly MongoDbRunner _runner;
    private readonly IMapper _mapper;

    public MongoIntegrationFixture()
    {
        var solutionRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
        var binariesDirectory = Path.Combine(
            solutionRoot,
            ".dotnet",
            ".nuget",
            "packages",
            "mongo2go",
            "4.1.0",
            "tools",
            "mongodb-windows-4.4.4-database-tools-100.3.1",
            "bin"
        );
        var dataDirectory = Path.Combine(solutionRoot, ".dotnet", "mongo2go-data", Guid.NewGuid().ToString("N"));

        Directory.CreateDirectory(dataDirectory);
        _runner = MongoDbRunner.Start(
            dataDirectory: dataDirectory,
            binariesSearchDirectory: binariesDirectory
        );

        var mapperConfiguration = new MapperConfiguration(
            cfg => cfg.AddProfile<GeneralMapping>(),
            NullLoggerFactory.Instance
        );
        _mapper = mapperConfiguration.CreateMapper();
    }

    public (DatabaseSettings settings, IMongoDbContext context, IMapper mapper) CreateScope()
    {
        var databaseSettings = new DatabaseSettings
        {
            ConnectionString = _runner.ConnectionString,
            DatabaseName = $"logisticscms-tests-{Guid.NewGuid():N}",
            ShipmentCollectionName = "Shipments",
            AboutCollectionName = "Abouts",
            BrandCollectionName = "Brands",
            GetInTouchSectionCollectionName = "GetInTouchSections",
            HowItWorkCollectionName = "HowItWorks",
            OfferCollectionName = "Offers",
            ProjectSectionCollectionName = "ProjectSections",
            QuestionCollectionName = "Questions",
            SliderCollectionName = "Sliders",
            TestimonialCollectionName = "Testimonials",
        };

        var mongoClient = new MongoClient(databaseSettings.ConnectionString);
        var context = new MongoDbContext(mongoClient, databaseSettings);

        return (databaseSettings, context, _mapper);
    }

    public void Dispose()
    {
        _runner.Dispose();
    }
}
