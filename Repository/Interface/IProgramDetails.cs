using CapitalPlacement.Models;

namespace CapitalPlacement.Repository.Interface
{
    public interface IProgramDetails
    {
        Task<ProgramDetails> CreateProgramDetails(ProgramDetails programDetails);
        Task<ProgramDetails> GetProgramDetails(string custId);

        Task<ProgramDetails> UpdateProgramDetailsAsync(string custId, ProgramDetails updatedProduct);
    }
}
