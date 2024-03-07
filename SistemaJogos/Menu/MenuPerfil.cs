using SistemaJogos.Menu;
using SistemaJogos.Modelos;
internal class MenuPerfil : Menu
{
    public override void Executar(List<Partida> partidaList, List<Perfil> perfil)
    {
        List<Perfil> perfilAtual = new List<Perfil>();
        base.Executar(partidaList, perfil);
        ExibirTitulosOpcao("Meu Perfil");
        Perfil.ExibirPerfil(perfil);
        Console.Write("\nDigite uma tecla para voltar ao menu principal!");
        Console.ReadKey();
    }
}