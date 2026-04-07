namespace LogisticsCMS.Services
{
    public interface ICrudService<TCreateDto, TUpdateDto, TResultDto, TGetByIdDto>
    {
        Task<List<TResultDto>> GetAllAsync();
        Task<TGetByIdDto?> GetByIdAsync(string id);
        Task CreateAsync(TCreateDto createDto);
        Task UpdateAsync(TUpdateDto updateDto);
        Task DeleteAsync(string id);
    }
}
