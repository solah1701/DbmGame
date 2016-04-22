namespace GameCore.DebellisMultitudinis
{
    public interface IUnit : INamedItem
    {
        int Attack { get; set; }
        int Defence { get; set; }
        int Move { get; set; }
        int Range { get; set; }
        int Speed { get; set; }
        int Stamina { get; set; }
        int Level { get; set; }
        int Morale { get; set; }
        int Upkeep { get; set; }
    }
}