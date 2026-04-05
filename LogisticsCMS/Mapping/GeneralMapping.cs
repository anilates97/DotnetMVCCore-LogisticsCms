namespace LogisticsCMS.Mapping
{
    using AutoMapper;
    using LogisticsCMS.Dtos.AboutDtos;
    using LogisticsCMS.Dtos.BrandDtos;
    using LogisticsCMS.Dtos.GetInTouchSectionDtos;
    using LogisticsCMS.Dtos.HowItWorkDtos;
    using LogisticsCMS.Dtos.OfferDtos;
    using LogisticsCMS.Dtos.ProjectSectionDtos;
    using LogisticsCMS.Dtos.QuestionDtos;
    using LogisticsCMS.Dtos.ShipmentDto;
    using LogisticsCMS.Dtos.ShipmentTrackingDto;
    using LogisticsCMS.Dtos.SliderDtos;
    using LogisticsCMS.Dtos.TestimonialDtos;
    using LogisticsCMS.Models;

    public class GeneralMapping : Profile // AutoMapper profili oluÅŸturarak, model ve DTO'lar arasÄ±nda dÃ¶nÃ¼ÅŸÃ¼mleri tanÄ±mlÄ±yoruz
    {
        public GeneralMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap(); // Slider modelini ResultSliderDto'ya ve tam tersine dÃ¶nÃ¼ÅŸtÃ¼rmek iÃ§in bir eÅŸleme tanÄ±mlÄ±yoruz
            CreateMap<CreateSliderDto, Slider>().ReverseMap();
            CreateMap<UpdateSliderDto, Slider>().ReverseMap();
            CreateMap<GetSliderByIdDto, Slider>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<CreateBrandDto, Brand>().ReverseMap();
            CreateMap<UpdateBrandDto, Brand>().ReverseMap();
            CreateMap<GetBrandByIdDto, Brand>().ReverseMap();

            CreateMap<Offer, ResultOfferDto>().ReverseMap();
            CreateMap<CreateOfferDto, Offer>().ReverseMap();
            CreateMap<UpdateOfferDto, Offer>().ReverseMap();
            CreateMap<GetOfferByIdDto, Offer>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<GetAboutByIdDto, About>().ReverseMap();

            CreateMap<GetInTouchSection, ResultGetInTouchSectionDto>().ReverseMap();
            CreateMap<CreateGetInTouchSectionDto, GetInTouchSection>().ReverseMap();
            CreateMap<UpdateGetInTouchSectionDto, GetInTouchSection>().ReverseMap();
            CreateMap<GetGetInTouchSectionByIdDto, GetInTouchSection>().ReverseMap();

            CreateMap<HowItWork, ResultHowItWorkDto>().ReverseMap();
            CreateMap<CreateHowItWorkDto, HowItWork>().ReverseMap();
            CreateMap<UpdateHowItWorkDto, HowItWork>().ReverseMap();
            CreateMap<GetHowItWorkByIdDto, HowItWork>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialByIdDto, Testimonial>().ReverseMap();

            CreateMap<ProjectSection, ResultProjectSectionDto>().ReverseMap();
            CreateMap<CreateProjectSectionDto, ProjectSection>().ReverseMap();
            CreateMap<UpdateProjectSectionDto, ProjectSection>().ReverseMap();
            CreateMap<GetProjectSectionByIdDto, ProjectSection>().ReverseMap();

            CreateMap<Question, ResultQuestionDto>().ReverseMap();
            CreateMap<CreateQuestionDto, Question>().ReverseMap();
            CreateMap<UpdateQuestionDto, Question>().ReverseMap();
            CreateMap<GetQuestionByIdDto, Question>().ReverseMap();

            CreateMap<Shipment, ResultShipmentDto>().ReverseMap();
            CreateMap<CreateShipmentDto, Shipment>().ReverseMap();
            CreateMap<UpdateShipmentDto, Shipment>().ReverseMap();
            CreateMap<GetShipmentByIdDto, Shipment>().ReverseMap();

            CreateMap<ShipmentTracking, ResultShipmentTrackingDto>().ReverseMap();
            CreateMap<CreateShipmentTrackingDto, ShipmentTracking>().ReverseMap();
            CreateMap<UpdateShipmentTrackingDto, ShipmentTracking>().ReverseMap();
            //  CreateMap<GetShipmentTrackingByIdDto, ShipmentTracking>().ReverseMap();
        }
    }
}

