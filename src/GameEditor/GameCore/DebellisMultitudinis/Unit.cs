using System;
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
        public decimal Cost { get; set; }
        [DataMember]
        public int Upkeep { get; set; }
        [DataMember]
        public int ConstructionTime { get; set; }
        [DataMember]
        public bool IsGeneral { get; set; }
        [DataMember]
        public bool IsChariot { get; set; }
        [DataMember]
        public bool IsMountedInfantry { get; set; }
        [DataMember]
        public DisciplineTypeEnum DisciplineType { get; set; }
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

        private decimal GetUnitCost()
        {
            var table = new Dictionary<Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>, decimal>
            {
                // Elephants
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Elephants), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Elephants), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Elephants), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Elephants), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Elephants), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Elephants), 20 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Elephants), 16 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Elephants), 14 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Elephants), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Elephants), 22 },
                // Knights
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Knights), 15 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Knights), 12 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Knights), 10 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Knights), 11 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Knights), 13 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Knights), 12 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Knights), 10 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Knights), 8 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Knights), 9 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Knights), 11 },
                // Cavalry
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Cavalry), 10 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Cavalry), 8 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Cavalry), 6 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Cavalry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Cavalry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Cavalry), 9 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Cavalry), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Cavalry), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Cavalry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Cavalry), 0 },
                // Light Horse
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.LightHorse), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.LightHorse), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.LightHorse), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.LightHorse), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.LightHorse), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.LightHorse), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.LightHorse), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.LightHorse), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.LightHorse), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.LightHorse), 0 },
                // Camelry
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Camelry), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Camelry), 0 },
                // Expendables
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Expendables), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Expendables), 0 },
                // Spears
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Spear), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Spear), 0 },
                // Pike
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Pike), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Pike), 0 },
                // Blades
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Blades), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Blades), 0 },
                // Warband
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Warband), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Warband), 0 },
                // Auxilia
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Auxilia), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Auxilia), 0 },
                // Bowmen
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Bow), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Bow), 0 },
                // Psiloi
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Psiloi), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Psiloi), 0 },
                // Artillery
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Artillary), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Artillary), 0 },
                // War Wagons
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.WarWagons), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.WarWagons), 0 },
                // Hordes
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Hordes), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Hordes), 0 },
                // Galleys
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Galleys), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Galleys), 0 },
                // Ships
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Ships), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Ships), 0 },
                // Boats
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Boats), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Boats), 0 },
                // Baggage
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Baggage), 0 },
            };
            return
                table[new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineType, GradeType, UnitType)];
        }
    }
}