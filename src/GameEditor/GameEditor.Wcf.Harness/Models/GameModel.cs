using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Models
{
    public class GameModel : IGameModel
    {
        private WarGameServiceClient _client;

        public GameModel()
        {
            _client = new WarGameServiceClient();
        }

        public ArmyDefinitions GetArmyDefinitions()
        {
            return _client.GetArmyDefinitions();
        }

        public ArmyDefinition GetArmyDefinition(int id)
        {
            return _client.GetArmyDefinition(id);
        }

        public int AddArmyDefinition(ArmyDefinition definition)
        {
            return _client.PutArmyDefinition(definition);
        }

        public void DeleteArmyDefinition(int id)
        {
            _client.DeleteArmyDefinition(id);
        }
    }
}