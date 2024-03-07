namespace SistemaJogos.Modelos;

internal class Perfil
{

    public string Nome { get; set; }
    public string TimeCoracao { get; set; }
    public int QtdJogos { get; set; }
    public int QtdEstadios { get; set; }

    public Perfil(string nome, string timeCoracao, int qtdJogos, int qtdEstadios)
    {
        Nome = nome;
        TimeCoracao = timeCoracao;
        QtdJogos = qtdJogos;
        QtdEstadios = qtdEstadios;
    }

    internal static void ExibirPerfil(List<Perfil> perfil)
    {


        foreach(Perfil dados in perfil)
        {
            Console.WriteLine($"Nome: {dados.Nome}");
            Console.WriteLine($"Time do coração: {dados.TimeCoracao}");
            Console.WriteLine($"Quantidade de Jogos presente: {dados.QtdJogos}");
            Console.WriteLine($"Estádios visitados: {dados.QtdEstadios}");


        }

    }
}
