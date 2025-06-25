using Agenda_de_Contatos.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Global
{
    class GlobalData
    {        
        //Cria um lista de contatos que pode ser usada em qualquer parte do programa
        public List<Contato> listaContatos = [];

        //Gera um id com base no maior numero de id + 1
        public int NewId(List<Contato> lista)
        {
            if(lista.Count == 0)
            {
                return 0;
            }

            List<int> ids = [];
            foreach (Contato x in listaContatos)
            {
                ids.Add(x.Id);
            }

            return ids.Max() + 1;
        }
    }
}
