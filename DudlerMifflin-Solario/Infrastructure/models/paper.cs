namespace DudlerMifflin_Solario.Infrastructure.models;

public class paper
{
    public int PaperId { get; set; }
    public string PaperName { get; set; }
    public bool Discontinued { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
}