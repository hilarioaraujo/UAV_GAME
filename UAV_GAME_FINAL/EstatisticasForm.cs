using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UAV_GAME_FINAL
{
    public partial class EstatisticasForm : Form
    {
        //public string[] LinhasTxt { get; set; }

        public EstatisticasForm()
        {
            InitializeComponent();
            LerTodasEstatisticas();
        }

        private void LerTodasEstatisticas()
        {
            List<Estatisticas> ListaEstatisticas = new List<Estatisticas>();

            //Lê todas as linhas do ficheiro TXT "EstatisticasJogo.txt"
            string[] LinhasTxt = File.ReadAllLines("EstatisticasJogo.txt", Encoding.Default);
            int numLinhasTxt = LinhasTxt.Length - 1;
            int j = 0;
            while (j <numLinhasTxt)
            {
                //Adiciona uma nova estatistica
                ListaEstatisticas.Add(new Estatisticas(LinhasTxt[j], Convert.ToInt32(LinhasTxt[j + 1])));
                j = j + 2;
            }

            //cria uma nova lista 
            List<Estatisticas> NovaListaEstatisticas;

            //Ordena decrescentemente a lista anterior
            NovaListaEstatisticas = ListaEstatisticas.OrderByDescending(x => x.Cotacao).ToList();

            //Faz com que o tamnho das colunas seja o tamanho da tabela/2
            Tabela.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            //Coloca a nova lista na DataGridView - Tabela
            Tabela.DataSource = NovaListaEstatisticas;
            
            //Coloca a descreição de cada coluna
            Tabela.Columns[0].HeaderText = "Nome do Jogador";
            Tabela.Columns[1].HeaderText = "Cotação do Jogador";
        }


        private void EstatisticasForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Limpar_Click(object sender, EventArgs e)
        {
            CriarFicheiroTXT.ResetEstatisticas();
            LerTodasEstatisticas();
        }
    }
}
