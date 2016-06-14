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
                CurrentArmyDefinitionId = id;
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
            throw new System.NotImplementedException();
        }

        public ArmyUnitDefinitions GetArmyUnitDefinitions()
        {
            throw new System.NotImplementedException();
        }

        public int AddArmyUnitDefinitino(ArmyUnitDefinition definition)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteArmyUnitDefinition(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}