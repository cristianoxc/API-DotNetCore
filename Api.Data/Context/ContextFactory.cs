using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            
            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
            {
                string connectionString;
                connectionString = "Server=localhost;Port=3306;Database=api_dotnet_core;Uid=root";
                optionsBuilder.UseMySql(connectionString);

            }
            else
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"));
            }
            return new MyContext(optionsBuilder.Options);
        }
    }
}
