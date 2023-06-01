using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamer_MVC.Models
{
    public class Equipe
    {

        [Key]// (chave) DATA ANNOTATION -IdEquipe //
        public int IdEquipe { get; set; }
        
        public string Nome { get; set; }
        
        public string Imagem { get; set; }
        

        // referencia que a classe equipe vai ter acesso a colection "Jogador"
        public  ICollection< Jogador> Jogador {get;set;} 



    }
}