using SistemaJogos.Modelos;

namespace SistemaJogos.Menu
{
    internal class MenuAdicionarJogo : Menu
    {
        public override void Executar(List<Partida> partidaList, List<Perfil> perfil)
        {
            base.Executar(partidaList, perfil);
            ExibirTitulosOpcao("Adicionando o placar do jogo");
            Console.Write("Data do jogo (Ex.: 22/09/1997): ");
            string dataJogo = Console.ReadLine()!;
            string data = dataJogo;

            Console.Write("\nLocal da partida: ");
            string localPartida = Console.ReadLine()!;

            Console.Write("\nPartida (Ex.: Mandante x Visitante): ");
            string partida = Console.ReadLine()!;

            Console.Write("\nPlacar do jogo (Ex.: 2x1): ");
            string placar = Console.ReadLine()!;

            
            Partida partidaAtual = new Partida(data, localPartida, partida, placar);
            partidaList.Add(partidaAtual);

            Console.Write("\nPartida cadastrada com sucesso!");
            Thread.Sleep(3000);
            Console.Write("\nDigite uma tecla para voltar ao menu principal!");
            Console.ReadKey();
            Console.Clear();
        }
        public static List<MenuAdicionarJogo> PlacarMandanteVisitante(string timeMandante, string timeVisitante, int golsTimeMandante, int golsTimeVisitante)
        {
            List<MenuAdicionarJogo> timesVisitantes = new List<MenuAdicionarJogo>();            

            for (int i = 1; i <= golsTimeMandante; i++)
            {
                Console.Write($"\nQuem fez o {i}º gol para o {timeMandante}: ");
                string jogadorGol = Console.ReadLine()!;
            }

            for (int i = 1; i <= golsTimeVisitante; i++)
            {
                Console.Write($"\nQuem fez o {i}º gol para o {timeVisitante}: ");
                string jogadorGol = Console.ReadLine()!;
            }

            return timesVisitantes;
        }
    }
}
