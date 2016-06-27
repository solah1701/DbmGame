using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Models
{
    public class GameModel : IGameModel
    {
        public int CurrentArmyDefinitionId { get; set; }
        public int CurrentArmyUnitDefinitionId { get; set; }
        public int CurrentAllyDefinitionId { get; set; }
        public int CurrentAllyArmyDefinitionId { get; set; }

        public ArmyDefinitions GetArmyDefinitions()
        {
            using (var client = new WarGameServiceClient())
            {
                return client.GetArmyDefinitions();
            }
        }

        public ArmyDefinition GetArmyDefinition(int id)
        {
            if (id == 0) return null;
            using (var client = new WarGameServiceClient())
            {
                return client.GetArmyDefinition(id);
            }
        }

        public ArmyDefinition GetArmyDefinition(string name)
        {
            if (name == string.Empty) return null;
            using (var client = new WarGameServiceClient())
            {
                return client.GetArmyDefinitionByName(name);
            }
        }

        public int AddArmyDefinition(ArmyDefinition definition)
        {
            using (var client = new WarGameServiceClient())
            {
                CurrentArmyDefinitionId = client.PutArmyDefinition(definition);
                return CurrentArmyDefinitionId;
            }
        }

        public void DeleteArmyDefinition(int id)
        {
            if (id == 0) return;
            using (var client = new WarGameServiceClient())
            {
                client.DeleteArmyDefinition(id);
                CurrentArmyDefinitionId = 0;
                CurrentArmyUnitDefinitionId = 0;
            }
        }

        public ArmyUnitDefinition GetArmyUnitDefinition(int id)
        {
            if (CurrentArmyDefinitionId == 0 || id == 0) return null;
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

        public int AddArmyUnitDefinition(ArmyUnitDefinition definition)
        {
            if (CurrentArmyDefinitionId == 0) return 0;
            using (var client = new WarGameServiceClient())
            {
                return client.PutArmyUnitDefinition(CurrentArmyDefinitionId, definition.Id, definition);
            }
        }

        public void DeleteArmyUnitDefinition(int id)
        {
            if (CurrentArmyDefinitionId == 0 || id == 0) return;
            using (var client = new WarGameServiceClient())
            {
                client.DeleteArmyUnitDefinition(CurrentArmyDefinitionId, id);
                CurrentArmyUnitDefinitionId = 0;
            }
        }

        public AlliedArmyDefinition GetAlliedArmyDefinition(int id)
        {
            if (CurrentArmyDefinitionId == 0 || id == 0) return null;
            using (var client = new WarGameServiceClient())
            {
                return client.GetAlliedArmyDefinition(CurrentArmyDefinitionId, id);
            }
        }

        public AlliedArmyDefinitions GetAlliedArmyDefinitions()
        {
            if (CurrentArmyDefinitionId == 0) return null;
            using (var client = new WarGameServiceClient())
            {
                return client.GetAlliedArmyDefinitions(CurrentArmyDefinitionId);
            }
        }

        public ArmyDefinitions GetFilteredAlliedArmyDefinitions(int minYear, int maxYear)
        {
            if (minYear == maxYear) return null;
            using (var client = new WarGameServiceClient())
            {
                return client.GetArmyDefinitionsForPeriod(CurrentArmyDefinitionId, minYear, maxYear);
            }
        }

        public int AddAllyDefinition(AlliedArmyDefinition definition)
        {
            if (CurrentArmyDefinitionId == 0) return 0;
            using (var client = new WarGameServiceClient())
            {
                return client.PutAlliedArmyDefinition(CurrentArmyDefinitionId, definition.Id, definition);
            }
        }

        public void DeleteAllyDefinition(int id)
        {
            if (CurrentArmyDefinitionId == 0 || id == 0) return;
            using (var client = new WarGameServiceClient())
            {
                client.DeleteAlliedArmyDefinition(CurrentArmyDefinitionId, id);
                CurrentArmyDefinitionId = 0;
            }
        }
    }
}