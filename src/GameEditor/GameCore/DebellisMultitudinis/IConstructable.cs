namespace GameCore.DebellisMultitudinis
{
    public interface IConstructable
    {
        int Cost { get; set; }
        int Upkeep { get; set; }
        int ConstructionTime { get; set; } 
    }
}