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

        public ArmyDefinition GetArmyDefinition(string id)
        {
            return _client.GetArmyDefinition(id);
        }

        public void AddArmyDefinition(ArmyDefinition definition)
        {
            _client.PutArmyDefinition(definition);
        }
    }
}