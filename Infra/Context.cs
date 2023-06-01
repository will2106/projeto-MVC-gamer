using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamer_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamer_MVC.Infra
{
    public class Context : DbContext // context e responsavel por guardar as configuracoes do banco de dados.
    {

        public Context()
        {


        }

        public Context(DbContextOptions<Context> options) : base(options)

        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // string de concexao com o banco        
            //  Data Source : o nome do servidor do gerenciador do banco de dados
            // intergrated security : Autenticacao pelo windows
            // TrustServerCertificate : Autenticacao pelo windows


            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = NOTE14-S15 ; Initial Catalog = gamerManha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true "); // string de conexao


            }




        }


// referencia de classes e tabelas 
public DbSet<Jogador> Jogador {get;set;}


public DbSet<Equipe> Equipe {get;set;}



    }
}