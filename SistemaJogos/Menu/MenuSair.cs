using SistemaJogos.Modelos;

namespace SistemaJogos.Menu;

internal class MenuSair : Menu
{
    public override void Executar(List<Partida> partidaList, List<Perfil> perfil)
    {
        Console.WriteLine("Avanti Palestra!! :)");
    }
}
