using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infraestrutura.Contextos
{
    public class Fabrica : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var conexao = "Server=localhost;DataBase=Estacionamento;Uid=estacionamento;Pwd=1234";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySQL(conexao);

            return new MyContext(optionsBuilder.Options);
        }
    }
}