using System.Text.RegularExpressions;

namespace TestProject1
{
    public class UnitTest1
    {
        // Вспомогательный метод для создания тестовой группы
        private Group CreateSampleGroup()
        {
            var g = new Group(1, "TheExample", 2000, "USA", 1);
            g.Repertoire.Add(new Song(1, "SongA", "Comp1", "Lyric1", 2001, "Singer1"));
            g.Repertoire.Add(new Song(2, "SongB", "Comp2", "Lyric2", 2002, "Singer2"));
            g.Repertoire.Add(new Song(3, "SongC", "Comp3", "Lyric3", 2003, "Singer3"));
            g.Tours.Add(new Tour(1, "CityX", new DateTime(2020, 1, 1), new DateTime(2020, 1, 5), 15m));
            return g;
        }

        // 1️⃣ Разница между Assert.Equal и Assert.Same
        [Fact]
        public void Test_Equal_vs_Same()
        {
            string expected = "Hello";
            string actual = new string("Hello".ToCharArray()); // разные объекты, одинаковое значение

            Assert.Equal(expected, actual);      // сравнение по значению (пройдёт)
            Assert.NotSame(expected, actual);    // ссылки разные (пройдёт)

            string interned = string.Intern(actual);
            Assert.Same(expected, interned);     // теперь одна и та же ссылка (пройдёт)
        }

        // 2️⃣ Все элементы коллекции уникальны
        [Fact]
        public void Test_AllItemsAreUnique()
        {
            var g = CreateSampleGroup();
            var titles = g.Repertoire.Select(s => s.Title).ToList();
            Assert.Equal(titles.Count, titles.Distinct().Count());
        }

        // 3️⃣ Все элементы коллекции не равны null
        [Fact]
        public void Test_AllItemsAreNotNull()
        {
            var g = CreateSampleGroup();
            Assert.All(g.Repertoire, song => Assert.NotNull(song));
        }

        // 4️⃣ Проверки StringAssert (замена на обычные Assert)
        [Fact]
        public void Test_String_Contains()
        {
            var g = CreateSampleGroup();
            var text = g.ToString();
            Assert.Contains(g.Name, text);
        }

        [Fact]
        public void Test_String_StartsWith()
        {
            var g = CreateSampleGroup();
            var text = g.ToString();
            Assert.StartsWith(g.Id.ToString(), text);
        }

        [Fact]
        public void Test_String_EndsWith()
        {
            var g = CreateSampleGroup();
            var text = g.ToString();
            Assert.EndsWith(g.ChartPosition.ToString(), text);
        }

        [Fact]
        public void Test_String_MatchesRegex()
        {
            var g = CreateSampleGroup();
            var text = g.ToString();
            var regex = new Regex(@"^\d+;.+;\d{4};.+;\d+$");
            Assert.Matches(regex, text);
        }

        // 5️⃣ Проверки CollectionAssert (аналогами в xUnit)
        [Fact]
        public void Test_Collections_AreEqual_OrderMatters()
        {
            var expected = new List<int> { 1, 2, 3 };
            var actual = new List<int> { 1, 2, 3 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Collections_AreEquivalent_OrderNotImportant()
        {
            var expected = new List<int> { 1, 2, 3 };
            var actual = new List<int> { 3, 1, 2 };
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }

        [Fact]
        public void Test_Collections_Contains_Object()
        {
            var g = CreateSampleGroup();
            var song = g.Repertoire[0];
            Assert.Contains(song, g.Repertoire);
        }

        [Fact]
        public void Test_Collections_IsSubsetOf()
        {
            var g = CreateSampleGroup();
            var subset = new List<string> { "SongA", "SongC" };
            var superset = g.Repertoire.Select(s => s.Title).ToList();

            Assert.True(subset.All(s => superset.Contains(s)));
        }
    }
}
