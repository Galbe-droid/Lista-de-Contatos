using Agenda_de_Contatos.Global;
using Agenda_de_Contatos.Tipo;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Classe
{
    class Contato
    {
        [NotNull]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ContatoNumero { get; set; }
        public ContatoType Tipo { get; set; }

        public Contato(int id, string nome, string numero, ContatoType tipoContato)
        {
            Id = id;
            Nome = nome;
            ContatoNumero = numero;
            Tipo = tipoContato;            
        }

        public override string ToString()
        {
            return $"{Id} | Nome: {Nome} | Numero: {ContatoNumero} | Tipo: {Tipo}";
        }
    }
}
