using Agenda_de_Contatos.Classe;
using Agenda_de_Contatos.Global;
using Agenda_de_Contatos.Service;
using Agenda_de_Contatos.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Telas
{
    internal class TelaModificarContato
    {
        public static void Mostrar(Contato contatoAntigo, string nome, string contato, ContatoType tipo)
        {
            Console.Write("//////////////////////////////////////////////////////\n");
            Console.WriteLine(contatoAntigo.ToString() + " <--- Antigo");
            Console.Write("//////////////////////////////////////////////////////\n");
            Console.WriteLine($"Nome: {nome}\n" +
                              $"Contato: {contato}\n" +
                              $"Tipo: {tipo}");
        }
    }
}
