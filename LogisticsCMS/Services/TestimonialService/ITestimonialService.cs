using LogisticsCMS.Dtos.TestimonialDtos;

namespace LogisticsCMS.Services.TestimonialService
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id);
        Task DeleteTestimonialAsync(string id);
    }
}

