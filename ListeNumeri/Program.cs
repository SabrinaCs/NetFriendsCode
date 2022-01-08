using ListeNumeri;

Console.WriteLine("Press M for Check group of numbers Micky Version");
Console.WriteLine("Press S for Check group of numbers Sabrina Version");
Console.WriteLine("Press X for Check group of numbers Micle Version");
Console.WriteLine("Press A for Check ALL Version");

var key = Console.ReadLine();
Console.WriteLine($"Hello, you pressed {key}");

List<int> allPages = new List<int>() { 6, 7, 8, 9, 10, 11, 12, 22, 23, 24, 25, 43, 44, 45, 46, 47, 48, 66, 67, 68, 84 };

Console.WriteLine("\n");
allPages.ForEach(i => Console.Write($"{i}, "));

switch (key)
{
	case "a":
	case "A":
		Console.WriteLine($"\n\n#### Soluzione Micle: ####\n");
		GapCounter counter1 = new GapCounter(allPages);
		Console.WriteLine(counter1);

		Console.WriteLine($"\n\n#### Soluzione Miky: ####\n");
		var miky = new GroupNumbers(allPages);

		Console.WriteLine($"\n\n#### Soluzione Sabrina: ####\n");
		SplitChecker spl1 = new SplitChecker();
		spl1.CheckList(allPages, 100);
		break;

	case "x":
	case "X":
		GapCounter counter = new GapCounter(allPages);
		Console.WriteLine(counter);
		break;

	case "m":	
	case "M":
		Console.WriteLine();
		var gn = new GroupNumbers(allPages);
		//var gn = new GroupNumbers(new List<int> { 1, 2, 3, 4, 12, 13, 14, 15, 21, 22, 23, 24, 25 });
		break;

	case "s":
	case "S":
		Console.WriteLine();
		SplitChecker spl = new SplitChecker();
		spl.CheckList(allPages, 100);
		break;

	default:
		Console.WriteLine();
		Console.WriteLine($"Sorry, {key} is not a valid input, press Enter to end this program.");
		Console.ReadLine();
		break;
}



