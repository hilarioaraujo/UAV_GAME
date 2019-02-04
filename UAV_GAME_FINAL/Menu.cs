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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void NovoJogo_Click(object sender, EventArgs e)
        {

            Game.Initialize();
            Game.Jogador1 = new Jogador();
            Game.Jogador2 = new Jogador();
            Game.TabGame = new Tabu();

            //Ocultar temporariamente o Menu e armazene seu ponteiro.
            Defenicoes Defenicoes = new Defenicoes();
            Defenicoes.Location = Location;
            Defenicoes.Show();
            Hide();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            // Encerra a solução por inteiro
            Application.Exit();
        }

        private void Estatisticas_Click(object sender, EventArgs e)
        {
            EstatisticasForm EstatisticasForm = new EstatisticasForm();
            EstatisticasForm.Location = Location;
            EstatisticasForm.Show();
            Hide();
        }
    }
}
