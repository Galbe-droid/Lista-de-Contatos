using Agenda_de_Contatos.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Telas
{
    internal static class TelaCriacao
    {
        public static void InfoContato(string name, string numero, ContatoType type)
        {
            Console.WriteLine("//////////////////////////////////////////////////////\n");
            Console.WriteLine($"Informações do contato: \n" +
                              $"Nome: {name} \n" +
                              $"Numero: {numero} \n" +
                              $"Tipo: {type} \n");
            Console.WriteLine("//////////////////////////////////////////////////////\n");
        }

        public static void InfoTipoContato()
        {
            Console.WriteLine($"1 - Casa \n" +
                              $"2 - Familia \n" +
                              $"3 - Amigos \n" +
                              $"4 - Trabalho \n" +
                              $"5 - Serviço \n");
        }
    }
}
