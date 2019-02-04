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
    static class GraphicContext
    {
        static private readonly Bitmap hitImage = new Bitmap(Properties.Resources.TanqHit);
        static private readonly Bitmap TanqImage = new Bitmap(Properties.Resources.Tanq);
        static public readonly Bitmap deckImages = new Bitmap(Properties.Resources.Mapa);

        static GraphicContext()
        {
            deckImages = new Bitmap(Properties.Resources.Mapa);
        }


        // Configurações de opacidade.
        private static readonly int generalOpacity = 150;
        private static readonly int spacialOpacity = 200;
        public static readonly Brush[] colors = new SolidBrush[8]
        {
            new SolidBrush(Color.FromArgb(generalOpacity, 255, 255, 0)),   // [0] Yellow
            new SolidBrush(Color.FromArgb(generalOpacity, 255, 0, 0)),     // [1] Red
            new SolidBrush(Color.FromArgb(generalOpacity, 0, 255, 0)),     // [2] Green
            new SolidBrush(Color.FromArgb(generalOpacity, 0, 0, 255)),     // [3] Blue
            new SolidBrush(Color.FromArgb(generalOpacity, 150, 0, 200)),   // [4] Violet
            new SolidBrush(Color.FromArgb(spacialOpacity, 255, 255, 255)), // [5] White
            new SolidBrush(Color.FromArgb(spacialOpacity, 0, 255, 255)),   // [6] Azure
            new SolidBrush(Color.FromArgb(spacialOpacity, 255, 0, 140))    // [7] Magenta
        };

        static public int GetCoorX(Form form, PictureBox deckPictureBox)
        {
            int borderWidth = (form.Width - form.ClientSize.Width) / 2;
            int coorX = Control.MousePosition.X - form.Location.X - deckPictureBox.Location.X - borderWidth;
            return (coorX < 33 || coorX > 342) ? -1 : coorX;
        }

        static public int GetCoorY(Form form, PictureBox deckPictureBox)
        {
            int borderWidth = (form.Width - form.ClientSize.Width) / 2;
            int titleBarHeight = form.Height - form.ClientSize.Height - 2 * borderWidth;
            int coorY = Control.MousePosition.Y - form.Location.Y - deckPictureBox.Location.Y - titleBarHeight - borderWidth;
            return (coorY < 33 || coorY > 342) ? -1 : coorY;
        }

        static public int GetCell(int coor)
        {
            return (coor - 33) / 31;
        }

        // PictureBox paint event handler para desenhar uma célula colorida.
        static public void DrawColoredCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(GraphicContext.colors[color], (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1, 30, 30);
        }

        static public void DrawHitCell(int cellX, int cellY, Form form, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            g.DrawImage(hitImage, (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1);
        }

        // PictureBox paint event handler para desenhar uma célula de sucesso.
        static public void DrawHitCell(int cellX, int cellY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hitImage, (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1);
        }


        static public void DrawInnerFrameCell(int cellX, int cellY, int color, Form form, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            Pen framePen = new Pen(colors[color], 3);
            g.DrawRectangle(framePen, (cellX + 1) * 31 + 3, (cellY + 1) * 31 + 3, 25, 25);
        }

        static public void DrawOuterFrameCell(int cellX, int cellY, int color, Form form, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            Pen framePen = new Pen(colors[color], 3);
            g.DrawRectangle(framePen, (cellX + 1) * 31 + -3, (cellY + 1) * 31 + -3, 37, 37);
        }

        // PictureBox paint event handler para desenhar uma moldura externa em torno de uma célula.
        static public void DrawOuterFrameCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            Pen framePen = new Pen(colors[color], 3);
            e.Graphics.DrawRectangle(framePen, (cellX + 1) * 31 + -3, (cellY + 1) * 31 + -3, 37, 37);
        }

        // PictureBox paint event handler para desenhar um quadro interno em torno de uma célula.
        static public void DrawInnerFrameCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            Pen framePen = new Pen(colors[color], 3);
            e.Graphics.DrawRectangle(framePen, (cellX + 1) * 31 + 3, (cellY + 1) * 31 + 3, 25, 25);
        }

        // PictureBox paint event handler para desenhar comboio no tabuleiro.
        static public void DrawCombSet(int[,] CombSet, PaintEventArgs e)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (CombSet[x, y] != -1)
                    {
                        DrawCombCell(x, y, CombSet[x, y], e);
                    }
                }
            }
        }

        static public void DrawCombCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            e.Graphics.DrawImage(TanqImage, (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1);
        }

        // PictureBox paint event handler para desenhar um status no tabuleiro de todas as células.
        static public void DrawDeckStatus(bool[,] deckStatus, int[,] CombSet, PaintEventArgs e)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (deckStatus[x, y])
                    {
                        if (CombSet[x, y] != -1)
                        {
                            DrawHitCell(x, y, e);
                        }
                    }
                }
            }
        }

        // PictureBox paint event handler para desenhar os combios destruidos
        static public void DrawSunkenShips(int[,] CombSet, int[] ComboiosLeftCells, PaintEventArgs e)
        {
            for (int CombSelec = 0; CombSelec < 4; CombSelec++)
            {
                if (ComboiosLeftCells[CombSelec] == 0)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (CombSet[x, y] == CombSelec)
                            {
                                DrawColoredCell(x, y, CombSelec, e);
                            }
                        }
                    }
                }
            }
        }
    }
}
