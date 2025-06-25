using Agenda_de_Contatos.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Telas
{
    internal class TelaMostrarContatos
    {
        public static void Mostrar(List<Contato> lista, int pagina, decimal limitePagina)
        {
            Console.WriteLine($"Possui {lista.Count} contatos");
            Console.WriteLine($"////{pagina} - {limitePagina}////");
            for (int i = 0; i < 10; i++)
            {
                int paginaAtual = (pagina - 1) * 10;
                paginaAtual += i;
                if (paginaAtual > lista.Count -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(lista[paginaAtual].ToString());
                }                    
            }
        }
    }
}
