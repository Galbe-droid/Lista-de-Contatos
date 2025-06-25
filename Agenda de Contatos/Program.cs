using Agenda_de_Contatos.Classe;
using Agenda_de_Contatos.Global;
using Agenda_de_Contatos.Service;
using Agenda_de_Contatos.Telas;
using Agenda_de_Contatos.Tipo;

//Carregamento inicial 
//Inicialização dos modos Globais que não são estaticos
Inicializacao inicializacao = new();
//Verificar se o arquivo para salvar existe
inicializacao.contatosRepository.CrateFile();
//Carregando a lista Json para o sistema, apenas se ela existir e se estiver com dados
inicializacao.globalData.listaContatos = inicializacao.contatosRepository.Loading();

while (true)
{
    //Quantidade de Contatos cadastrados
    int contatosQty = inicializacao.globalData.listaContatos.Count;
    //Escolha do menu principal para decidir o que fazer
    //1-Mostrar Contatos
    //2-Criar um contato
    //3-Sair do console
    int resultado = inicializacao.menuPrincipal.Escolha(contatosQty);

    //Sair do console
    if( resultado == 3 )
    {
        break;
    }

    switch (resultado)
    {
        //Mostrar Contatos
        case 1:
            //Se não tiver contato e mostrado apenas um texto
            if(contatosQty == 0)
            {
                Console.WriteLine("Sem Contatos para mostrar. (Qualquer tecla para continuar)");
                Console.ReadLine();
            }
            //Se tiver e levado ao menu de opção 
            else
            {                
                inicializacao.navegarContato.Opcao(inicializacao);            
            }            
            break;

        //Criar contato
        case 2:
            //O contato e criado em outro menu 
            Contato contato = inicializacao.criacaoContato.Criacao(inicializacao);
            //Caso o contato não retorne null ele e criado e caso seja null ele retorna ao menu principal
            if( contato != null )
            {
                //Passa para o script de criação
                ContatosService.Create(inicializacao, contato);
            }
            break;

        default:
            break;
    }
    Console.Clear();
}
