using CapitalPlacement.Models;
using CapitalPlacement.Repository.Interface;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacement.Repository
{
    public class ProgramDetailsRepository : IProgramDetails
    {
        private readonly Container _container;
        public ProgramDetailsRepository(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));

        }
        public async  Task<ProgramDetails> CreateProgramDetails(ProgramDetails programDetails)
        {

            var response = await _container.CreateItemAsync(programDetails, new PartitionKey(programDetails.CustId));
            return response.Resource;

        }

        public async  Task<ProgramDetails> GetProgramDetails(string custId)
        {
            try
            {
                var response = await _container.ReadItemAsync<ProgramDetails>(custId, new PartitionKey(custId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Product not found
            }

        }

        public async  Task<ProgramDetails> UpdateProgramDetailsAsync(string custId, ProgramDetails updatedProduct)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(updatedProduct, custId, new PartitionKey(custId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Product not found
            }

        }
    }
}
