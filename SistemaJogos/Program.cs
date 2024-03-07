using SistemaJogos.Menu;
using SistemaJogos.Modelos;
using System.Collections.Generic;

string mensagemSubTitulo = "Sistema de jogos presentes do Palmeiras!";
//Dictionary<DateTime, List<Partida>> partidasCadastradas = new();
List<Partida> partidaList = new();
List<Perfil> perfil = new();
List<string> golsTimeMandanteLista = new List<string>();
List<string> golsTimeVisitanteLista = new List<string>();

Perfil perfil1 = new Perfil("André Lucas", "Palmeiras", 0, 0);
perfil.Add(perfil1);
//Partida partida1 = new Partida(Convert.ToDateTime("22/09/1997"), "Allianz", "Palmeiras x Corinthians", "2x1");
//partidaList.Add(partida1);
//
//Partida partida2 = new Partida(Convert.ToDateTime("05/03/2024"), "Pacaembu", "Palmeiras x Santos", "3x0");
//partidaList.Add(partida2);

Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
opcoes.Add(1, new MenuPerfil());
opcoes.Add(2, new MenuAdicionarJogo());
opcoes.Add(3, new MenuVisualizarPartidas());
opcoes.Add(0, new MenuSair());


void ExibirMensagemAbertura()
{
    Console.WriteLine(@"
░░░░░██╗░█████╗░░██████╗░░█████╗░░██████╗  ██████╗░░█████╗░
░░░░░██║██╔══██╗██╔════╝░██╔══██╗██╔════╝  ██╔══██╗██╔══██╗
░░░░░██║██║░░██║██║░░██╗░██║░░██║╚█████╗░  ██║░░██║██║░░██║
██╗░░██║██║░░██║██║░░╚██╗██║░░██║░╚═══██╗  ██║░░██║██║░░██║
╚█████╔╝╚█████╔╝╚██████╔╝╚█████╔╝██████╔╝  ██████╔╝╚█████╔╝
░╚════╝░░╚════╝░░╚═════╝░░╚════╝░╚═════╝░  ╚═════╝░░╚════╝░

██████╗░░█████╗░██╗░░░░░███╗░░░███╗███████╗██╗██████╗░░█████╗░░██████╗
██╔══██╗██╔══██╗██║░░░░░████╗░████║██╔════╝██║██╔══██╗██╔══██╗██╔════╝
██████╔╝███████║██║░░░░░██╔████╔██║█████╗░░██║██████╔╝███████║╚█████╗░
██╔═══╝░██╔══██║██║░░░░░██║╚██╔╝██║██╔══╝░░██║██╔══██╗██╔══██║░╚═══██╗
██║░░░░░██║░░██║███████╗██║░╚═╝░██║███████╗██║██║░░██║██║░░██║██████╔╝
╚═╝░░░░░╚═╝░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░");
   ExibirTitulosOpcao(mensagemSubTitulo);

}

void ExibirMenu()
{
    ExibirMensagemAbertura();
    Console.WriteLine("\nDigite 1 para visualizar seu perfil.");
    Console.WriteLine("\nDigite 2 para adicionar o placar do jogo.");
    Console.WriteLine("\nDigite 3 para visualizar as partidas presentes.");
    Console.WriteLine("\nDigite 0 para sair.");

    Console.Write("\nDigite a sua opção: ");

    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    while (!opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Console.Write("Opção inválida! Digite novamente: ");
        opcaoEscolhida = Console.ReadLine()!;
        opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    }
    
    Menu menuExibido = opcoes[opcaoEscolhidaNumerica];
    menuExibido.Executar(partidaList, perfil);

    if (opcaoEscolhidaNumerica > 0)
    {
        ExibirMenu();
    }   
}

void ExibirTitulosOpcao(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

ExibirMenu();