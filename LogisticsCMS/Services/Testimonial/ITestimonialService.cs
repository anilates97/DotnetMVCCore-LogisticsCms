using LogisticsCMS.Dtos.Testimonial;

namespace LogisticsCMS.Services.Testimonial
{
    public interface ITestimonialService
        : ICrudService<
            CreateTestimonialDto,
            UpdateTestimonialDto,
            ResultTestimonialDto,
            GetTestimonialByIdDto
        >
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<GetTestimonialByIdDto?> GetTestimonialByIdAsync(string id);
        Task DeleteTestimonialAsync(string id);
    }
}
