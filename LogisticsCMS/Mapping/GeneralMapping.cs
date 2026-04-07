namespace LogisticsCMS.Mapping
{
    using AutoMapper;
    using LogisticsCMS.Dtos.About;
    using LogisticsCMS.Dtos.Brand;
    using LogisticsCMS.Dtos.GetInTouchSection;
    using LogisticsCMS.Dtos.HowItWork;
    using LogisticsCMS.Dtos.Offer;
    using LogisticsCMS.Dtos.ProjectSection;
    using LogisticsCMS.Dtos.Question;
    using LogisticsCMS.Dtos.Shipment;
    using LogisticsCMS.Dtos.ShipmentTracking;
    using LogisticsCMS.Dtos.Slider;
    using LogisticsCMS.Dtos.Testimonial;
    using LogisticsCMS.Models;

    public class GeneralMapping : Profile // AutoMapper profili oluşturarak, model ve DTO'lar arasında dönüşümleri tanımlıyoruz
    {
        public GeneralMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap(); // Slider modelini ResultSliderDto'ya ve tam tersine dönüştürmek için bir eşleme tanımlıyoruz
            CreateMap<CreateSliderDto, Slider>().ReverseMap();
            CreateMap<UpdateSliderDto, Slider>().ReverseMap();
            CreateMap<GetSliderByIdDto, Slider>().ReverseMap();
            CreateMap<GetSliderByIdDto, UpdateSliderDto>();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<CreateBrandDto, Brand>().ReverseMap();
            CreateMap<UpdateBrandDto, Brand>().ReverseMap();
            CreateMap<GetBrandByIdDto, Brand>().ReverseMap();
            CreateMap<GetBrandByIdDto, UpdateBrandDto>();

            CreateMap<Offer, ResultOfferDto>().ReverseMap();
            CreateMap<CreateOfferDto, Offer>().ReverseMap();
            CreateMap<UpdateOfferDto, Offer>().ReverseMap();
            CreateMap<GetOfferByIdDto, Offer>().ReverseMap();
            CreateMap<GetOfferByIdDto, UpdateOfferDto>();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<GetAboutByIdDto, About>().ReverseMap();
            CreateMap<GetAboutByIdDto, UpdateAboutDto>();

            CreateMap<GetInTouchSection, ResultGetInTouchSectionDto>().ReverseMap();
            CreateMap<CreateGetInTouchSectionDto, GetInTouchSection>().ReverseMap();
            CreateMap<UpdateGetInTouchSectionDto, GetInTouchSection>().ReverseMap();
            CreateMap<GetInTouchSectionByIdDto, GetInTouchSection>().ReverseMap();
            CreateMap<GetInTouchSectionByIdDto, UpdateGetInTouchSectionDto>();

            CreateMap<HowItWork, ResultHowItWorkDto>().ReverseMap();
            CreateMap<CreateHowItWorkDto, HowItWork>().ReverseMap();
            CreateMap<UpdateHowItWorkDto, HowItWork>().ReverseMap();
            CreateMap<GetHowItWorkByIdDto, HowItWork>().ReverseMap();
            CreateMap<GetHowItWorkByIdDto, UpdateHowItWorkDto>();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialByIdDto, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialByIdDto, UpdateTestimonialDto>();

            CreateMap<ProjectSection, ResultProjectSectionDto>().ReverseMap();
            CreateMap<CreateProjectSectionDto, ProjectSection>().ReverseMap();
            CreateMap<UpdateProjectSectionDto, ProjectSection>().ReverseMap();
            CreateMap<GetProjectSectionByIdDto, ProjectSection>().ReverseMap();
            CreateMap<GetProjectSectionByIdDto, UpdateProjectSectionDto>();

            CreateMap<Question, ResultQuestionDto>().ReverseMap();
            CreateMap<CreateQuestionDto, Question>().ReverseMap();
            CreateMap<UpdateQuestionDto, Question>().ReverseMap();
            CreateMap<GetQuestionByIdDto, Question>().ReverseMap();
            CreateMap<GetQuestionByIdDto, UpdateQuestionDto>();

            CreateMap<Shipment, ResultShipmentDto>().ReverseMap();
            CreateMap<CreateShipmentDto, Shipment>().ReverseMap();
            CreateMap<UpdateShipmentDto, Shipment>().ReverseMap();
            CreateMap<GetShipmentByIdDto, Shipment>().ReverseMap();
            CreateMap<GetShipmentByIdDto, UpdateShipmentDto>();

            CreateMap<ShipmentTracking, ResultShipmentTrackingDto>().ReverseMap();
            CreateMap<CreateShipmentTrackingDto, ShipmentTracking>().ReverseMap();
            CreateMap<UpdateShipmentTrackingDto, ShipmentTracking>().ReverseMap();
            CreateMap<ResultShipmentTrackingDto, UpdateShipmentTrackingDto>();
            //  CreateMap<GetShipmentTrackingByIdDto, ShipmentTracking>().ReverseMap();
        }
    }
}


