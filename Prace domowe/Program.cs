using System.Text;

List<string> stringList = new List<string>()
{
    "jojoj",
    "jojko"
};

Wordle w = new Wordle();
Console.WriteLine("Przygotowywanie gry...");
w.PrepareWordForWordleGame(stringList);

bool isCorrectWord = false;
while (!isCorrectWord)
{
    Console.WriteLine("Podaj 5-literowe słowo");
    string userInput = Console.ReadLine();
    isCorrectWord = w.PlayWordle(userInput);
}
class WordleLetter
{
    public char Char { get; set; }
    public bool IsInWord { get; set; }
    public bool IsInCorrectPlace { get; set; }
}
class Wordle
{
    public string WordleWord { get; set; }

    public bool PlayWordle(string userWord)
    {
        List<WordleLetter> wordleLetterList = new List<WordleLetter>();
        wordleLetterList = CompareUserWord(userWord);
        int correctLetters = 0;

        foreach (var x in wordleLetterList)
        {
            if (x.IsInWord && x.IsInCorrectPlace)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(x.Char);
                correctLetters++;

            }
            else if (x.IsInWord)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(x.Char);
            }
            else if (!x.IsInWord && !x.IsInCorrectPlace)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(x.Char);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine("");

        if (correctLetters == userWord.Length)
        {
            Console.WriteLine("Gratulacje, zgadłeś słowo");
            return true;
        }
        return false;
    }
    public void PrepareWordForWordleGame(List<string> stringList)
    {
        Random random = new Random();
        WordleWord = stringList[random.Next(0, stringList.Count)];
    }

    public List<WordleLetter> CompareUserWord(string userWord)
    {
        List<WordleLetter> wordleLettersList = new List<WordleLetter>();
        if (userWord.Length != 5)
        {
            Console.WriteLine("słowo musi mieć 5 liter. Wypierdalaj");
        }
        else
        {
            foreach (char x in userWord)
            {
                if (WordleWord.IndexOf(x) == userWord.IndexOf(x))
                {
                    wordleLettersList.Add(new WordleLetter
                    {
                        Char = x,
                        IsInWord = true,
                        IsInCorrectPlace = true
                    });

                    Console.WriteLine($"Litera: {x} występuje w słowie i jest w poprawnym miejscu");
                }

                else if (WordleWord.Contains(x))
                {
                    wordleLettersList.Add(new WordleLetter
                    {
                        Char = x,
                        IsInWord = true,
                        IsInCorrectPlace = false
                    });

                    Console.WriteLine($"Litera: {x} występuje w słowie, ale jest w niepoprawnym miejscu");
                }
                else
                {
                    wordleLettersList.Add(new WordleLetter
                    {
                        Char = x,
                        IsInWord = false,
                        IsInCorrectPlace = false
                    });
                    Console.WriteLine($"Litera: {x} nie występuje w słowie");
                }
            }
        }
        return wordleLettersList;
    }
}