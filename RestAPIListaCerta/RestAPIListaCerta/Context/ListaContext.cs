using Microsoft.EntityFrameworkCore;
using RestAPIListaCerta.Models;

namespace RestAPIListaCerta.Context
{
    public class ListaContext : DbContext
    {
        public ListaContext (DbContextOptions<ListaContext>options) : base(options)
        {
            
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lista> Listas { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

    }
}
