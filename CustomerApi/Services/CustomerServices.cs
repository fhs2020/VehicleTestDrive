using Azure.Messaging.ServiceBus;

using CustomerApi.Data;
using CustomerApi.Interfaces;
using CustomerApi.Models;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace CustomerApi.Services
{
    public class CustomerServices : ICustomer
    {
        private ApiCustomerDbContext dbContext;

        public CustomerServices()
        {
            dbContext = new ApiCustomerDbContext();
        }

        public async Task AddCustomer(Customer customer)
        {
            var vehicleInDb = await dbContext.Vehicles.FirstOrDefaultAsync(v => v.Id == customer.VehicleId);
            if (vehicleInDb == null) 
            {
                await dbContext.Vehicles.AddAsync(customer.Vehicle);
                await dbContext.SaveChangesAsync();
            }

            customer.Vehicle = null;
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            string connectionString = "Endpoint=sb://vehicletestdriveapp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=nuIGL3F+LtXmOa6TZvMFx+HGEzEZsXUH9zo6bdD8xT8=";
            string queueName = "azureorderqueue";
            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            var customerObjectAsText = JsonConvert.SerializeObject(customer);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(customerObjectAsText);

            // send the message
            await sender.SendMessageAsync(message);
        }

        public Task DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
