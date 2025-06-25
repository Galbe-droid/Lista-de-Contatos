using Agenda_de_Contatos.Classe;
using Agenda_de_Contatos.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Telas
{
    class TelaPrincipal
    {
        //Mostra a quantidade de contatos no menu principal 
        public static void QtdContatos(int quantidadeContatos)
        {
            Console.WriteLine($"Agenda de contatos - Quantidade de contatos {quantidadeContatos}");
        }

        public static void MenuInicial()
        {
            Console.Write($"Opções: \n" +
                          $"1 - Ver Contatos \n" +
                          $"2 - Adicinar Contatos \n" +
                          $"3 - Sair \n" +
                          $"Resposta (Sera apenas considerado o primeiro digito): ");
        }
    }
}
