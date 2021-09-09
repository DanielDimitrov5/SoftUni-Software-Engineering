namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    using Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    x.Name,
                    x.ReleaseDate,
                    x.Producer,
                    Songs = x.Songs.Select(song => new
                    {
                        song.Name,
                        song.Price,
                        song.Writer
                    }),
                    songProperty = x.Songs,
                    x.Price
                })
                .ToList();

            foreach (var album in albums.OrderByDescending(x => x.Price))
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine(
                    $"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.Producer.Name}");

                sb.AppendLine("-Songs:");

                int counter = 0;

                foreach (var song in album.Songs.OrderByDescending(x => x.Name).ThenBy(x => x.Writer.Name))
                {
                    sb.AppendLine($"---#{++counter}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.Writer.Name}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Select(x => new
                {
                    SongName = x.Name,
                    PerformerFullName = x.SongPerformers.Select(p => p.Performer.FirstName +  " " + p.Performer.LastName).FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerFullName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            int counter = 0;

            foreach (var song in songs.Where(x => x.Duration.TotalSeconds > duration))
            {
                sb.AppendLine($"-Song #{++counter}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerFullName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
