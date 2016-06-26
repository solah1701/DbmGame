using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Models
{
    public interface IGameModel
    {
        int CurrentArmyDefinitionId { get; set; }
        int CurrentArmyUnitDefinitionId { get; set; }
        int CurrentAllyDefinitionId { get; set; }

        ArmyDefinition GetArmyDefinition(int id);
        ArmyDefinitions GetArmyDefinitions();
        int AddArmyDefinition(ArmyDefinition definition);
        void DeleteArmyDefinition(int id);

        ArmyUnitDefinition GetArmyUnitDefinition(int id);
        ArmyUnitDefinitions GetArmyUnitDefinitions();
        int AddArmyUnitDefinition(ArmyUnitDefinition definition);
        void DeleteArmyUnitDefinition(int id);

        AlliedArmyDefinition GetAlliedArmyDefinition(int id);
        AlliedArmyDefinitions GetAlliedArmyDefinitions();
        ArmyDefinitions GetFilteredAlliedArmyDefinitions(int minYear, int maxYear);
        int AddAllyDefinition(AlliedArmyDefinition definition);
        void DeleteAllyDefinition(int id);
    }
}