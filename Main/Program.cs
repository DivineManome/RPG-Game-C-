using Main;

//Gender gender = 0;
//HairColour hairColour = 0;
//int age = 0;
//string name = "";

//Console.Write("What is your name?: ");
//name = Console.ReadLine();
//Console.Clear();
//Console.Write("What is your age?: ");
//while (true)
//{
//    if (int.TryParse(Console.ReadLine(), out int _age))
//    {
//        if (_age < 0 || _age > 100)
//        {
//            Console.WriteLine("This age is not eligible");
//        }
//        else
//        {
//            age = _age;
//            Console.Clear();
//            break;
//        }
//    }
//    else
//    {
//        Console.WriteLine("This character is not eligible");
//    }
//}
//Console.Write("What would you like your hair colour to be?\n1. Black\n2. Brown\n3. Red\n4. White\n5. Yellow\n> ");
//while (true)
//{
//    if (int.TryParse(Console.ReadLine(), out int _hairColour))
//    {
//        if (_hairColour < 0 || _hairColour > 5)
//        {
//            Console.Write("This number is not an option, try another number\n> ");
//        }
//        else
//        {
//            hairColour = (HairColour)_hairColour;
//            Console.Clear();
//            break;
//        }
//    }
//    else
//    {
//        Console.Write("This character is not eligible\n> ");
//    }
//}
//Console.Write("What is your gender?\n1. Male\n2. Female\n3. Non_Binary\n4. Trans Women/man\n5. Other\n> ");
//while (true)
//{
//    if (int.TryParse(Console.ReadLine(), out int _gender))
//    {
//        if (_gender < 0 || _gender > 6)
//        {
//            Console.Write("This number is not an option, try another number\n> ");
//        }
//        else
//        {
//            gender = (Gender)_gender;
//            Console.Clear();
//            break;
//        }
//    }
//    else
//    {
//        Console.Write("This character is not eligible\n> ");
//    }
//}

//Console.WriteLine("As a new player, you will be starting with 10 attack, 5 defense, and 100 HP");
//--------------------------------------------------------------------------------------------------

Player you = new Player(Gender.Male, "Black", 18, "Divine", 10000.0f, 80, 0,10000);

Game game = new Game(you);
game.StartGame();

Enemy enemy = new Enemy("Goblin", 100.0f, 10, 5, 100);
public enum Gender
{
    Male,
    Female,
    Non_Binary,
    Trans,
    Other,
}
public enum HairColour
{
    Black,
    Brown,
    Red,
    White,
    Yellow,
}