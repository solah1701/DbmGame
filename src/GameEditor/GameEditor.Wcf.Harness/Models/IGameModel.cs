using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Models
{
    public interface IGameModel
    {
        ArmyDefinition GetArmyDefinition(int id);
        ArmyDefinitions GetArmyDefinitions();
        int AddArmyDefinition(ArmyDefinition definition);
        void DeleteArmyDefinition(int id);
    }
}