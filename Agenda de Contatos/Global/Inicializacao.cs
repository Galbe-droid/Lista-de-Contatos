using Agenda_de_Contatos.Menu;
using Agenda_de_Contatos.Repository;
using Agenda_de_Contatos.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contatos.Global
{
    //Serve para inicializar todos os metodos e scripts em um local so 
    internal class Inicializacao
    {
        public GlobalData globalData = new();
        public MenuPrincipal menuPrincipal = new();
        public CriacaoContato criacaoContato = new();
        public NavegarContato navegarContato = new();
        public ModificarContato modificarContato = new();
        public IContatosRepository contatosRepository = new();
    }
}
