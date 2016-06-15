using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Models
{
    public class GameModel : IGameModel
    {
        public int CurrentArmyDefinitionId { get; set; }
        public int CurrentArmyUnitDefinitionId { get; set; }

        public ArmyDefinitions GetArmyDefinitions()
        {
            using (var client = new WarGameServiceClient())
            {
                return client.GetArmyDefinitions();
            }
        }

        public ArmyDefinition GetArmyDefinition(int id)
        {
            using (var client = new WarGameServiceClient())
            {
                return client.GetArmyDefinition(id);
            }
        }

        public int AddArmyDefinition(ArmyDefinition definition)
        {
            using (var client = new WarGameServiceClient())
            {
                var result = client.PutArmyDefinition(definition);
                CurrentArmyDefinitionId = result;
                return result;
            }
        }

        public void DeleteArmyDefinition(int id)
        {
            using (var client = new WarGameServiceClient())
            {
                client.DeleteArmyDefinition(id);
                CurrentArmyDefinitionId = 0;
                CurrentArmyUnitDefinitionId = 0;
            }
        }

        public ArmyUnitDefinition GetArmyUnitDefinition(int id)
        {
            if (CurrentArmyDefinitionId == 0) return null;
            using (var client = new WarGameServiceClient())
            {
                return client.GetArmyUnitDefinition(CurrentArmyDefinitionId, id);
            }
        }

        public ArmyUnitDefinitions GetArmyUnitDefinitions()
        {
            if (CurrentArmyDefinitionId == 0) return null;
            using (var client = new WarGameServiceClient())
            {
                return client.GetArmyUnitDefinitions(CurrentArmyDefinitionId);
            }
        }

        public int AddArmyUnitDefinitino(ArmyUnitDefinition definition)
        {
            using (var client = new WarGameServiceClient())
            {
                if (CurrentArmyDefinitionId == 0) return 0;
                CurrentArmyUnitDefinitionId = client.PutArmyUnitDefinition(CurrentArmyDefinitionId, definition.Id, definition);
                return CurrentArmyUnitDefinitionId;
            }
        }

        public void DeleteArmyUnitDefinition(int id)
        {
            using (var client = new WarGameServiceClient())
            {
                client.DeleteArmyUnitDefinition(CurrentArmyDefinitionId, id);
                CurrentArmyUnitDefinitionId = 0;
            }
        }
    }
}