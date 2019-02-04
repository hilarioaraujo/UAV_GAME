using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAV_GAME_FINAL
{
    class ComboioTabuleiro
    {
        public static int[] CombTamanho = new int[4] { 1, 3, 5, 7 };

        // O método retorna se uma célula pode conter um comboio.
        static public bool PodeSerComboio(int CombSelec, int cellX, int cellY, int[,] CombSet)
        {
            // O indice x e y do tabuleiro está inválido
            if (cellX < 0 || cellY < 0)
            {
                return false;
            }

            if (cellX + CombTamanho[CombSelec] - 1 <= 9)
            {
                //Procura por um layout inválido na grelha do tabuleiro
                for (int i = Math.Max(0, cellX); i <= Math.Min(9, cellX-1 + CombTamanho[CombSelec]); i++)
                {
                    for (int j = Math.Max(0, cellY); j <= Math.Min(9, cellY); j++)
                    {
                        if (CombSet[i, j] != -1)
                        {
                            //O layout selecionado é inválido
                            return false;
                        }
                    }
                }

                // Layout encontrado inválido
                return true;
            }
            else
            {
                // Está fora da grelha do tabuleiro
                return false;
            }
        }

        
        // A segunda implementação é dedicada à lógica AI.
        static public bool PodeSerComboio(int CombSelec, int cellX, int cellY, Tabu TabGame)
        {
            
            if (cellX < 0 || cellY < 0)
            {
                return false;
            }

            if (cellX + CombTamanho[CombSelec] - 1 <= 9)
            {
                //Procura por um layout inválido na grelha do tabuleiro
                for (int i = Math.Max(0, cellX); i <= Math.Min(9, cellX-1 + CombTamanho[CombSelec]); i++)
                {
                    for (int j = Math.Max(0, cellY); j <= Math.Min(9, cellY); j++)
                    {
                        // Ship position cells.
                        if (i >= cellX && i < cellX + CombTamanho[CombSelec] && j == cellY)
                        {
                            if(TabGame.CellsTrancadas[i, j] && TabGame.CombSet[i, j] == -1)
                            {
                                return false;
                            }

                        }
                        else
                        {
                            // If there is a neighbouring revealed ship cell.
                            if (TabGame.CellsTrancadas[i, j] && TabGame.CombSet[i, j] != -1)
                            {
                                // Invalid layout found.
                                return false;
                            }
                        }
                    }
                }

                //Layout encontrado inválido
                return true;
            }
            else
            {
                // Está fora da grelha do tabuleiro
                return false;
            }

        }

        // Coloca o Comboio no Tabuleiro
        static public void ColocarComboio(int CombSelec, int cellX, int cellY, int[,] CombSet)
        {
            for (int i = 0; i < CombTamanho[CombSelec]; i++)
            {
                // Coloca o comboio no ComboSet
                CombSet[cellX + i, cellY] = CombSelec;
                Game.TabGame.CombSituacao[cellX + i, cellY] = 0;
                Game.TabGame.CellsTrancadas[cellX + i, cellY] = false;
            }

        }

        // Eliminar Comboio do Tabuleiro de Jogo
        static public void EliminarComboio(int CombSelec, int[,] CombSet)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (CombSet[x, y] == CombSelec)
                    {
                        Game.TabGame.CombSituacao[x, y] = -1;
                        CombSet[x, y] = -1;
                        Game.TabGame.CellsTrancadas[x, y] = true;
                    }
                }
            }
        }

        // Colocação randam do Comboio
        static public void AICombDestribuicao()
        {

            int VeiculosADepositar = Game.TabGame.NumVeiculos;

            int CombSelec = 0;

            //Enquanto o numero de Veiculos depositados for maior que zero o ciclo vai decorrer para encontrar forma de os depositar
            while (VeiculosADepositar > 0)
            {
                //se for maior que 7, podem ser selecionado todos os bomboios
                if (VeiculosADepositar > 7)
                {
                    CombSelec = GlobalContext.RandomNumber(3);
                }
                else
                {
                    // se for menor que 7 só podem ser selecionados os comboios 0, 1 e 2
                    if (VeiculosADepositar < 7)
                    {
                        CombSelec = GlobalContext.RandomNumber(2);
                    }
                    else
                    {
                        // se for menor que 5 só podem ser selecionados os comboios 0, 1
                        if (VeiculosADepositar < 5)
                        {
                            CombSelec = GlobalContext.RandomNumber(1);
                        }
                        else
                        {
                            // se for menor que 3 só podem ser selecionados os comboios 0
                            CombSelec = 1;
                        }
                    }
                }
            
                // Inicia a lista de possibilidades - serve para criar uma lista de possibilidades para cada comboio a ser implementado no tabuleiro
                List<int[]> possibilities = new List<int[]>();

                // Para todas as células do tabuleiro 10 x 10.
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        // Existe alguma célula livre no tabuleiro?
                        if (PodeSerComboio(CombSelec, x, y, Game.TabGame.CombSet))
                        {
                            // Adiciona esta possibilidade [x, y].
                            possibilities.Add(new int[2] { x, y });
                        }
                    }
                }

                // Escolhe a possibilidade.
                int numberOfChosen = GlobalContext.RandomNumber(possibilities.Count);

                // Implanta o comboio no tabuleiro
                ColocarComboio(CombSelec, possibilities[numberOfChosen][0], possibilities[numberOfChosen][1], Game.TabGame.CombSet);
                VeiculosADepositar = VeiculosADepositar - CombTamanho[CombSelec];
            }
        }

        // Adiciona probabilidade a todos os pontos em que o comboio pode ser implantado.
        static private void ProbabilitySetAddComb(int CombSelec, int cellX, int cellY, int[,] probabilitySet)
        {
            for (int i = 0; i < CombTamanho[CombSelec]; i++)
            {

                probabilitySet[cellX + i, cellY]++;
            }
        }
    }
}
