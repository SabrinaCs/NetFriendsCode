namespace ListeNumeri;

public class GapCounter
{
    public List<Gap> InList { get; private set; }
    public List<Gap> OutList { get; private set; }

    public GapCounter(ReportParams reportParams)
    {
        InList = new();
        OutList = new();
        Counter(reportParams.PagesList);
    }
    public GapCounter(List<int> theNumbers)
    {
        InList = new();
        OutList = new();
        Counter(theNumbers);
    }

    private void Counter(List<int> theNumbers)
    {
        int i = 0; //counter dei mancanti
        int j = 0; //counter attigui
        int start = 1; //record per gli attigui
        int k = 0; //indice reale della lista theNumbers
        foreach (var number in theNumbers)
        {
            k++;
            i++;
            if (number == i)
            {
                j++;
                if (theNumbers.Count == k) //la condizione dell'ultimo numero
                {
                    InList.Add(new()
                    {
                        Start = start,
                        Jump = j
                    });
                }
                continue;
            }


            //se sono qui non ho trovato corrispondenza fra number ed i, significa che sono in
            //un gap dove number rappresenta la fine ed i l'inizio

            // 1 2 3 4 . . 7 8 9 .. .. .. 13 

            OutList.Add(new()
            {
                Start = i,
                Jump = number - i
            });

            //lista per gli int devo discriminare l'inizio
            //{ . . . . . . 7 . 9 . . 12 13 . 15 . . 18 19 . . 22 23 24 25 };
            if (j != 0)
            {
                InList.Add(new()
                {
                    Start = start,
                    Jump = j
                });
            }

            if (theNumbers.Count == k) //la condizione dell'ultimo numero
            {
                InList.Add(new()
                {
                    Start = number,
                    Jump = 1
                });
            }

            start = number;     //memorizzo la partenza dei continui
            j = 1;
            i = number;         //allineo l'indice col numero

        }
    }

    public override string ToString()
    {
        string output = "Lista degli out:\n";
        foreach (var gap in OutList)
            output += $"{gap}\n";

        output += "\n\nLista degli in:\n";
        foreach (var gap in InList)
            output += $"{gap}\n";

        return output;

    }
}
