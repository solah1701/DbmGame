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
        public decimal? Cost { get { return GetUnitCost(); } set { } }
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
        public bool IsAlly { get; set; }
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

        private decimal? GetUnitCost()
        {
            var table = new Dictionary<Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>, decimal?>
            {
                // Elephants
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Elephants), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Elephants), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Elephants), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Elephants), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Elephants), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Elephants), 20 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Elephants), 16 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Elephants), 14 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Elephants), null },
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
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Cavalry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Cavalry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Cavalry), 9 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Cavalry), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Cavalry), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Cavalry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Cavalry), null },
                // Light Horse
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.LightHorse), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.LightHorse), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.LightHorse), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.LightHorse), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.LightHorse), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.LightHorse), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.LightHorse), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.LightHorse), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.LightHorse), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.LightHorse), null },
                // Camelry
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Camelry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Camelry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Camelry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Camelry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Camelry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Camelry), 11 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Camelry), 6 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Camelry), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Camelry), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Camelry), 9 },
                // Expendables
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Expendables), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Expendables), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Expendables), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Expendables), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Expendables), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Expendables), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Expendables), 10 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Expendables), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Expendables), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Expendables), null },
                // Spears
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Spear), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Spear), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Spear), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Spear), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Spear), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Spear), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Spear), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Spear), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Spear), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Spear), null },
                // Pike
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Pike), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Pike), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Pike), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Pike), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Pike), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Pike), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Pike), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Pike), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Pike), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Pike), 4 },
                // Blades
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Blades), 9 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Blades), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Blades), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Blades), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Blades), 8 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Blades), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Blades), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Blades), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Blades), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Blades), 6 },
                // Warband
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Warband), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Warband), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Warband), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Warband), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Warband), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Warband), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Warband), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Warband), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Warband), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Warband), null },
                // Auxilia
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Auxilia), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Auxilia), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Auxilia), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Auxilia), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Auxilia), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Auxilia), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Auxilia), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Auxilia), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Auxilia), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Auxilia), 3 },
                // Bowmen
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Bow), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Bow), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Bow), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Bow), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Bow), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Bow), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Bow), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Bow), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Bow), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Bow), 5 },
                // Psiloi
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Psiloi), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Psiloi), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Psiloi), 1 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Psiloi), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Psiloi), 8 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Psiloi), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Psiloi), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Psiloi), 1 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Psiloi), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Psiloi), 8 },
                // Artillery
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Artillary), 10 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Artillary), 8 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Artillary), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Artillary), 10 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Artillary), 5 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Artillary), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Artillary), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Artillary), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Artillary), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Artillary), null },
                // War Wagons
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.WarWagons), 14 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.WarWagons), 10 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.WarWagons), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.WarWagons), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.WarWagons), 7 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.WarWagons), 10 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.WarWagons), 8 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.WarWagons), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.WarWagons), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.WarWagons), 6 },
                // Hordes
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Hordes), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Hordes), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Hordes), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Hordes), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Hordes), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Hordes), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Hordes), 1 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Hordes), new decimal(0.5) },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Hordes), 1 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Hordes), null },
                // Galleys
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Galleys), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Galleys), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Galleys), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Galleys), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Galleys), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Galleys), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Galleys), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Galleys), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Galleys), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Galleys), null },
                // Ships
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Ships), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Ships), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Ships), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Ships), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Ships), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Ships), 4 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Ships), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Ships), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Ships), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Ships), 6 },
                // Boats
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Boats), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Boats), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Boats), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Boats), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Boats), 6 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Boats), 3 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Boats), 2 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Boats), 1 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Boats), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Boats), null },
                // Baggage
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Superior, UnitTypeEnum.Baggage), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Ordinary, UnitTypeEnum.Baggage), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Inferior, UnitTypeEnum.Baggage), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Fast, UnitTypeEnum.Baggage), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Regular, GradeTypeEnum.Exception, UnitTypeEnum.Baggage), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Superior, UnitTypeEnum.Baggage), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Ordinary, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Inferior, UnitTypeEnum.Baggage), 0 },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Fast, UnitTypeEnum.Baggage), null },
                { new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineTypeEnum.Irregular, GradeTypeEnum.Exception, UnitTypeEnum.Baggage), null },
            };
            var additions = 0;
            if (IsChariot && (UnitType == UnitTypeEnum.Knights || UnitType == UnitTypeEnum.Cavalry)) additions -= 1;
            if (IsMountedInfantry && DispositionType == DispositionTypeEnum.Foot) additions += 1;
            if (IsGeneral && !IsAlly && DisciplineType == DisciplineTypeEnum.Regular) additions += 20;
            if (IsGeneral && !IsAlly && DisciplineType == DisciplineTypeEnum.Irregular) additions += 10;
            if (IsGeneral && IsAlly && DisciplineType == DisciplineTypeEnum.Regular) additions += 10;
            if (IsGeneral && IsAlly && DisciplineType == DisciplineTypeEnum.Irregular) additions += 5;
            return
                table[new Tuple<DisciplineTypeEnum, GradeTypeEnum, UnitTypeEnum>(DisciplineType, GradeType, UnitType)] + additions;
        }
    }
}