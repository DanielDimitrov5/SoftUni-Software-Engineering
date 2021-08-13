// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using FestivalManager.Entities;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
        }

        [Test]
        public void AddPerformerThrowsAnExceptionIfObjectNull()
        {
            Performer performer = null;

            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void AddPerformerThrowsAnExceptionWhenUnderAged()
        {
            Performer performer = new Performer("Ivo", "Ivanov", 9);

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void AddPerformerAddsPerformerToTheCollection()
        {
            Performer performer = new Performer("Ivo", "Ivanov", 18);

            stage.AddPerformer(performer);

            Assert.AreEqual(stage.Performers.Count, 1);
        }

        [Test]
        public void AddSongThrowsAnExceptionIfObjectNull()
        {
            Song song = null;

            Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
        }

        [Test]
        public void AddSongThrowsAnExceptionWhenDurationUnderOneMinute()
        {
            Song song = new Song("Jik-Tak", new TimeSpan(0, 0, 55));

            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]
        public void AddSongToPerformerThrowsAnExceptionWhenPerformerIsNotPresentInTheCollection()
        {
            Song song = new Song("Song", new TimeSpan(0, 2, 34));
            stage.AddSong(song);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, "Performer"));
        }
        
        [Test]
        public void AddSongToPerformerThrowsAnExceptionWhenSongIsNotPresentInTheCollection()
        {
            Performer performer = new Performer("Performer", "Performer", 66);
            stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Song", performer.FullName));
        }

        [Test]
        public void AddSongToPerformerReturnsString()
        {
            Performer performer = new Performer("Performer", "Performer", 66);
            Song song = new Song("Song", new TimeSpan(0, 2, 34));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            string expected = $"{song} will be performed by {performer.FullName}";

            string actual = stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PlayCalculatesAllPerformersSongsCount()
        {
            Performer performerOne = new Performer("Ivo", "Stefanov", 30);
            Performer performerTwo = new Performer("Stefcho", "Stefanov", 30);

            int count = 5;

            for (int i = 0; i < count; i++)
            {
                performerOne.SongList.Add(new Song($"{i}", new TimeSpan(0, 3, i)));
                performerTwo.SongList.Add(new Song($"{i + count}", new TimeSpan(0, 3, i + 1)));
            }

            stage.AddPerformer(performerOne);
            stage.AddPerformer(performerTwo);

            int performersCount = stage.Performers.Count;
            int totalSongsPlayed = performersCount * count;

            string expected = $"{performersCount} performers played {totalSongsPlayed} songs";

            string actual = stage.Play();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Song", null)]
        [TestCase(null, "Performer")]
        public void ValidateNullValueThrowsAnExceptionWhenObjectsAreNull(string song, string performer)
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(song, performer));
        }


    }
}