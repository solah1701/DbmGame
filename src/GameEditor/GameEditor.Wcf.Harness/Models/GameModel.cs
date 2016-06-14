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
                return client.PutArmyDefinition(definition); 
            }
        }

        public void DeleteArmyDefinition(int id)
        {
            using (var client = new WarGameServiceClient())
            {
                client.DeleteArmyDefinition(id); 
            }
        }
    }
}