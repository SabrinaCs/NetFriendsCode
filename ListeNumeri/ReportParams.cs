namespace ListeNumeri;

public class ReportParams
{
    public List<int> PagesList { get; set; }
    public int Pages { get; set; }

    public ReportParams()
    {
        PagesList = new List<int> { 6, 7, 8, 9, 10, 11, 12, 22, 23, 24, 25, 43, 44, 45, 46, 47, 48, 66, 67, 68, 84 };
        Pages = 100;
    }
}    
