using Agenda_de_Contatos.Classe;
using Agenda_de_Contatos.Global;
using Agenda_de_Contatos.Service;
using Agenda_de_Contatos.Telas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Menu
{
    internal class NavegarContato
    {
        public void Opcao(Inicializacao inicializacao)
        {
            ///Delimita paginas cada uma contendo 10 contatos
            int pagina = 1;
            decimal limitePagina = (inicializacao.globalData.listaContatos.Count < 10) ? 1 : Math.Ceiling(Convert.ToDecimal(inicializacao.globalData.listaContatos.Count) / 10);

            do
            {
                Console.Clear();
                //Essa tela mostra os contatos
                TelaMostrarContatos.Mostrar(inicializacao.globalData.listaContatos, pagina, limitePagina);
                if (limitePagina == 0)
                {
                    Console.Write("Sair ?");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    //Essa lista e para que o usuario selecione apenas as opções disponivels
                    string[] escolhasAceitas = ["a", "p", "m", "d"];
                    Console.Write("P - Proximo\n" +
                                  "A - Anterior\n" +
                                  "M - Modificar\n" +
                                  "D - Excluir\n" +
                                  "Qualquer Tecla - Sair\n" +
                                  "Escolha: ");
                    string escolha = Console.ReadLine()!.ToLower();

                    //Caso a pagina seja 1 e o usuario voltar ela permanecera como um
                    if (escolha == "a" && pagina == 1)
                    {
                        pagina = 1;
                    }
                    else if (escolha == "a")
                    {
                        pagina--;
                    }

                    //Caso o personagem queira ir alem dos limites de paginas esse if segura ele na ultima pagina
                    if (escolha == "p" && pagina == limitePagina)
                    {
                        pagina = int.Parse(limitePagina.ToString());
                    }
                    else if (escolha == "p")
                    {
                        pagina++;
                    }

                    //Modificar contato
                    if (escolha == "m")
                    {

                        Console.Write("Selecione o id que deseja modificar: ");
                        string idStr = Console.ReadLine()!;

                        //Caso o id não seja um numero ou tenha uma letra dentro dele o programa sai do ciclo 
                        if (String.IsNullOrEmpty(idStr)){  break; }

                        bool hasLetter = false;

                        foreach(char c in idStr) { hasLetter = Char.IsLetter(c); }

                        if (!inicializacao.globalData.listaContatos.Exists(cont => cont.Id == int.Parse(idStr)))
                        {
                            Console.Write("Nenhum contato encontrado ! ( aperte qualquer tecla para continuar)");
                            Console.ReadLine();
                        }

                        //caso seja um valor aceito o usuario passa para a tela de modificação
                        if (!hasLetter) 
                        {
                            inicializacao.modificarContato.Modificar(inicializacao, int.Parse(idStr));
                        }
                    }

                    //Deletar contato
                    if(escolha == "d")
                    {
                        Console.Write("Selecione o id que deseja modificar: ");
                        string idStr = Console.ReadLine()!;
                        //Caso o id não seja um numero ou tenha uma letra dentro dele o programa sai do ciclo 
                        if (String.IsNullOrEmpty(idStr)) { break; }

                        bool hasLetter = false;

                        foreach (char c in idStr) { hasLetter = Char.IsLetter(c); }

                        if (!inicializacao.globalData.listaContatos.Exists(cont => cont.Id == int.Parse(idStr)))
                        {
                            Console.Write("Nenhum contato encontrado ! ( aperte qualquer tecla para continuar)");
                            Console.ReadLine();
                        }
                        //caso seja um valor aceito o contato e deletado
                        if (!hasLetter)
                        {
                            Contato removerContato = inicializacao.globalData.listaContatos.FirstOrDefault(cont => cont.Id == int.Parse(idStr))!;
                            ContatosService.Delete(inicializacao, removerContato);
                        }
                    }

                    //Caso não escolha nenhuma opção valida o usuario voltar para a o menu principal 
                    if (!escolhasAceitas.Contains(escolha))
                    {
                        break;
                    }
                }
            } while (true);
        }
    }
}
