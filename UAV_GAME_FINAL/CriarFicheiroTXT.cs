using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UAV_GAME_FINAL
{
    class CriarFicheiroTXT
    {
        public static string Diretorio = "";
        public static FileStream fs;

        static public bool CriarFicheiro()
        {
            ////declaração da variavel do tipo StreamWriter para 
            //abrir ou criar um arquivo para escrita 
            StreamWriter x = new StreamWriter(fs);


            //escrevendo o titulo
            x.WriteLine("Registo da Operação");
            //deixar linha em branco
            x.WriteLine();
            x.WriteLine(Game.TabGame.DimLinhas + " " + Game.TabGame.DimColunas);
            x.WriteLine();

            //Para saber se Já Houve algum Veiculo da mesma linha a ser colado
            bool Existe = false;

            //Para saber se Na linha que foi vista pelo ciclo se havia algum veículo
            bool Existiu = false;

            for (int i=0; i<10;i++)
            {
                for(int j=0; j<10; j++)
                {
                    //Se existe algum Veículo na posição [j,i]
                    if(Game.TabGame.CombSet[j,i]>=0)
                    {
                        if (Existe)
                        {
                            x.Write(Game.letterLabels[i] + Game.numberLables[j]);
                            Existe = false;
                        }
                        else
                        {
                            x.Write(" " + Game.letterLabels[i] + Game.numberLables[j] );
                        }
                        Existiu = true;
                            
                    }
                }
                Existe = false;
                if (Existiu)
                {
                    x.WriteLine(" ");
                }
                Existiu = false;

            }
            x.WriteLine(" ");

            x.WriteLine("Registo das Ações dos Jogadores");

            x.WriteLine(Game.TabGame.BattleLog);

            //fechando o arquivo texto com o método .Close()
            x.Close();
            return true;
        }

        //Criar um documento TxT de Estatisticas com a cotação deste jogo
        static public void CriarEstatisticas(Jogador Jogadora, Jogador Jogadorb)
        {
            List<Estatisticas> ListaEstatisticas = new List<Estatisticas>();

            //Lê todas as linhas do ficheiro TXT "EstatisticasJogo.txt"
            string[] LinhasTxt = File.ReadAllLines("EstatisticasJogo.txt", Encoding.Default);
            int numLinhasTxt = LinhasTxt.Length - 1;
            int j = 0;
            while (j < numLinhasTxt)
            {
                //Adiciona uma lista de  estatistica
                ListaEstatisticas.Add(new Estatisticas(LinhasTxt[j], Convert.ToInt32(LinhasTxt[j + 1])));
                j = j + 2;
            }

            int i = 0;
            bool SelecaoJogador1 = false;
            bool SelecaoJogador2 = false;

            StreamWriter writer = new StreamWriter("EstatisticasJogo.txt");

            //Verefica se existe algum Jogador com o nome dos Jogadores que jogaram neste jogo e se houver atualiza a cotação do mesmo
            //Adiciona a lista a um novo ficheiro TXT.
            while (i < ListaEstatisticas.Count)
            {
                if(String.Equals(Jogadora.Nome, ListaEstatisticas[i].Nome))
                {
                    ListaEstatisticas[i].Cotacao = ListaEstatisticas[i].Cotacao + Jogadora.Cotacao;
                    SelecaoJogador1 = true;
                    i++;
                }
                if (String.Equals(Jogadorb.Nome, ListaEstatisticas[i].Nome))
                {
                    ListaEstatisticas[i].Cotacao = ListaEstatisticas[i].Cotacao + Jogadorb.Cotacao;
                    SelecaoJogador2 = true;
                    i++;
                }
                i++;
            }

            if (!SelecaoJogador1)
            {
                    writer.WriteLine(Jogadora.Nome);
                    writer.WriteLine(Jogadora.Cotacao);
            }

            if (!SelecaoJogador2)
            {
                writer.WriteLine(Jogadorb.Nome);
                writer.WriteLine(Jogadorb.Cotacao);
            }

            j = 0;
            while (j < ListaEstatisticas.Count)
            {
                writer.WriteLine(Convert.ToString(ListaEstatisticas[j].Nome));
                if (j==ListaEstatisticas.Count-1)
                {
                    writer.Write(Convert.ToString(ListaEstatisticas[j].Cotacao));
                }
                else
                {
                    writer.WriteLine(Convert.ToString(ListaEstatisticas[j].Cotacao));
                }
                
                j++;
            }

            writer.Close();
            return;
        }

        static public void ResetEstatisticas()
        {
            StreamWriter writer = new StreamWriter("EstatisticasJogo.txt");
            writer.Close();
            return;
        }
    }
}
