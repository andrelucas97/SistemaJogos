using SistemaJogos.Modelos;

namespace SistemaJogos.Menu;

internal class Menu
{
    public virtual void Executar(List<Partida> partidaList, List<Perfil> perfil)
    {
        Console.Clear();
    }
    public void ExibirTitulosOpcao(string titulo)
    {
        int qtdLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

}
