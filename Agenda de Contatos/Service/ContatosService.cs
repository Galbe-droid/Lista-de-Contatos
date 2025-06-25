using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda_de_Contatos.Classe;
using Agenda_de_Contatos.Global;
using Agenda_de_Contatos.Telas;
using Newtonsoft.Json;

namespace Agenda_de_Contatos.Service
{
    internal class ContatosService
    {
        //Cria um contato, coloca ele dentro da lista global e tambem salva ele dentro do Json
        public static void Create(Inicializacao inicializacao, Contato contato)
        {
            inicializacao.globalData.listaContatos.Add(contato);
            inicializacao.contatosRepository.Save(inicializacao.globalData.listaContatos);
            Console.Write("Contato adicionado... (Aperte qualquer tecla para continuar)");
            Console.ReadLine();
        }

        //Para receber todos os contatos da lista
        public static List<Contato> ReadAll(Inicializacao inicializacao)
        {
            return inicializacao.globalData.listaContatos;
        }

        //Para receber apenas 1 contato pelo id
        public static Contato ReadById (Inicializacao inicializacao, int id)
        {
            return inicializacao.globalData.listaContatos.Find(cont => cont.Id == id);
        }

        //Para atualizar, salvar e remove a copia da lista
        public static List<Contato> Update(Inicializacao inicializacao, int id, Contato novoContato)
        {
            int index = inicializacao.globalData.listaContatos.FindIndex(cont => cont.Id == id);
            inicializacao.globalData.listaContatos.Insert(index, novoContato);
            inicializacao.globalData.listaContatos.RemoveAt(index + 1);
            inicializacao.contatosRepository.Save(inicializacao.globalData.listaContatos);
            return inicializacao.globalData.listaContatos;
        }

        //Deleta o contato e atualiza ela no arquivo json 
        public static void Delete(Inicializacao inicializacao, Contato removerContato)
        {
            inicializacao.globalData.listaContatos.Remove(removerContato);
            inicializacao.contatosRepository.Save(inicializacao.globalData.listaContatos);
        }
    }
}
