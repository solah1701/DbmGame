using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Models
{
    public interface IGameModel
    {
        ArmyDefinition GetArmyDefinition(string id);
        ArmyDefinitions GetArmyDefinitions();
        void AddArmyDefinition(ArmyDefinition definition);
    }
}