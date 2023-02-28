using System.Data;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TodoApi.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbsContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Customer>> SearchCustomer(string searchTerm)
        {
            return await RepositoryContext.Customers
                        .Where(s => s.CustomerName.Contains(searchTerm))
                        .OrderBy(s => s.CustomerId).ToListAsync();
        }

        public async Task<IEnumerable<CustomerResult>> ListCustomer()
        {
            // return await RepositoryContext.Customers
            //             .OrderBy(s => s.Id).ToListAsync();
            // return await RepositoryContext.Customers
            //             .Include(e => e.EmpDepartment)
            //             .OrderBy(s => s.Id).ToListAsync();
            // return await RepositoryContext.Customers
            //             .Select(e => new CustomerResult{
            //                 Id = e.Id,
            //                 CustomerName = e.CustomerName,
            //                 CustomerAddress = e.CustomerAddress,
            //                 EmpDepartmentId = e.EmpDepartmentId
            //             })
            //             .OrderBy(s => s.Id).ToListAsync();
            return await RepositoryContext.Customers
                        .Select(e => new CustomerResult
                        {
                            CustomerId = e.CustomerId,
                            CustomerName = e.CustomerName,
                            CustomerAddress = e.CustomerAddress,
                            CustomerTypeId = e.CustomerTypeId,
                            CustomerTypeName = e.CustomerType!.CustomerTypeName,
                            CustomerTypeDescription = e.CustomerType.CustomerTypeDescription
                        })
                        .OrderBy(s => s.CustomerId).ToListAsync();
        }


        public bool IsExists(long id)
        {
            return RepositoryContext.Customers.Any(e => e.CustomerId == id);
        }
    }

}