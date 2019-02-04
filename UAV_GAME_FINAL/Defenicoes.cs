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
    public partial class Defenicoes : Form
    {
        bool EscolhaAleatoria = true;

        public Defenicoes()

        {
            InitializeComponent();
            
        }

        private void Tipo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Busca o tipo de jogador selecionado
            string tipo_jogador1 = Tipo1.Items[Tipo1.SelectedIndex].ToString();

            //Compara o tipo de jogador selecionado com a string humano, se for verdade, O nome da text box passa para Jogador 1, senão fica Máquina 1
            if (String.Equals(tipo_jogador1, "Humano"))
            {
                Nome1.Text = "Jogador 1";
                Game.Jogador1.IA = false;
            }

            else
            {
                Nome1.Text = "Máquina 1";
                Game.Jogador1.IA = true;
            }

            //Vai buscar o nome que o utilizador deu ao jogador, isto é vai buscar o valor da text box
            Game.Jogador1.Nome = Nome1.Text;
        }

        private void Tipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Busca o tipo de jogador selecionado
            string tipo_jogador2 = Tipo2.Items[Tipo2.SelectedIndex].ToString();

            //Compara o tipo de jogador selecionado com a string humano, se for verdade, O nome da text box passa para Jogador 2, senão fica Máquina 2
            if (String.Equals(tipo_jogador2, "Humano"))
            {
                Nome2.Text = "Jogador 2";
                Game.Jogador2.IA = false; ;
            }

            else
            {
                Nome2.Text = "Máquina 2";
                Game.Jogador2.IA = true;
            }

            //Vai buscar o nome que o utilizador deu ao jogador, isto é vai buscar o valor da text box
            Game.Jogador2.Nome = Nome2.Text;
        }

        private void EscolherPosicao_Click(object sender, EventArgs e)
        {

            if (Tipo1.SelectedItem == null)
            {
                MessageBox.Show("Terá de Selecionar Tipo de Jogador 1 antes de escolher a posição dos veículos!)", "Erro");
                return;
            }

            if (Tipo2.SelectedItem == null)
            {
                MessageBox.Show("Terá de Selecionar Tipo de Jogador 2 antes de escolher a posição dos veículos!)", "Erro");
                return;
            }

            if (ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Terá de Selecionar a Cor de Jogador que pretende mostrar no mapa!)", "Erro");
                return;
            }

            if (ComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Terá de Selecionar a Cor de Jogador que pretende mostrar no mapa!)", "Erro");
                return;
            }

            if (Convert.ToInt32(Veiculos.Text) < 0 || Convert.ToInt32(Veiculos.Text) > 100)
            {
                MessageBox.Show("Terá de escrever o número de veículos que pretende no jogo [0, 100] antes começar a Jogar!)", "Erro");
                return;
            }



            //Defenir o Tipo de Jogo : 0- Humano vs Humano
            //1- Maquina vs Maquina
            //2-Máquina vs Humano, Humano vs Máquina
            if ((String.Equals(Tipo1.Items[Tipo1.SelectedIndex].ToString(), "Humano")) && (String.Equals(Tipo1.Items[Tipo1.SelectedIndex].ToString(), "Humano")))
            {
                Game.gameMode = 0;
            }
            else
            {
                if ((String.Equals(Tipo1.Items[Tipo1.SelectedIndex].ToString(), "Máquina")) && (String.Equals(Tipo1.Items[Tipo1.SelectedIndex].ToString(), "Máquina")))
                {
                    Game.gameMode = 1;
                }
                else
                {
                    Game.gameMode = 2;
                }
            }

            Game.TabGame.DimLinhas = Convert.ToInt32(Linhas.Text);
            Game.TabGame.DimColunas = Convert.ToInt32(Colunas.Text);
            Game.TabGame.EscAleat = true;
            Game.TabGame.NumVeiculos = Convert.ToInt32(Veiculos.Text);
            Game.TabGame.VeiculosLeft = Game.TabGame.NumVeiculos;

            EscolhaAleatoria = false;
            Game.Jogador1.CorEsc = ComboBox1.SelectedIndex;
            Game.Jogador2.CorEsc = ComboBox2.SelectedIndex;


            //Inicia o tabuleiro para o jogador colocar lá os comboios
            Tabuleiro tabuleiro = new Tabuleiro
            {
                Location = Location
            };
            tabuleiro.Show();
            Hide();
        }

        private void Jogar_Click(object sender, EventArgs e)
        {

            if (Tipo1.SelectedItem == null)
            {
                MessageBox.Show("Terá de Selecionar Tipo de Jogador 1 antes começar a Jogar!)", "Erro");
                return;
            }

            if (Tipo2.SelectedItem == null)
            {
                MessageBox.Show("Terá de Selecionar Tipo de Jogador 2 antes de começar a Jogar!)", "Erro");
                return;
            }

            if (ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Terá de Selecionar a Cor de Jogador que pretende mostrar no mapa!)", "Erro");
                return;
            }

            if (ComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Terá de Selecionar a Cor de Jogador que pretende mostrar no mapa!)", "Erro");
                return;
            }
            if (Convert.ToInt32(Veiculos.Text) < 0 || Convert.ToInt32(Veiculos.Text)>100)
            {
                MessageBox.Show("Terá de escrever o número de veículos que pretende no jogo [0, 100] antes começar a Jogar!)", "Erro");
                return;
            }

            if (EscolhaAleatoria)
            {
                //Defenir o Tipo de Jogo : 0- Humano vs Humano
                //1- Maquina vs Maquina
                //2-Máquina vs Humano, Humano vs Máquina
                if ((String.Equals(Tipo1.Items[Tipo1.SelectedIndex].ToString(), "Humano")) && (String.Equals(Tipo1.Items[Tipo1.SelectedIndex].ToString(), "Humano")))
                {
                    Game.gameMode = 0;
                }
                else
                {
                    if ((String.Equals(Tipo1.Items[Tipo1.SelectedIndex].ToString(), "Máquina")) && (String.Equals(Tipo1.Items[Tipo1.SelectedIndex].ToString(), "Máquina")))
                    {
                        Game.gameMode = 1;
                    }
                    else
                    {
                        Game.gameMode = 2;
                    }
                }




                Game.TabGame.DimLinhas = Convert.ToInt32(Linhas.Text);
                Game.TabGame.DimColunas = Convert.ToInt32(Colunas.Text);
                Game.TabGame.EscAleat = true;
                Game.TabGame.NumVeiculos = Convert.ToInt32(Veiculos.Text);
                Game.TabGame.VeiculosLeft = Game.TabGame.NumVeiculos;


                Game.Jogador1.CorEsc = ComboBox1.SelectedIndex;
                Game.Jogador2.CorEsc = ComboBox2.SelectedIndex;

                //Implementação dos COmboios com a lógica IA
                ComboioTabuleiro.AICombDestribuicao();

                //saber qual é o comboio com a maior extensão
                int VeiculosMAxComboio = 0;
                int a = 0;

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (Game.TabGame.CombSituacao[j, i] == 0)
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

                Jogo jogo = new Jogo
                {
                    Location = Location
                };
                jogo.Show();
                Hide();
            }                
        }

        private void Defenicoes_Closing(object sender, FormClosingEventArgs e)
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

        private void ComboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            //[0] Amarelo
            //[1] Vermelho
            //[2] Verde
            //[3] Azul
            //[4] Violeta
            //[5] Branco
            //[6] Azul
            //[7] Magenta
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(GraphicContext.colors[e.Index], rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }
        }

        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //[0] Amarelo
            //[1] Vermelho
            //[2] Verde
            //[3] Azul
            //[4] Violeta
            //[5] Branco
            //[6] Azul
            //[7] Magenta
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(GraphicContext.colors[e.Index], rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }

        }
    }
}
