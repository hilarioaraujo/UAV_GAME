using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAV_GAME_FINAL
{
    static class Game
    {

        public static Jogador Jogador1;
        public static Jogador Jogador2;
        public static Tabu TabGame;
        public static int gameMode;

        public static string[] letterLabels = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        public static string[] numberLables = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };


        //Troca de Jogador
        public static bool SwitchJogador;
        
        // Round count.
        public static int roundCount;
        
        // Inicia o Jogo
        static public void Initialize()
        {
            int a = GlobalContext.RandomNumber(1);
            if (a == 0)
            {
                SwitchJogador = true;
            }
            else
            {
                SwitchJogador = false;
            }

            roundCount = 0;
        }

        //Ciclo para determinar se existem mais veículos na linha para serem destruidos 
        //returna true se houverem/ false se não
        static public bool ExisteMaisVeicLinha(int celly)
        {
            for (int y = 0; y < 10; y++)
            {
                if (Game.TabGame.CombSituacao[y, celly] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Performa o ataque do Jogador 
        // [true] se o jogo acabou, já não há mais veículos para serem abatidos / [false] se ainda à veículos que não foram destruidos.
        static public bool PerformAttack(int cellX, int cellY, Jogador attacker, Jogador other)
        {
            string attackerLogNote = "--> " + String.Format("{0:000}", roundCount) + ".ronda: " + attacker.Nome + ", atacou o veículo da célula [" +
                letterLabels[cellY] + "," + numberLables[cellX] + "]. ";

            attacker.Hits = attacker.Hits++;
            attacker.Misseis = attacker.Misseis - 1;
            attacker.HitRatio = Convert.ToDouble(attacker.Hits) / Convert.ToDouble(Game.roundCount);

            // O ataque foi realizado com sucesso
            if (TabGame.CombSituacao[cellX, cellY] == 0)
            {
                if (SwitchJogador)
                {
                    TabGame.CombSituacao[cellX, cellY] = 1;
                }
                else
                {
                    TabGame.CombSituacao[cellX, cellY] = 2;
                }

                // Marca a célula atingida como trancada
                TabGame.CellsTrancadas[cellX, cellY] = true;
                TabGame.CellsTrancadasDepoisJogar[cellX, cellY] = true;

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        TabGame.CellsTrancadasDepoisJogar[i, j] = true;
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    if (TabGame.CombSituacao[i, cellY] == 0)
                    {
                        TabGame.CellsTrancadasDepoisJogar[i, cellY] = false;
                    }
                    else
                    {
                        TabGame.CellsTrancadasDepoisJogar[i, cellY] = true;
                    }
                }

                // Marca a última célula trancada
                TabGame.LastCellsTrancadas[0] = cellX;
                TabGame.LastCellsTrancadas[1] = cellY;

                // Aumenta a contagem de hits do atacante.
                attacker.Hits++;

                // Decresce o número de veiculos que restam
                TabGame.VeiculosLeft--;

                // O jogo acabou?
                if (TabGame.VeiculosLeft == 0)
                {
                    string last = "--> " + String.Format("{0:000}", roundCount) + ".ronda: " + other.Nome.ToString() + " ganhou o jogo!" + " O " + attacker.Nome + " Destruiu o último veículo do Jogo!";
                    TabGame.BattleLog = TabGame.BattleLog + attackerLogNote + "\n" + last;

                    return true;
                }
                else
                {
                    //verifica se os misseis do Jogaor acabam quando o ataque
                    if (attacker.Misseis == 0 || TabGame.VeiculosLeft ==0)
                    {
                        string last = "--> " + String.Format("{0:000}", roundCount) + ".ronda: " + other.Nome.ToString() + " ganhou o jogo!" + " O " + attacker.Nome + " Não tem mais misséis para jogar e ainda faltam destruir 2 ou mais veículos!";
                        TabGame.BattleLog = TabGame.BattleLog + attackerLogNote + "\n" + last;
                        return true;
                    }
                    else
                    {
                        // Returna false se ainda houverem veiculos a serem destruidos
                        TabGame.BattleLog = TabGame.BattleLog + attackerLogNote + "\n";
                        return false;
                    }
                }
            }
            else
            {
                TabGame.BattleLog = TabGame.BattleLog + attackerLogNote + "\n";
                
                return false;
            }
        }
    }
}
