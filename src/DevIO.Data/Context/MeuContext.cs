using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Context
{
    public class MeuContext: DbContext
    {
        public MeuContext(DbContextOptions options): base (options)
        {

        }

        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<EnderecosModel> Enderecos { get; set; }
        public DbSet<FornecedorModel> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         /*  setando as string para varchar caso esquecemos de tipar algum atributo
          
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.Relational().Columntype = "varchar(100)";
         */

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuContext).Assembly);

            //esse foreach impede que uma classe quando excluida, leve os filhos juntos. é opcional, sem ele quando o obj pai é excluida os filhos vao juntos
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }
    }
}
