using CapitalPlacement.Models;
using CapitalPlacement.Repository.Interface;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacement.Repository
{
    public class WorkFlowRepository : IWorkFlow
    {
        private readonly Container _container;
        public WorkFlowRepository(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));

        }
        public async  Task<WorkFlow> CreateWorkFlowDetails(WorkFlow workFlow)
        {
            var response = await _container.CreateItemAsync(workFlow, new PartitionKey(workFlow.CustId));
            return response.Resource;
        }

        public async  Task<WorkFlow> GetWorkFlow(string custId)
        {
            try
            {
                var response = await _container.ReadItemAsync<WorkFlow>(custId, new PartitionKey(custId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Product not found
            }
        }

        public async  Task<WorkFlow> UpdateProgramDetailsAsync(string custId, WorkFlow workFlow)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(workFlow, custId, new PartitionKey(custId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Product not found
            }
        }
    }
}
