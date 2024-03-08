using SistemaJogos.Menu;
using System.Text.Json;

namespace SistemaJogos.Modelos
{
    public class Partida
    {
        public string Data { get; set; }
        public string Estadio { get; set; }
        public string PartidaTimes { get; set; }
        public string Placar { get; set; }
        public string? TimeMandante { get; set; }
        public string? TimeVisitante { get; set; }
        public int? GolsTimeMandante { get; set; }
        public int? GolsTimeVisitante { get; set; }
        public static List<Partida>? PartidaJogos { get; }
        public Partida()
        {

        }

        public Partida(string data, string estadio, string partidaTimes, string placar)
        {          

            string[] time = partidaTimes.Split('x');
            string timeMandante = time[0].Trim();
            string timeVisitante = time[1].Trim();

            string[] placarSplit = placar.Split('x');
            int golsTimeMandante = int.Parse(placarSplit[0]);
            int golsTimeVisitante = int.Parse(placarSplit[1]);

            List<string> golsTimeMandanteLista = new List<string>();
            List<string> golsTimeVisitanteLista = new List<string>();

            PlacarMandanteVisitante(timeMandante, timeVisitante, golsTimeMandante, golsTimeVisitante, golsTimeMandanteLista, golsTimeVisitanteLista);

            Data = data;
            Estadio = estadio;
            PartidaTimes = partidaTimes;
            Placar = placar;
            TimeMandante = timeMandante;
            TimeVisitante = timeVisitante;
            GolsTimeMandante = golsTimeMandante;
            GolsTimeVisitante = golsTimeVisitante;

        }

        public void PlacarMandanteVisitante(string timeMandante, string timeVisitante, int golsTimeMandante, int golsTimeVisitante, List<string> golsTimeMandanteLista, List<string> golsTimeVisitanteLista)
        {

            for (int i = 1; i <= golsTimeMandante; i++)
            {
                Console.Write($"\nQuem fez o {i}º gol para o {timeMandante}: ");
                string jogadorGol = Console.ReadLine()!;
                golsTimeMandanteLista.Add(jogadorGol);
            }

            for (int i = 1; i <= golsTimeVisitante; i++)
            {
                Console.Write($"\nQuem fez o {i}º gol para o {timeVisitante}: ");
                string jogadorGol = Console.ReadLine()!;
                golsTimeVisitanteLista.Add(jogadorGol);
            }
            
        }

        public static List<Partida> ExibirInfoJogo(List<Partida> partida)
        {
            List<Partida> partidas = new List<Partida>();
            int count = 1;
            foreach (Partida partidaItem in partida)
            {
                Console.WriteLine($"Partida {count}: {partidaItem.Data} ({partidaItem.Estadio}) {partidaItem.TimeMandante} {partidaItem.GolsTimeMandante} x {partidaItem.GolsTimeVisitante} {partidaItem.TimeVisitante} ");
                Console.WriteLine($"Time Mandante: {partidaItem.TimeMandante}");
                Console.WriteLine($"Time Visitante: {partidaItem.TimeVisitante}");
                count++;
            }
            return partidas;
        }

        internal void AdicionarArquivoJson(Partida partidaAtual)
        {
            string arquivoJogos = $"jogos-presente.json";
            List<Partida> partidaList = new List<Partida>();

            try
            {
                if (File.Exists(arquivoJogos))
                {
                    string json = File.ReadAllText(arquivoJogos);
                    // ERRO AQUI
                    partidaList = JsonSerializer.Deserialize<List<Partida>>(json)!;
                }
                else
                {
                    string json = JsonSerializer.Serialize(new
                    {
                        data = Data,
                        estadio = Estadio,
                        partidaTimes = PartidaTimes,
                        placar = Placar,
                        timeMandante = TimeMandante,
                        timeVisitante = TimeVisitante,
                        golsTimeMandante = GolsTimeMandante,
                        golsTimeVisitante = GolsTimeVisitante

                    });

                    string arquivoJogo = $"jogos-presente.json";

                    File.WriteAllText(arquivoJogo, json);
                    Console.WriteLine($"Arquivo Json criado com sucesso! {Path.GetFullPath(arquivoJogo)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao desserializar o JSON: {ex.Message}");
            }
            

            partidaList.AddRange(PartidaJogos!);

            string novoJson = JsonSerializer.Serialize(partidaList);
            File.WriteAllText(arquivoJogos, novoJson);
            Console.WriteLine($"Jogo atualizado com sucesso!! {Path.GetFullPath(arquivoJogos)}");
        }
    }
}
