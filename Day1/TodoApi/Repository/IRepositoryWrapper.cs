namespace TodoApi.Repository
{
    public interface IRepositoryWrapper
    {
        ITodoItemRepository TodoItem { get; }
        
    }
}
