using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAV_GAME_FINAL
{
    public class Jogador
    {
        // names dos Jogadores
        public string Nome { get; set; }
        public int CorEsc { get; set; }

        // Registo de Batalha
        public int Hits { get; set; }
        
        // Numero de misseis disoniveis
        public int Misseis { get; set; }
        
        // Hit ratio.
        public double HitRatio { get; set; }

        //Cotação do Jogador
        public int Cotacao { get; set; }

        //Se o jogador já jogou
        public bool JaJogou { get; set; }
        public bool IA { get; set; }

        public Jogador()
        {
            IA = false;
            Hits = 0;
            Misseis = 0;
            HitRatio = 0;
            Cotacao = 0;
            JaJogou = false;
        }
    }
}
