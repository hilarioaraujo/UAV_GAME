using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UAV_GAME_FINAL
{
    public class Estatisticas
    {
        public string Nome { get; set; }
	    public int Cotacao { get; set; }

        public Estatisticas (string nome, int cotacao)
	    {
            Nome = nome;
            Cotacao = cotacao;
	    }

        public Estatisticas(){}
}
}
