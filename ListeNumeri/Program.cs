// See https://aka.ms/new-console-template for more information


using ListeNumeri;

Console.WriteLine("Press M for Check group of numbers Micky Version");
Console.WriteLine("Press S for Check group of numbers Sabrina Version");
ConsoleKeyInfo key = Console.ReadKey();

switch (key.KeyChar)
{
	case 'm':	
	case 'M':
		Console.WriteLine();
		var gn = new GroupNumbers();
		break;
	case 's':
	case 'S':
		Console.WriteLine();
		List<int> allPages = new List<int>() {6,7,8,9,10,11,12,22,23,24,25,43,44,45,46,47,48,66,67,68,84 };
		SplitChecker spl = new SplitChecker();
		spl.CheckList(allPages, 100);
		break;
	default:
		Console.WriteLine();
		Console.WriteLine($"Hello, you pressed {key.KeyChar} press Enter to end this program.");
		Console.ReadLine();
		break;
}



