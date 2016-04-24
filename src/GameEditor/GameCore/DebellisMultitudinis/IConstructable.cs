namespace GameCore.DebellisMultitudinis
{
    public interface IConstructable
    {
        decimal Cost { get; set; }
        int ConstructionTime { get; set; } 
    }
}