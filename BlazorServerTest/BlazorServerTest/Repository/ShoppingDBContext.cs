using Microsoft.EntityFrameworkCore;
using ShardLibrary.Models;

namespace ShardLibrary.Repository
{

	public class ShoppingDBContext : DbContext
	{
		private const string _connectionString = "Data Source=localhost;Initial Catalog=ShoppingDB;Integrated Security=SSPI;TrustServerCertificate=true";
		public DbSet<ShoppingItem> ShoppingItems { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseSqlServer(_connectionString);
		}
	}
}
