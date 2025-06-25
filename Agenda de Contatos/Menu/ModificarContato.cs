using Agenda_de_Contatos.Classe;
using Agenda_de_Contatos.Global;
using Agenda_de_Contatos.Service;
using Agenda_de_Contatos.Telas;
using Agenda_de_Contatos.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Menu
{
    internal class ModificarContato
    {
        //Script para modificar o contato
        public void Modificar(Inicializacao inicializacao, int id)
        {
            //Escolhas permitidas
            string[] escolhas = ["n", "c", "t", "f"];
            Contato contatoModificar = ContatosService.ReadById(inicializacao, id);
            string nomeContato = contatoModificar.Nome;
            string numeroContato = contatoModificar.ContatoNumero;
            ContatoType tipoContato = contatoModificar.Tipo;
            do
            {
                Console.Clear();                
                TelaModificarContato.Mostrar(contatoModificar, nomeContato, numeroContato, tipoContato);
                Console.Write("N - Modificar Nome\n" +
                              "C - Modificar Contato\n" +
                              "T - Modificar Tipo\n" +
                              "F - Finalizar\n");
                Console.Write("Escolha: ");
                string escolha = Console.ReadLine()!.ToLower();

                //Se a escolha não for nula e estiver dentro do array escolhas ele pode acessar as opções caso contrario essa pagina se reinicia
                if(!String.IsNullOrEmpty(escolha) && escolhas.Contains(escolha))
                {
                    switch (escolha)
                    {
                        //Coloca novo nome
                        case"n":
                            Console.Write("Novo nome: ");
                            nomeContato = Console.ReadLine()!;
                            break;

                        //Coloca Novo numero
                        case "c":
                            Console.Write("Novo numero: ");
                            numeroContato = Console.ReadLine()!;
                            break;

                        //Coloca novo tipo de contato
                        case "t":
                            int tipoEscolha = 0;
                            Console.WriteLine("Novo Tipo (Caso não seja escolhido nada o valor base e 1): ");
                            TelaCriacao.InfoTipoContato();
                            Console.Write("Escolha: ");
                            tipoContato = inicializacao.criacaoContato.DefinirTipo(tipoEscolha = int.Parse(Console.ReadLine()!) -1);
                            break;

                        //Finaliza as alterações e coloca ela na lista
                        case "f":
                            Contato novoContato = new(id, nomeContato, numeroContato, tipoContato);
                            ContatosService.Update(inicializacao, id, novoContato);
                            break;
                    }                    
                }
                //Caso a opção seja 'f' ele saira do loop e voltara ao menu principal
                if (escolha == "f") { break; }

            } while(true);
        }
    }
}
