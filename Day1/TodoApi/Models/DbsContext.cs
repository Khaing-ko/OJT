using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TodoApi.Models
{
    public class DbsContext : DbContext
    {
        public DbsContext(DbContextOptions<DbsContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<HeroList> HeroLists { get; set; } = null!;

        public DbSet<TodoItemDTO> TodoItemDTOs { get; set; } = null!;

    }

    
}