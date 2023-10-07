using CapitalPlacement.Models;

namespace CapitalPlacement.Repository.Interface
{
    public interface IWorkFlow
    {
        Task<WorkFlow> CreateWorkFlowDetails(WorkFlow workFlow);
        Task<WorkFlow> GetWorkFlow(string custId);

        Task<WorkFlow> UpdateProgramDetailsAsync(string custId, WorkFlow workFlow);
    }
}
