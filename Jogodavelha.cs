using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_Da_Velha
{
    public partial class Form1 : Form
    {
        string[,] mat = new string[3, 3];
        string jogadoratual = "X";
        int contadorJogadas = 0;

        public Form1()
        {
            InitializeComponent();
            matriz_iniciar();
            atualizar_jogo();
        }

        private void matriz_iniciar()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mat[i, j] = " ";
                }
            }
            contadorJogadas = 0; 
        }

        private void atualizar_jogo()
        {
            lblTabuleiro.Text = $"{mat[0, 0]} | {mat[0, 1]} | {mat[0, 2]}\n" +
                                $"{mat[1, 0]} | {mat[1, 1]} | {mat[1, 2]}\n" +
                                $"{mat[2, 0]} | {mat[2, 1]} | {mat[2, 2]}";
            lblJogador.Text = jogadoratual;
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            if (contadorJogadas >= 9)
            {
                MessageBox.Show("DEU VEIA!");
                return;
            }

            int linha = int.Parse(txtLinha.Text) - 1;
            int coluna = int.Parse(txtColuna.Text) - 1;

            if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2 || mat[linha, coluna] != " ")
            {
                MessageBox.Show("DIGITE UM NÚMERO VALIDO");
                return;
            }

            mat[linha, coluna] = jogadoratual;
            contadorJogadas++; 

            if (venceu())
            {
                MessageBox.Show("O JOGADOR " + jogadoratual + " VENCEU!");
                matriz_iniciar();
                return;
            }
            else if (empatou())
            {
                MessageBox.Show("EMPATOU");
                matriz_iniciar();
                return;
            }

            if (jogadoratual == "X")
            {
                jogadoratual = "O";
            }
            else
            {
                jogadoratual = "X";
            }

            atualizar_jogo();
        }

        private bool venceu()
        {
          
            for (int i = 0; i < 3; i++)
            {
                if (mat[i, 0] == jogadoratual && mat[i, 1] == jogadoratual && mat[i, 2] == jogadoratual)
                    return true;
            }

            
            for (int j = 0; j < 3; j++)
            {
                if (mat[0, j] == jogadoratual && mat[1, j] == jogadoratual && mat[2, j] == jogadoratual)
                    return true;
            }

            
            if (mat[0, 0] == jogadoratual && mat[1, 1] == jogadoratual && mat[2, 2] == jogadoratual)
                return true;

            if (mat[0, 2] == jogadoratual && mat[1, 1] == jogadoratual && mat[2, 0] == jogadoratual)
                return true;

            return false;
        }

        private bool empatou()
        {
      
            foreach (var pos in mat)
            {
                if (pos == " ")
                    return false;
            }
 
            if (!venceu())
                return true;

            return false;
        }
    }
}