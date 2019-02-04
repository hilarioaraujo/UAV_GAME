using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace UAV_GAME_FINAL
{
    static class GlobalContext
    {
        // Reference to the main menu form instance.
        public static Menu MainMenuForm { get; set; }

        // Método para gerar números aleatórios em função do intervalo [0,max]
        public static int RandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(max);
        }
    }

    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia o menu principal e executa o aplicativo.
            Menu mainMenuForm = new Menu();
            GlobalContext.MainMenuForm = mainMenuForm;
            Application.Run(mainMenuForm);

        }
    }
}
