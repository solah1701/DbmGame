using System.Collections.Generic;
using System.Runtime.Serialization;
using GameCore.DebellisMultitudinis.Enumerations;

namespace GameCore.DebellisMultitudinis
{
    [DataContract(Name = "Unit", Namespace = "GameCore.DebellisMultitudinis")]
    public class Unit : IConstructableUnit
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Attack { get; set; }
        [DataMember]
        public int Defence { get; set; }
        [DataMember]
        public int Move { get; set; }
        [DataMember]
        public int Range { get; set; }
        [DataMember]
        public int Speed { get; set; }
        [DataMember]
        public int Stamina { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public int Morale { get; set; }
        [DataMember]
        public int Cost { get; set; }
        [DataMember]
        public int Upkeep { get; set; }
        [DataMember]
        public int ConstructionTime { get; set; }
        [DataMember]
        public UnitTypeEnum UnitType { get; set; }
        [DataMember]
        public GradeTypeEnum GradeType { get; set; }
        public DispositionTypeEnum DispositionType => GetDispositionType();

        private DispositionTypeEnum GetDispositionType()
        {
            var table = new Dictionary<UnitTypeEnum, DispositionTypeEnum>
            {
                { UnitTypeEnum.Elephants, DispositionTypeEnum.Mounted },
                { UnitTypeEnum.Knights, DispositionTypeEnum.Mounted },
                { UnitTypeEnum.Cavalry, DispositionTypeEnum.Mounted },
                { UnitTypeEnum.LightHorse, DispositionTypeEnum.Mounted },
                { UnitTypeEnum.Camelry, DispositionTypeEnum.Mounted },
                { UnitTypeEnum.Expendables, DispositionTypeEnum.Mounted },
                { UnitTypeEnum.Spear, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Pike, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Blades, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Warband, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Auxilia, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Bow, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Psiloi, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Artillary, DispositionTypeEnum.Foot },
                { UnitTypeEnum.WarWagons, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Hordes, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Baggage, DispositionTypeEnum.Foot },
                { UnitTypeEnum.Galleys, DispositionTypeEnum.Naval },
                { UnitTypeEnum.Ships, DispositionTypeEnum.Naval },
                { UnitTypeEnum.Boats, DispositionTypeEnum.Naval }
            };
            return table[UnitType];
        }
    }
}