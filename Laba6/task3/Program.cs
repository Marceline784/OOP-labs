using System;
using System.Collections.Generic;

public class InvalidSongException : Exception
{
    public InvalidSongException(string message = "Invalid song.") : base(message) { }
}


public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException() : base("Artist name should be between 3 and 20 symbols.") { }
}


public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException() : base("Song name should be between 3 and 30 symbols.") { }
}


public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException() : base("Invalid song length.") { }
    public InvalidSongLengthException(string message) : base(message) { }
}

public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException() : base("Song minutes should be between 0 and 14.") { }

}

public class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException() : base("Song seconds should be between 0 and 59.") { }
}

public class Song
{
    private string artist;
    private string name;
    private int minutes;
    private int seconds;

    public Song(string artist, string name, int minutes, int seconds)
    {
        Artist = artist;
        Name = name;
        Minutes = minutes;
        Seconds = seconds;
    }
    public string Artist
    {
        get 
        { 
            return artist;
        }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidArtistNameException();
            artist = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
                throw new InvalidSongNameException();
            name = value;
        }
    }
    public int Minutes
    {
        get
        {
            return minutes;
        }
        private set
        {
            if (value < 0 || value > 14)
                throw new InvalidSongMinutesException();
            minutes = value;
        }
    }
    public int Seconds
    {
        get
        {
            return seconds;
        }
        private set
        {
            if (value < 0 || value > 59)
                throw new InvalidSongSecondsException();
            seconds = value;
        }
    }
    public int TotalSeconds => Minutes * 60 + Seconds;
}
class Program
    {
        static void Main()
        {
        int n = int.Parse(Console.ReadLine());
        List<Song> playlist = new List<Song>();
        int totalSeconds = 0;

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(';');

            try
            {
                string artist = parts[0];
                string name = parts[1];
                string[] timeParts = parts[2].Split(':');
                int minutes = int.Parse(timeParts[0]);
                int seconds = int.Parse(timeParts[1]);

                Song song = new Song(artist, name, minutes, seconds);
                playlist.Add(song);
                totalSeconds += song.TotalSeconds;

                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        int hours = totalSeconds / 3600;
        int minutesTotal = (totalSeconds % 3600) / 60;
        int secondsTotal = totalSeconds % 60;

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist length: {hours}h {minutesTotal}m {secondsTotal}s");
    }
}

