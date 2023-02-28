using TodoApi.Models;
namespace TodoApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DbsContext _repoContext;

        public RepositoryWrapper(DbsContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        private ITodoItemRepository? oItem;
        public ITodoItemRepository TodoItem
        {
            get
            {
                if (oItem == null)
                {
                    oItem = new TodoItemRepository(_repoContext);
                }

                return oItem;
            }
        }
        private IEmployeeRepository? oEmp;
        public IEmployeeRepository Employee
        {
            get
            {
                if (oEmp == null)
                {
                    oEmp = new EmployeeRepository(_repoContext);
                }

                return oEmp;
            }
        }
    }
}