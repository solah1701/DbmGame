namespace GameEditor.Wcf.Harness.Models
{
    public class ArmyDefinition: IArmyDefinition
    {
        public int ArmyId { get; set; }
        public string ArmyName { get; set; }
        public int ArmyBook { get; set; }
        public int ArmyList { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
    }
}