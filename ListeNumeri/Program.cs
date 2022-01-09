using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ListeNumeri;

Console.WriteLine("Press M for Check group of numbers Micky Version");
Console.WriteLine("Press S for Check group of numbers Sabrina Version");
Console.WriteLine("Press X for Check group of numbers Micle Version");
Console.WriteLine("Press A for Check ALL Version");



var host = Host.CreateDefaultBuilder()
				.ConfigureAppConfiguration((context, builder) =>
				{
					//No configurations needed
					//Qui possono essere aggiunti parametri di configurazione del Host
					//Ad esempio possiamo caricare dei file di settings da un file json, xml e altro
				})
				.ConfigureServices((context, services)=>
				{
					//Qui possiamo caricare dei servizi (classi che riusiamo spesso nel software)
					
					//Singleton: Viene istanziato una unica volta e distrutto alla chiusura dell'applicazione
					//Scoped: Viene istanziato ogni volta che serve ma non ci puo' essere piu' di una unica istanza.
					//		  Quando esiste, viene condiviso da tutti i processi che lo richiedono
					//        Viene distrutto quando non viene piu' usato da nessun processo, e ricreato se nuovamente richiesto ed era stato distrutto
					//Transient: Viene creata una istanza ogni volta che ne viene fatta richiesta

					// Se i servizi hanno dei costruttori con parametri, anche i parametri devono esistere come servizi
					// In questo caso ReportParameters e' una classe che funge da parametro per gli altri servizi.
					// ReportParameters non viene istanziato finche' un servizio non ne fa richiesta
					// ReportParameters e' stato aggiunto come Scoped cosi' tutti gli altri servizi lo usano in condivisione

					// Quando si usa la DI non si deve mai distruggere un servizio via codice

					services.AddScoped<ReportParams>();
					services.AddTransient<GroupNumbers>();
					services.AddTransient<GapCounter>();
					services.AddTransient<SplitChecker>();					
				})
				.ConfigureLogging(logging => 
				{
					// Qui si potrebbe aggiungere un Logger per registrare gli otuput che ora vengono direttamente inviati alla Console
				}).Build();

var key = Console.ReadLine();
Console.WriteLine($"Hello, you pressed {key}");


Console.WriteLine("\n");

ReportParams reportParams = new ReportParams(); //Usato per il codice che non usa la DependencyInjection IoC
reportParams.PagesList.ForEach(i => Console.Write($"{i}, "));

switch (key)
{
	case "a":
	case "A":  //Solo qui viene sfruttata la DependencyInjection

		Console.WriteLine($"\n\n#### Soluzione Micle: ####\n");
		//GapCounter counter1 = new GapCounter(allPages);
		var counter1 = host.Services.GetRequiredService<GapCounter>();
		Console.WriteLine(counter1);

		Console.WriteLine($"\n\n#### Soluzione Miky: ####\n");
		//var miky = new GroupNumbers(allPages);
		var miky = host.Services.GetRequiredService<GroupNumbers>();

		Console.WriteLine($"\n\n#### Soluzione Sabrina: ####\n");
		//SplitChecker spl1 = new SplitChecker();
		var spl1 = host.Services.GetRequiredService<SplitChecker>();
		//spl1.CheckList(allPages, 100);
		break;

	case "x":
	case "X":
		GapCounter counter = new GapCounter(reportParams.PagesList);
		Console.WriteLine(counter);
		break;

	case "m":	
	case "M":
		Console.WriteLine();
		var gn = new GroupNumbers(reportParams.PagesList);
		break;

	case "s":
	case "S":
		Console.WriteLine();
		SplitChecker spl = new SplitChecker(reportParams);
		//spl.CheckList(reportParams.PagesList, reportParams.Pages);
		break;

	default:
		Console.WriteLine();
		Console.WriteLine($"Sorry, {key} is not a valid input, press Enter to end this program.");
		Console.ReadLine();
		break;
}





