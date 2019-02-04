using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAV_GAME_FINAL
{
    public class Tabu
    {
        public int DimLinhas { get; set; }
        public int DimColunas { get; set; }
        public bool EscAleat { get; set; }
        public int NumVeiculos { get; set; }
        public int[] ComboiosLeftCells { get; set; }
        public int[,] CombSituacao { get; set; }

        // Localização dos comboios
        public int[,] CombSet { get; set; }

        // [true] trancadas / [false] destrancadas
        public bool[,] CellsTrancadas { get; set; }
        public bool[,] CellsTrancadasDepoisJogar { get; set; }
        public int[] LastCellsTrancadas { get; set; }
        
        //Veiculos que faltam destruir
        public int VeiculosLeft { get; set; }
        
        // COmboios que faltam destruir
        public int ComboiosLeft { get; set; }

        public int ComboioMaisExtenso { get; set; }

        // registo de batalha
        public string BattleLog { get; set; }


        public Tabu()
        { 
            
            DimLinhas = 0; //Numero de linhas
            DimColunas = 0; // numero de colunas
            CombSet = new int[10, 10]; //Registo de onde estão os comboios
            CombSituacao = new int[10, 10]; //descrição de como esta o statos do tabuleiro (veiculos destruidos, que faltam destuir e células livres
            CellsTrancadasDepoisJogar = new bool[10, 10]; // células que ficarão trancadas após uma jogada
            CellsTrancadas = new bool[10, 10]; // Células trancadas a cada ronda
            ComboiosLeftCells = new int[] { 1, 3, 5, 7 }; //

            VeiculosLeft = 16;
            ComboiosLeft = 4;
            ComboioMaisExtenso = 7; //numero por default
            LastCellsTrancadas = new int[2];
            LastCellsTrancadas[0] = -1;
            LastCellsTrancadas[1] = -1;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    CombSituacao[i, j] = -1;
                    CombSet[i, j] = -1;
                    CellsTrancadas[i, j] = true;
                    CellsTrancadasDepoisJogar[i, j] = true;
                }
            }
        }
    }
}
