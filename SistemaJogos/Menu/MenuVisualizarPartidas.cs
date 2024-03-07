using SistemaJogos.Modelos;

namespace SistemaJogos.Menu;

internal class MenuVisualizarPartidas : Menu
{
    public override void Executar(List<Partida> partidaList, List<Perfil> perfil)
    {
        base.Executar(partidaList, perfil);
        ExibirTitulosOpcao("Visualização de Partidas presentes");
        Partida.ExibirInfoJogo(partidaList);
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
