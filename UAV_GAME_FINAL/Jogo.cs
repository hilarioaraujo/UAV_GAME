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
    public partial class Jogo : Form
    {
        int mouseCellX;
        int mouseCellY;
        int[] IAmove = { 0, 0 };

        Jogador JogadorQueJoga; 
        Jogador JogadorQueNaoJoga;
        

        public Jogo()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (Game.TabGame.CellsTrancadas[x, y]==true)
                    {
                        Game.TabGame.CellsTrancadasDepoisJogar[x, y] = true;
                    }
                    else
                    {
                        Game.TabGame.CellsTrancadasDepoisJogar[x, y] = false;
                    }
                    
                }
            }
            InitializeComponent();
            // Disable maximalization button on the title bar.
            MaximizeBox = false;
            // Set the location of the form to the center of the screen.
            CenterToScreen();

            //Coloca os nomes dos jogadores junto aos respetivos quadros de estatísticas
            Nome1.Text = Game.Jogador1.Nome;
            Nome2.Text = Game.Jogador2.Nome;

            


            DeckPictureBox.Image = GraphicContext.deckImages;

            Game.roundCount++;
            mouseCellX = -1;
            mouseCellY = -1;
            RedrawStatistics();

            // Muda o titulo consuante o Jogador que for a jogar.
            if (Game.SwitchJogador)
            {
                Text = "Battleships: " + Game.Jogador1.Nome + "’s turn";
                JogadorQueJoga = Game.Jogador1;
                JogadorQueNaoJoga = Game.Jogador2;
            }
            else
            {
                Text = "Battleships: " + Game.Jogador2.Nome + "’s turn";
                JogadorQueJoga = Game.Jogador2;
                JogadorQueNaoJoga = Game.Jogador1;
            }

            if (JogadorQueJoga.IA)
            {
                IAImplementacao();
                Game.roundCount++;
                RedrawStatistics();

                if (Game.SwitchJogador)
                {
                    Text = "Battleships: " + Game.Jogador1.Nome + "’s turn";
                    JogadorQueJoga = Game.Jogador1;
                    JogadorQueNaoJoga = Game.Jogador2;
                }
                else
                {
                    Text = "Battleships: " + Game.Jogador2.Nome + "’s turn";
                    JogadorQueJoga = Game.Jogador2;
                    JogadorQueNaoJoga = Game.Jogador1;
                }

                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (Game.TabGame.CellsTrancadas[x, y] == true)
                        {
                            Game.TabGame.CellsTrancadasDepoisJogar[x, y] = true;
                        }
                        else
                        {
                            Game.TabGame.CellsTrancadasDepoisJogar[x, y] = false;
                        }

                    }
                }
                return;
            }
            
        }

        public void IAImplementacao()
        {
            //Ia escolhe para onde deseja jogar
            IAmove = AtaqueIA.AIChooseCellToHit(JogadorQueJoga);

            // Verifica se o jogo já terminou?
            if (Game.PerformAttack(IAmove[0], IAmove[1], JogadorQueJoga, JogadorQueNaoJoga))
            {
                //Verificação para saber quem ganhou o jogo
                if (JogadorQueJoga.Misseis == 0)
                {
                    //Não permite que seja selecionada mais nenhuma célula
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            Game.TabGame.CellsTrancadasDepoisJogar[x, y] = true;
                        }
                    }

                    //Vereficação para saber se para além do Jogador que joga, se o jogador que não joga também ficou sem misseis
                    if (JogadorQueNaoJoga.Misseis == 0)
                    {
                        JogadorQueJoga.Cotacao = -1;
                        JogadorQueNaoJoga.Cotacao = -1;
                        RedrawStatistics();
                        MessageBox.Show("O jogo acabou com empate." + " Em " + Game.roundCount + " rondas!" + " O " + JogadorQueJoga.Nome + " e " + JogadorQueNaoJoga.Nome
                            + " acabaram os misséis que disponha para atacar os veículos antes de os destruirem a todos.", "UAV GAME: O Jogo Terminou!");

                        DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        if (confirm.ToString().ToUpper() == "YES")
                        {
                            ChooseFolder();
                            if (CriarFicheiroTXT.CriarFicheiro())
                            {
                                MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                            }

                        }

                    }

                    //Caso contrário Só o jogador que joga é que acabou com os seus misseis
                    else
                    {
                        JogadorQueJoga.Cotacao = -1;
                        JogadorQueNaoJoga.Cotacao = 1;
                        RedrawStatistics();


                        MessageBox.Show("Parabéns " + JogadorQueNaoJoga.Nome + "! Acabou de ganhar ao jogador " + JogadorQueJoga.Nome + " em " + Game.roundCount + " rondas! " + " O " + JogadorQueJoga.Nome
                            + " acabou os misséis que disponha para atacar os veículos.", "UAV GAME: O Jogo Terminou!");


                        DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        if (confirm.ToString().ToUpper() == "YES")
                        {
                            ChooseFolder();
                            if (CriarFicheiroTXT.CriarFicheiro())
                            {
                                MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                            }

                        }
                    }
                }

                //Caso nenhuma vereficação de cima aconteça o Jogo acaba pq foi destruido o último veículo
                else
                {
                    //Não permite que seja selecionada mais nenhuma célula
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            Game.TabGame.CellsTrancadasDepoisJogar[x, y] = true;
                        }
                    }

                    JogadorQueJoga.Cotacao = -1;
                    JogadorQueNaoJoga.Cotacao = 1;

                    // Redesenha o Tabuleiro final
                    DeckPictureBox.Refresh();
                    RedrawStatistics();
                    MessageBox.Show("Parabéns " + JogadorQueNaoJoga.Nome + "! Acabou de ganhar ao jogador " + JogadorQueJoga.Nome + " em " + Game.roundCount + " rondas! " +
                        " O " + JogadorQueJoga.Nome + " acabou por destruir o último veículo do Jogo", "UAV GAME: O Jogo Terminou!");


                    //Questiona o utilizador se pretende guardar o registo do jogo
                    DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (confirm.ToString().ToUpper() == "YES")
                    {
                        ChooseFolder();
                        if (CriarFicheiroTXT.CriarFicheiro())
                        {
                            MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                        }

                    }

                }

                CriarFicheiroTXT.CriarEstatisticas(JogadorQueJoga, JogadorQueNaoJoga);
            }

            else
            {
                //    // Troca de Jogaro
                //    Dispose();
                Game.SwitchJogador = !Game.SwitchJogador;
                //    // Continua o jogo
                //    Jogo jogo = new Jogo
                //    {
                //        Location = Location
                //    };
                //    jogo.Show();
                //    Dispose();

            }
        }


        private void RedrawStatistics()
        {

            TextRound.Text = Game.roundCount.ToString();
            TextRound.Refresh();

            VeicDestr1.Text = Game.Jogador1.Hits.ToString();
            VeicDestr1.Refresh();

            Misseis1.Text = Game.Jogador1.Misseis.ToString();
            Misseis1.Refresh();

            Cotacao1.Text = Game.Jogador1.Cotacao.ToString();
            Cotacao1.Refresh();

            Racio1.Text = Game.Jogador1.HitRatio.ToString();
            Racio1.Refresh();

            VeicDestr2.Text = Game.Jogador2.Hits.ToString();
            VeicDestr2.Refresh();

            Misseis2.Text = Game.Jogador2.Misseis.ToString();
            Misseis2.Refresh();

            Cotacao2.Text = Game.Jogador2.Cotacao.ToString();
            Cotacao2.Refresh();

            Racio2.Text = Game.Jogador2.HitRatio.ToString();
            Racio2.Refresh();

            LeftVeic1.Text = Game.TabGame.VeiculosLeft.ToString();
            battleLogRichTextBox.Text = Game.TabGame.BattleLog;
            battleLogRichTextBox.Refresh();
            battleLogRichTextBox.ScrollToCaret();
        }

        private void DeckPictureBoxClick(object sender, EventArgs e)
        {
            if (mouseCellX != -1 && mouseCellY != -1 && !Game.TabGame.CellsTrancadasDepoisJogar[mouseCellX, mouseCellY])
            {
                // Verifica se o jogo já terminou?
                if (Game.PerformAttack(mouseCellX, mouseCellY, JogadorQueJoga, JogadorQueNaoJoga))
                {
                    //Verificação para saber quem ganhou o jogo
                    if (JogadorQueJoga.Misseis == 0)
                    {
                        //Não permite que seja selecionada mais nenhuma célula
                        for (int x = 0; x < 10; x++)
                        {
                            for (int y = 0; y < 10; y++)
                            {
                                Game.TabGame.CellsTrancadasDepoisJogar[x, y] = true;
                            }
                        }

                        //Vereficação para saber se para além do Jogador que joga, se o jogador que não joga também ficou sem misseis
                        if (JogadorQueNaoJoga.Misseis == 0)
                        {
                            JogadorQueJoga.Cotacao = -1;
                            JogadorQueNaoJoga.Cotacao = -1;
                            RedrawStatistics();
                            MessageBox.Show("O jogo acabou com empate." + " Em " + Game.roundCount + " rondas!" + " O " + JogadorQueJoga.Nome + " e " + JogadorQueNaoJoga.Nome
                                + " acabaram os misséis que disponha para atacar os veículos antes de os destruirem a todos.", "UAV GAME: O Jogo Terminou!");

                            DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                            if (confirm.ToString().ToUpper() == "YES")
                            {
                                ChooseFolder();
                                if (CriarFicheiroTXT.CriarFicheiro())
                                {
                                    MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                                }

                            }

                        }

                        //Caso contrário Só o jogador que joga é que acabou com os seus misseis
                        else
                        {
                            JogadorQueJoga.Cotacao = -1;
                            JogadorQueNaoJoga.Cotacao = 1;
                            RedrawStatistics();


                            MessageBox.Show("Parabéns " + JogadorQueNaoJoga.Nome + "! Acabou de ganhar ao jogador " + JogadorQueJoga.Nome + " em " + Game.roundCount + " rondas! " + " O " + JogadorQueJoga.Nome
                                + " acabou os misséis que disponha para atacar os veículos.", "UAV GAME: O Jogo Terminou!");


                            DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                            if (confirm.ToString().ToUpper() == "YES")
                            {
                                ChooseFolder();
                                if (CriarFicheiroTXT.CriarFicheiro())
                                {
                                    MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                                }

                            }
                        }
                    }

                    //Caso nenhuma vereficação de cima aconteça o Jogo acaba pq foi destruido o último veículo
                    else
                    {
                        //Não permite que seja selecionada mais nenhuma célula
                        for (int x = 0; x < 10; x++)
                        {
                            for (int y = 0; y < 10; y++)
                            {
                                Game.TabGame.CellsTrancadasDepoisJogar[x, y] = true;
                            }
                        }

                        JogadorQueJoga.Cotacao = -1;
                        JogadorQueNaoJoga.Cotacao = 1;

                        // Redesenha o Tabuleiro final
                        DeckPictureBox.Refresh();
                        RedrawStatistics();
                        MessageBox.Show("Parabéns " + JogadorQueNaoJoga.Nome + "! Acabou de ganhar ao jogador " + JogadorQueJoga.Nome + " em " + Game.roundCount + " rondas! " +
                            " O " + JogadorQueJoga.Nome + " acabou por destruir o último veículo do Jogo", "UAV GAME: O Jogo Terminou!");


                        //Questiona o utilizador se pretende guardar o registo do jogo
                        DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        if (confirm.ToString().ToUpper() == "YES")
                        {
                            ChooseFolder();
                            if (CriarFicheiroTXT.CriarFicheiro())
                            {
                                MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                            }

                        }

                    }

                    CriarFicheiroTXT.CriarEstatisticas(JogadorQueJoga, JogadorQueNaoJoga);
                }

                //Caso contrário o jogo ainda não acabou
                else
                {
                    JogadorQueJoga.JaJogou = true;
                    RedrawStatistics();

                    //O jogo ainda não terminou
                    // Redesenha o Tabuleiro
                    DeckPictureBox.Refresh();

                    if (!Game.ExisteMaisVeicLinha(mouseCellY))
                    {
                        //Qual é o modo do jogo
                        switch (Game.gameMode)
                        {
                            //Tipo de Jogo: 0 - Humano vs Humano
                            case 0:
                                if (!Game.SwitchJogador)
                                {
                                    // O jogador 2 já jogou;
                                    // Incrementa o valor 1 ao nº de rondas já executadas
                                    //Game.roundCount++;
                                }

                                // Troca de Jogaro
                                Dispose();
                                Game.SwitchJogador = !Game.SwitchJogador;

                                // Continua o jogo
                                Jogo jogo = new Jogo
                                {
                                    Location = Location
                                };
                                jogo.Show();
                                Dispose();

                                return;


                            //Tipo de Jogo: 1 Maquina vs Maquina
                            case 1:
                                break;


                            //Tipo de Jogo: 2-Máquina vs Humano, Humano vs Máquina
                            case 2:
                                if (!Game.SwitchJogador)
                                {
                                    // O jogador 2 já jogou;
                                    // Incrementa o valor 1 ao nº de rondas já executadas
                                    //Game.roundCount++;
                                }
                                Game.SwitchJogador = !Game.SwitchJogador;
                                break;
                        }
                    }
                }
            }
            else
                return;
        }




        private void DeckPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            // Are we on the grid of the first deck?
            if (GraphicContext.GetCoorX(this, DeckPictureBox) != -1 && GraphicContext.GetCoorY(this, DeckPictureBox) != -1)
            {
                // Have the cell selected by mouse changed?
                if (GraphicContext.GetCell(GraphicContext.GetCoorX(this, DeckPictureBox)) != mouseCellX || GraphicContext.GetCell(GraphicContext.GetCoorY(this, DeckPictureBox)) != mouseCellY)
                {
                    // Update the cell selected by mouse.
                    mouseCellX = GraphicContext.GetCell(GraphicContext.GetCoorX(this, DeckPictureBox));
                    mouseCellY = GraphicContext.GetCell(GraphicContext.GetCoorY(this, DeckPictureBox));

                    // Repaint the first deck.
                    DeckPictureBox.Refresh();
                    // Draw the outer frame of the selected cell.

                    if (Game.SwitchJogador)
                    {
                        GraphicContext.DrawOuterFrameCell(mouseCellX, mouseCellY, Game.Jogador1.CorEsc, this, DeckPictureBox);
                    }
                    else
                    {
                        GraphicContext.DrawOuterFrameCell(mouseCellX, mouseCellY, Game.Jogador2.CorEsc, this, DeckPictureBox);
                    }

                    
                }
            }
            else
            {
                // Unselect the cell in the first deck.
                mouseCellX = -1;
                mouseCellY = -1;

                // Repaint the first deck.
                DeckPictureBox.Refresh();
            }
        }

        private void DeckPictureBoxPaint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawCombSet(Game.TabGame.CombSet, e);

            GraphicContext.DrawDeckStatus(Game.TabGame.CellsTrancadas, Game.TabGame.CombSet, e);

            for (int x = 0; x == 10; x++)
            {
                for (int y = 0; y == 10; y++)

                    if (Game.TabGame.CombSituacao[x, y] == 1)
                    {
                        GraphicContext.DrawColoredCell(x, y, Game.Jogador1.CorEsc, e);

                    }
                    else
                    {
                        if (Game.TabGame.CombSituacao[x, y] == 2)
                        {
                            GraphicContext.DrawColoredCell(x, y, Game.Jogador2.CorEsc, e);
                        }
                        else
                        {
                            GraphicContext.DrawInnerFrameCell(x, y, Game.Jogador2.CorEsc, e);
                        }
                    }
            }

        }

        private void Jogo_Closing(object sender, FormClosingEventArgs e)
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

        private void Troca_Click(object sender, EventArgs e)
        {
            //Vereficação para saber se o jogador já hogou antes de passar a vez.
            
                switch (Game.gameMode)
                {
                    //Tipo de Jogo: 0 - Humano vs Humano
                    case 0:
                        if (JogadorQueJoga.JaJogou == true)
                        {
                            JogadorQueJoga.JaJogou = false;
                            // Troca de Jogaro
                            Dispose();
                            Game.SwitchJogador = !Game.SwitchJogador;

                            // Continua o jogo
                            Jogo jogo = new Jogo
                            {
                                Location = Location
                            };
                            jogo.Show();
                            Dispose();
                        return;
                        }
                        else
                        {
                            MessageBox.Show("Terá de jogar primeiro antes de passar a sua vez ao adversário!");
                            return;
                        }


                    //Tipo de Jogo: 1 Maquina vs Maquina
                    case 1:
                        break;


                    //Tipo de Jogo: 2-Máquina vs Humano, Humano vs Máquina
                    case 2:
                        if (!Game.SwitchJogador)
                        {
                            // O jogador 2 já jogou;
                            // Incrementa o valor 1 ao nº de rondas já executadas
                            //Game.roundCount++;
                        }

                        Game.SwitchJogador = !Game.SwitchJogador;

                        //Ia escolhe para onde deseja jogar
                        IAmove = AtaqueIA.AIChooseCellToHit(JogadorQueJoga);

                        // Verifica se o jogo já terminou?
                        if (Game.PerformAttack(IAmove[0], IAmove[1], JogadorQueJoga, JogadorQueNaoJoga))
                        {
                            //Verificação para saber quem ganhou o jogo
                            if (JogadorQueJoga.Misseis == 0)
                            {
                                //Não permite que seja selecionada mais nenhuma célula
                                for (int x = 0; x < 10; x++)
                                {
                                    for (int y = 0; y < 10; y++)
                                    {
                                        Game.TabGame.CellsTrancadasDepoisJogar[x, y] = true;
                                    }
                                }

                                //Vereficação para saber se para além do Jogador que joga, se o jogador que não joga também ficou sem misseis
                                if (JogadorQueNaoJoga.Misseis == 0)
                                {
                                    JogadorQueJoga.Cotacao = -1;
                                    JogadorQueNaoJoga.Cotacao = -1;
                                    RedrawStatistics();
                                    MessageBox.Show("O jogo acabou com empate." + " Em " + Game.roundCount + " rondas!" + " O " + JogadorQueJoga.Nome + " e " + JogadorQueNaoJoga.Nome
                                        + " acabaram os misséis que disponha para atacar os veículos antes de os destruirem a todos.", "UAV GAME: O Jogo Terminou!");

                                    DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                                    if (confirm.ToString().ToUpper() == "YES")
                                    {
                                        ChooseFolder();
                                        if (CriarFicheiroTXT.CriarFicheiro())
                                        {
                                            MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                                        }

                                    }

                                }

                                //Caso contrário Só o jogador que joga é que acabou com os seus misseis
                                else
                                {
                                    JogadorQueJoga.Cotacao = -1;
                                    JogadorQueNaoJoga.Cotacao = 1;
                                    RedrawStatistics();


                                    MessageBox.Show("Parabéns " + JogadorQueNaoJoga.Nome + "! Acabou de ganhar ao jogador " + JogadorQueJoga.Nome + " em " + Game.roundCount + " rondas! " + " O " + JogadorQueJoga.Nome
                                        + " acabou os misséis que disponha para atacar os veículos.", "UAV GAME: O Jogo Terminou!");


                                    DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                                    if (confirm.ToString().ToUpper() == "YES")
                                    {
                                        ChooseFolder();
                                        if (CriarFicheiroTXT.CriarFicheiro())
                                        {
                                            MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                                        }

                                    }
                                }
                            }

                            //Caso nenhuma vereficação de cima aconteça o Jogo acaba pq foi destruido o último veículo
                            else
                            {
                                //Não permite que seja selecionada mais nenhuma célula
                                for (int x = 0; x < 10; x++)
                                {
                                    for (int y = 0; y < 10; y++)
                                    {
                                        Game.TabGame.CellsTrancadasDepoisJogar[x, y] = true;
                                    }
                                }

                                JogadorQueJoga.Cotacao = -1;
                                JogadorQueNaoJoga.Cotacao = 1;

                                // Redesenha o Tabuleiro final
                                DeckPictureBox.Refresh();
                                RedrawStatistics();
                                MessageBox.Show("Parabéns " + JogadorQueNaoJoga.Nome + "! Acabou de ganhar ao jogador " + JogadorQueJoga.Nome + " em " + Game.roundCount + " rondas! " +
                                    " O " + JogadorQueJoga.Nome + " acabou por destruir o último veículo do Jogo", "UAV GAME: O Jogo Terminou!");


                                //Questiona o utilizador se pretende guardar o registo do jogo
                                DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                                if (confirm.ToString().ToUpper() == "YES")
                                {
                                    ChooseFolder();
                                    if (CriarFicheiroTXT.CriarFicheiro())
                                    {
                                        MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                                    }

                                }

                            }

                            CriarFicheiroTXT.CriarEstatisticas(JogadorQueJoga, JogadorQueNaoJoga);
                        }

                        else
                        {
                            // Troca de Jogaro
                            Dispose();
                            Game.SwitchJogador = !Game.SwitchJogador;

                            // Continua o jogo
                            Jogo Jogo = new Jogo
                            {
                                Location = Location
                            };
                            Jogo.Show();
                            Dispose();
                            return;
                        }
                        break;
                }
        }

        private void Gravar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Guardar Registo de Batalha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (confirm.ToString().ToUpper() == "YES")
            {
                ChooseFolder();
                if (CriarFicheiroTXT.CriarFicheiro())
                {
                    MessageBox.Show("Foi concluido com suceddo a gravação do Registo de Batalha");
                }

            }
        }

        public void ChooseFolder()
        {
            //Inicia o SaveFileDialog1 para saber onde o utilizador pretende guardar o ficheiro txt.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CriarFicheiroTXT.fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
            }
        }
    }
}
