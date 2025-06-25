using Agenda_de_Contatos.Classe;
using Agenda_de_Contatos.Global;
using Agenda_de_Contatos.Telas;
using Agenda_de_Contatos.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Menu
{
    internal class CriacaoContato
    {
        //Cria o contato e adiciona na lista 
        public Contato Criacao(Inicializacao inicializacao)
        {
            string name = "";
            string numero = "";
            int tipo = -1;
            while (true)
            {
                Console.Clear();
                TelaCriacao.InfoContato(name, numero, DefinirTipo(tipo));               

                Console.Write("Nome: ");
                name = Console.ReadLine()!;

                Console.WriteLine();

                while (numero.Length != 8)
                {
                    Console.Clear();
                    TelaCriacao.InfoContato(name, numero, DefinirTipo(tipo));
                    Console.Write("Numero (8 numeros): ");
                    numero = Console.ReadLine()!;
                }

                while (tipo < 0 || tipo > 4)
                {
                    string tipoStr = "";
                    Console.Clear();
                    TelaCriacao.InfoContato(name, numero, DefinirTipo(tipo));
                    TelaCriacao.InfoTipoContato();
                    Console.Write("Tipo de contato: ");
                    tipoStr = Console.ReadLine()!;

                    if (!String.IsNullOrEmpty(tipoStr))
                    {
                        if (!Char.IsDigit(tipoStr[0]))
                        {
                            Console.WriteLine("Digito não e número (aperte qualquer tecla para continuar).");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        tipo = int.Parse(tipoStr!) - 1;

                        if (tipo < 0 || tipo > 4)
                        {
                            Console.WriteLine("Digito não e uma opção (aperte qualquer tecla para continuar).");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }                   
                }

                Console.Clear();
                TelaCriacao.InfoContato(name, numero, DefinirTipo(tipo));
                //Caso selecione não o usuario e levado de volta ao menu principal e o contato não e criado 
                Console.Write("Contato esta correto ? (S/N)");
                string respota = Console.ReadLine()!.ToLower();

                if (respota == "s")
                {
                    int id = inicializacao.globalData.NewId(inicializacao.globalData.listaContatos);
                    Contato contato = new(id, name, numero, DefinirTipo(tipo)) { };
                    return contato;
                }
                else
                {
                    return null;
                }
            }            
        }

        //Define o tipo de contato
        public ContatoType DefinirTipo(int numero)
        {
            switch (numero)
            {
                case 0:
                    return ContatoType.Casa;

                case 1:
                    return ContatoType.Familia;

                case 2:
                    return ContatoType.Amigo;

                case 3:
                    return ContatoType.Trabalho;

                case 4:
                    return ContatoType.Servico;

                default:
                    return ContatoType.Casa;
            }
        }
    }
}
