using System.Collections.Generic;
using System.Linq;
using GameCore.Wcf.Game;

namespace GameCore.Wcf.Helpers
{
    public class WarGameModel : IWarGameModel
    {
        private Dictionary<string, Game.User> Users { get; set; }
        private Dictionary<string, Army> Armies { get; set; }
        private Dictionary<string, ArmyCommand> ArmyCommands { get; set; }
        private Dictionary<string, ArmyGroup> ArmyGroups { get; set; }
        private Dictionary<string, Unit> Units { get; set; }
        private Dictionary<string, Battle> Battles { get; set; }

        public Game.User FindUser(string username)
        {
            return UsersContainsKey(username) ? Users[username] : null;
        }

        public void SetUser(string username, Game.User user)
        {
            Users[username] = user;
        }

        public bool UsersContainsKey(string username)
        {
            return Users.ContainsKey(username);
        }

        public void UsersRemove(string username)
        {
            Users.Remove(username);
        }

        public Army GetUserArmy(string username, string id)
        {
            if (!Armies.ContainsKey(id) || Armies[id].User != username) return null;
            return Armies[id];
        }

        public Battle GetUserBattle(string username, string id)
        {
            if (!Battles.ContainsKey(id) ||
                (Battles[id].AttackerUser != username && Battles[id].DefenderUser != username))
                return null;
            return Battles[id];
        }

        public void BattlesAdd(string id, Battle battle)
        {
            Battles.Add(id, battle);
        }

        public bool BattleContainsKey(string id)
        {
            return Battles.ContainsKey(id);
        }

        public bool IsBattleAttacker(string id, string username)
        {
            return Battles[id].AttackerUser == username;
        }

        public bool IsBattleDefender(string id, string username)
        {
            return Battles[id].DefenderUser == username;
        }

        public void SetBattle(string id, Battle battle)
        {
            Battles[id] = battle;
        }

        public void BattlesRemove(string id)
        {
            Battles.Remove(id);
        }

        public Army FindArmy(string id)
        {
            return ArmiesContainsKey(id) ? Armies[id] : null;
        }

        public Armies ArmiesFindFromUser(string username)
        {
            return new Armies(Armies.Values.Where(a => a.User == username).ToList());
        }

        public bool ArmiesContainsKey(string id)
        {
            return Armies.ContainsKey(id);
        }

        public bool IsArmiesUser(string username, string id)
        {
            return Armies[id].User == username;
        }

        public void ArmiesAdd(string id, Army army)
        {
            Armies.Add(id, army);
        }

        public void ArmiesRemove(string id)
        {
            Armies.Remove(id);
        }

        public void SetArmy(string id, Army army)
        {
            Armies[id] = army;
        }

    }
}