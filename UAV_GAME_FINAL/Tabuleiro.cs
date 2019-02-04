using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAV_GAME_FINAL
{
    public partial class Tabuleiro : Form
    {
        // Mouse selecionado. [-1, -1] para nenhum.
        int mouseCellX;
        int mouseCellY;

        // Índice de um navio selecionado.
        int CombSelec;
        
        // Quais são os comboios depositados
        bool[] CombDepositados = new bool[4];

        public Tabu TabGame;

        int NumVeiculosDepositados;
        int NumComb1;
        int NumComb2;
        int NumComb3;
        int NumComb4;


        public Tabuleiro()
        {
            InitializeComponent();
            // Desative o botão de maximização na barra de título.
            MaximizeBox = false;
            //Defina a localização do formulário no canto superior esquerdo do pai.
            CenterToParent();

            // Coloca a Imagem mapa  na deckPictureBox do detabuleiro
            DeckPictureBox.Image = GraphicContext.deckImages;

            mouseCellX = -1;
            mouseCellY = -1;
            CombSelec = -1;
            NumVeiculosDepositados = Game.TabGame.NumVeiculos;
            NumComb1 = 0;
            NumComb2 = 0;
            NumComb3 = 0;
            NumComb4 = 0;
            
        }

        private void DeckPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            // Existe algum comboio selecionado?
            if (CombSelec != -1)
            {
                // O Jogador está a selecionar alguma célula do tabuleiro?
                if (GraphicContext.GetCoorX(this, DeckPictureBox) != -1 && GraphicContext.GetCoorY(this, DeckPictureBox) != -1)
                {
                    // O rato mexeu-se?
                    if (GraphicContext.GetCell(GraphicContext.GetCoorX(this, DeckPictureBox)) != mouseCellX || GraphicContext.GetCell(GraphicContext.GetCoorY(this, DeckPictureBox)) != mouseCellY)
                    {
                        // Reescreva as informações da célula do mouse.
                        mouseCellX = GraphicContext.GetCell(GraphicContext.GetCoorX(this, DeckPictureBox));
                        mouseCellY = GraphicContext.GetCell(GraphicContext.GetCoorY(this, DeckPictureBox));

                        // Redesenha o Tabuleiro
                        DeckPictureBox.Refresh();

                            // Mostra a cor do comboio selecionado no Tabuleiro
                            for (int i = 0; i < ComboioTabuleiro.CombTamanho[CombSelec]; i++)
                            {
                                //O comboio desenhado não atravessa os limites do tabuleiro
                                if (mouseCellX + i <= 9)
                                {
                                    GraphicContext.DrawInnerFrameCell(mouseCellX + i, mouseCellY, CombSelec, this, DeckPictureBox);
                                }
                                else
                                {
                                    break;
                                }
                            }
                    }
                }
                else
                {
                    // Fora dos limites do tabuleiro
                    if (mouseCellX != -1 || mouseCellY != -1)
                    {
                        mouseCellX = -1;
                        mouseCellY = -1;

                        // Redesenha o Tabuleiro
                        DeckPictureBox.Refresh();
                    }

                }
            }
        }

        private void DeckPictureBoxPaint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawCombSet(Game.TabGame.CombSet, e);
        }



        // Estes métodos são todos iguais para todos os botões dos comboios
        private void Comb1_Click(object sender, EventArgs e)
        {
            CombSelec = 0;
        }

        private void Comb2_Click(object sender, EventArgs e)
        {
            CombSelec = 1;
        }

        private void Comb3_Click(object sender, EventArgs e)
        {
            CombSelec = 2;
        }

        private void Comb4_Click(object sender, EventArgs e)
        {
            CombSelec = 3;
        }

        // Esses métodos são todos iguais para todos os botões de exclusão.
        private void Del1_Click_1(object sender, EventArgs e)
        {
            // Apaga todos os comboios 0 do tabuleiro
            ComboioTabuleiro.EliminarComboio(0, Game.TabGame.CombSet);
            NumVeiculosDepositados = NumVeiculosDepositados + NumComb1 * 1;
            NumComb1 = 0;
            
            // Redesenha o tabuleiro
            DeckPictureBox.Refresh();

            if (NumVeiculosDepositados >= 7)
            {
                Comb4.Enabled = true;
                Comb3.Enabled = true;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }


            if (NumVeiculosDepositados < 7)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = true;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }

            if (NumVeiculosDepositados < 5)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = false;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }

            if (NumVeiculosDepositados < 3)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = false;
                Comb2.Enabled = false;
                Comb1.Enabled = true;
            }
            Del1.Enabled = false;
            Done.Enabled = false;


        }

        private void Del2_Click_1(object sender, EventArgs e)
        {
            ComboioTabuleiro.EliminarComboio(1, Game.TabGame.CombSet);
            NumVeiculosDepositados = NumVeiculosDepositados + NumComb2 * 3;
            NumComb2= 0;
            DeckPictureBox.Refresh();
            if (NumVeiculosDepositados >= 7)
            {
                Comb4.Enabled = true;
                Comb3.Enabled = true;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }


            if (NumVeiculosDepositados < 7)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = true;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }

            if (NumVeiculosDepositados < 5)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = false;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }

            if (NumVeiculosDepositados < 3)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = false;
                Comb2.Enabled = false;
                Comb1.Enabled = true;
            }

            Del2.Enabled = false;
            Done.Enabled = false;


        }

        private void Del3_Click_1(object sender, EventArgs e)
        {
            ComboioTabuleiro.EliminarComboio(2, Game.TabGame.CombSet);
            NumVeiculosDepositados = NumVeiculosDepositados + NumComb3 * 5;
            NumComb3= 0;
            DeckPictureBox.Refresh();
            if (NumVeiculosDepositados >= 7)
            {
                Comb4.Enabled = true;
                Comb3.Enabled = true;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }


            if (NumVeiculosDepositados < 7)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = true;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }

            if (NumVeiculosDepositados < 5)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = false;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }

            if (NumVeiculosDepositados < 3)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = false;
                Comb2.Enabled = false;
                Comb1.Enabled = true;
            }

            Del3.Enabled = false;
            Done.Enabled = false;
        }

        private void Del4_Click_1(object sender, EventArgs e)
        {
            ComboioTabuleiro.EliminarComboio(3, Game.TabGame.CombSet);
            NumVeiculosDepositados = NumVeiculosDepositados + NumComb4 * 7;
            NumComb4 = 0;
            DeckPictureBox.Refresh();
            if (NumVeiculosDepositados >= 7)
            {
                Comb4.Enabled = true;
                Comb3.Enabled = true;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }


            if (NumVeiculosDepositados < 7)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = true;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }

            if (NumVeiculosDepositados < 5)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = false;
                Comb2.Enabled = true;
                Comb1.Enabled = true;
            }

            if (NumVeiculosDepositados < 3)
            {
                Comb4.Enabled = false;
                Comb3.Enabled = false;
                Comb2.Enabled = false;
                Comb1.Enabled = true;
            }

            Done.Enabled = false;
            Del4.Enabled = false;
        }

        private void Done_Click(object sender, EventArgs e)
        {
            int VeiculosMAxComboio = 0;
            int a = 0;
            
            //saber qual é o comboio com a maior extensão
            for (int i=0; i<10;i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Game.TabGame.CombSituacao[j,i] == 0)
                    {
                        a++;
                    }
                }
                if (a > VeiculosMAxComboio)
                {
                    VeiculosMAxComboio = a;
                }
                a = 0;
            }

            Game.TabGame.ComboioMaisExtenso = VeiculosMAxComboio;
            Game.Jogador1.Misseis = Game.TabGame.ComboioMaisExtenso;
            Game.Jogador2.Misseis = Game.TabGame.ComboioMaisExtenso;

            Game.TabGame.VeiculosLeft = Game.TabGame.NumVeiculos;

            Jogo jogo = new Jogo
            {
                Location = Location
            };
            jogo.Show();

            // Dispose não aciona o evento FormClosing.
            Dispose();
        }

        private void DeckPictureBox_Click_1(object sender, EventArgs e)
        {
            if (CombSelec != -1 && mouseCellX != -1 && mouseCellY != -1 && NumVeiculosDepositados>0)
            {
                if (ComboioTabuleiro.PodeSerComboio(CombSelec, mouseCellX, mouseCellY, Game.TabGame.CombSet))
                {

                    ComboioTabuleiro.ColocarComboio(CombSelec, mouseCellX, mouseCellY, Game.TabGame.CombSet);

                    NumVeiculosDepositados = NumVeiculosDepositados - ComboioTabuleiro.CombTamanho[CombSelec];
                    // O Comboio Selecionado foi colocado com sucesso


                    switch (CombSelec)
                    {
                        case 0:
                            NumComb1 = NumComb1+1;
                            Del1.Enabled = true;
                            break;

                        case 1:
                            NumComb2 = NumComb2+1;
                            Del2.Enabled = true;
                            break;

                        case 2:
                            NumComb3 = NumComb3+1;
                            Del3.Enabled = true;
                            break;

                        case 3:
                            NumComb4 = NumComb4+1;
                            Del4.Enabled = true;
                            break;
                    }

                    // Muda os botões dos comboios

                    if (NumVeiculosDepositados<7)
                    {
                        Comb4.Enabled = false;
                       
                    }
                    if (NumVeiculosDepositados < 5)
                    {
                        Comb3.Enabled = false;
                        
                    }
                    if (NumVeiculosDepositados < 3)
                    {
                        Comb2.Enabled = false;
                        
                    }
                    if (NumVeiculosDepositados < 1)
                    {
                        Comb1.Enabled = false;
                        
                    }


                    // Coloca o Comboio Selecionado no Registo do Comboio Set



                    // Redesenha o Tabuleiro
                    DeckPictureBox.Refresh();

                    // Unselected Comboio
                    CombSelec = -1;

                    // Todos os comboios foram colocados?
                    if (NumVeiculosDepositados==0)
                    {
                        Done.Enabled = true;
                    }
                }
            }
        }

        private void Tabuleiro_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult quitToMainMenu = MessageBox.Show("Quer sair para o menu principal?", "Sair do UAV GAME....", MessageBoxButtons.YesNo);
            if (quitToMainMenu == DialogResult.Yes)
            {
                // Caso alguém clique no botão fechar, mostre a caixa de diálogo.
                GlobalContext.MainMenuForm.Location = Location;
                GlobalContext.MainMenuForm.Show();
            }
            else
            {
                // Impedir que o formulário seja fechado.
                e.Cancel = true;
            }
        }
    }
}
