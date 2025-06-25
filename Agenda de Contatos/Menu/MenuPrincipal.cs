using Agenda_de_Contatos.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Menu
{
    class MenuPrincipal
    {
        public int Escolha(int qtdContatos)
        {
            string resposta = " ";
            //Repostas consideradas validas
            char[] respostasValidadas = ['1', '2', '3'];

            while (!respostasValidadas.Contains(resposta[0]))
            {
                TelaPrincipal.QtdContatos(qtdContatos);
                TelaPrincipal.MenuInicial();
                
                resposta = (Console.ReadLine()!);

                //Checa se o primeiro digito e numerico
                if (!String.IsNullOrEmpty(resposta))
                {
                    if (!Char.IsDigit(resposta[0]))
                    {
                        Console.WriteLine("Digito não e número (aperte qualquer tecla para continuar).");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    //Checa se o numero e valido 
                    else if (!respostasValidadas.Contains(resposta[0]))
                    {
                        Console.WriteLine("Digito não e uma opção (aperte qualquer tecla para continuar).");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    resposta = " ";
                    Console.Clear();
                }
            }

            return int.Parse(resposta);
        }
    }
}
