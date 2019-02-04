using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAV_GAME_FINAL
{
    class AtaqueIA
    {
        static public int[] AIChooseCellToHit(Jogador Maquina)
        {
            // Seleciona qual a célula que a AI Escolhe dentro das células disponiveis para destruir veículos
            int [] probabilitySet = new int[2];

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if(Game.TabGame.CombSituacao[x, y] == 0)
                    {
                        probabilitySet[0] = x;
                        probabilitySet[1] = y;
                        return probabilitySet;
                    }
                    
                }
            }
            probabilitySet[0] = -1;
            probabilitySet[1] = -1;
            return probabilitySet;

        }
    }
}
