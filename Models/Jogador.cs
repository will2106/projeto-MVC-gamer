using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gamer_MVC.Models
{
    public class Jogador
    {

        [Key]    // Data Annotation -IdJogador   
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }


        [ForeignKey("Equipe")] // chave estrangeira, que faz ligacao com a chave IdEquipe da classe(tabela) equipe
        public int IdEquipe { get; set; }

        
        public Equipe Equipe {get;set;}



    }
}