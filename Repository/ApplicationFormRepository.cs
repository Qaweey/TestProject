using CapitalPlacement.Models;
using CapitalPlacement.Repository.Interface;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacement.Repository
{
    public class ApplicationFormRepository : IApplicationForm
    {
        private readonly Container _container;
        public ApplicationFormRepository(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }
        public async  Task<ApplicationForm> CreateApplicationForm(ApplicationForm appForm)
        {
            var response = await _container.CreateItemAsync(appForm, new PartitionKey(appForm.CustId));
            return response.Resource;
        }

        public async  Task<ApplicationForm> GetApplicationForm(string custId)
        {
            try
            {
                var response = await _container.ReadItemAsync<ApplicationForm>(custId, new PartitionKey(custId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Product not found
            }
        }

        public async  Task<ApplicationForm> UpdateApplicationFormAsync(string custId, ApplicationForm updatedAppform)
        {
            try
            {
                var response = await _container.ReplaceItemAsync(updatedAppform, custId, new PartitionKey(custId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Product not found
            }
        }
    }
}
