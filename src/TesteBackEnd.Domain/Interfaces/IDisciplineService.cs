using TesteBackEnd.Domain.Dtos.Discipline;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IDisciplineService
    {
        Task<DisciplineDto> SelectAsync(Guid id);
        Task<IEnumerable<DisciplineDto>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<DisciplineDtoCreateResult> InsertAsync(DisciplineDtoCreate item);
        Task<DisciplineDtoUpdateResult> UpdateAsync(DisciplineDtoUpdate item);
        Task<bool> DeleteAsync(Guid id);
    }
}
