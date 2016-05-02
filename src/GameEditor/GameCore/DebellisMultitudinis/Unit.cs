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
        public bool IsShooting { get; set; }
        public bool IsFortified { get; set; }
        public bool IsElevated { get; set; }
        public bool IsDoubleElement { get; set; }
        public bool IsContactThisRound { get; set; }
        public bool IsMobile { get; set; }
        public bool IsUnladenNaval { get; set; }
        public int EnemyOverlapCount { get; set; }
        public int RearSupportCount { get; set; }
        public int EnemySupportShootingCount { get; set; }
        public IDbmUnit SupportingDbmUnit { get; set; }
        public TerrainGoingEnum TerrainGoing { get; set; }
        public FortificationTypeEnum FortificationType { get; set; }
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

        public int GetAttackValue(IDbmUnit opponentDbmUnit)
        {
            var table = new Dictionary<UnitTypeEnum, int>
            {
                { UnitTypeEnum.Elephants, UnitAttackValue(opponentDbmUnit, 5, 3, 4, 4) },
                { UnitTypeEnum.Spear, 4 },
                { UnitTypeEnum.Expendables, 4 },
                { UnitTypeEnum.Artillary, 4 },
                { UnitTypeEnum.Knights, UnitAttackValue(opponentDbmUnit, 4, 4, 4, 3) },
                { UnitTypeEnum.WarWagons, UnitAttackValue(opponentDbmUnit, 4, 4, 4, 3) },
                { UnitTypeEnum.Pike, UnitAttackValue(opponentDbmUnit, 4, 4, 3, 3) },
                { UnitTypeEnum.Bow, UnitAttackValue(opponentDbmUnit, 4, 3, 2, 2) },
                { UnitTypeEnum.Camelry, UnitAttackValue(opponentDbmUnit, 4, 3, 2, 2) },
                { UnitTypeEnum.Blades, UnitAttackValue(opponentDbmUnit, 3, 4, 4, 5) },
                { UnitTypeEnum.Cavalry, 3 },
                { UnitTypeEnum.Galleys, 3 },
                { UnitTypeEnum.Ships, 3 },
                { UnitTypeEnum.Warband, UnitAttackValue(opponentDbmUnit, 2, 3, 3, 3) },
                { UnitTypeEnum.Auxilia, UnitAttackValue(opponentDbmUnit, 2, 3, 3, 3) },
                { UnitTypeEnum.LightHorse, 2 },
                { UnitTypeEnum.Psiloi, 2 },
                { UnitTypeEnum.Hordes, 2 },
                { UnitTypeEnum.Boats, 2 },
                { UnitTypeEnum.Baggage, 1 }
            };
            return table[UnitType];
        }

        public int GetRearSupportingFactor(IDbmUnit opposingDbmUnit)
        {
            var result = 0;
            if (RearSupportCount == 0) return result;
            if (IsDoubleElement && UnitType == UnitTypeEnum.Knights && GradeType == GradeTypeEnum.Inferior &&
                (opposingDbmUnit.UnitType == UnitTypeEnum.Knights || opposingDbmUnit.UnitType == UnitTypeEnum.Cavalry ||
                 opposingDbmUnit.UnitType == UnitTypeEnum.LightHorse ||
                 opposingDbmUnit.DispositionType == DispositionTypeEnum.Foot ||
                 (opposingDbmUnit.UnitType != UnitTypeEnum.Artillary && opposingDbmUnit.IsShooting)))
                result += 1;
            if (UnitType == UnitTypeEnum.Cavalry && SupportingDbmUnit.UnitType == UnitTypeEnum.Cavalry &&
                (opposingDbmUnit.UnitType == UnitTypeEnum.Cavalry || opposingDbmUnit.UnitType == UnitTypeEnum.LightHorse) &&
                ((GradeType == GradeTypeEnum.Inferior && SupportingDbmUnit.GradeType == GradeTypeEnum.Inferior) ||
                 (GradeType != GradeTypeEnum.Inferior && SupportingDbmUnit.GradeType == GradeTypeEnum.Ordinary)))
                result += Math.Min(RearSupportCount, 1);
            if (UnitType == UnitTypeEnum.Spear && SupportingDbmUnit.UnitType == UnitTypeEnum.Spear &&
                GradeType == SupportingDbmUnit.GradeType &&
                TerrainGoing == TerrainGoingEnum.Good && SupportingDbmUnit.TerrainGoing == TerrainGoingEnum.Good)
                result += Math.Min(RearSupportCount, 1);
            if (UnitType == UnitTypeEnum.Pike && SupportingDbmUnit.UnitType == UnitTypeEnum.Pike &&
                GradeType != GradeTypeEnum.Exception &&
                GradeType == SupportingDbmUnit.GradeType && TerrainGoing == TerrainGoingEnum.Good
                && SupportingDbmUnit.TerrainGoing == TerrainGoingEnum.Good)
                result += Math.Min(RearSupportCount, 3);
            if (UnitType == UnitTypeEnum.Pike && GradeType == GradeTypeEnum.Exception &&
                (SupportingDbmUnit.GradeType == GradeTypeEnum.Exception ||
                 SupportingDbmUnit.GradeType == GradeTypeEnum.Inferior) && TerrainGoing == TerrainGoingEnum.Good &&
                SupportingDbmUnit.TerrainGoing == TerrainGoingEnum.Good)
                result += Math.Min(RearSupportCount, 2);
            if (UnitType == UnitTypeEnum.Blades && SupportingDbmUnit.UnitType == UnitTypeEnum.Blades && opposingDbmUnit.UnitType == UnitTypeEnum.Knights ||
                (opposingDbmUnit.UnitType == UnitTypeEnum.Camelry && opposingDbmUnit.GradeType == GradeTypeEnum.Superior))
                result += Math.Min(RearSupportCount, 1);
            if (UnitType == UnitTypeEnum.Warband && SupportingDbmUnit.UnitType == UnitTypeEnum.Warband)
                result += Math.Min(RearSupportCount, 1);
            if (UnitType == UnitTypeEnum.Warband && GradeType == GradeTypeEnum.Superior &&
                opposingDbmUnit.DispositionType == DispositionTypeEnum.Mounted &&
                SupportingDbmUnit.UnitType == UnitTypeEnum.Warband &&
                SupportingDbmUnit.GradeType == GradeTypeEnum.Superior)
                result += Math.Min(RearSupportCount, 3) - 1;
            if (UnitType == UnitTypeEnum.Auxilia & GradeType == GradeTypeEnum.Exception &&
                SupportingDbmUnit.UnitType == UnitTypeEnum.Auxilia &&
                SupportingDbmUnit.GradeType == GradeTypeEnum.Exception)
                result += Math.Min(RearSupportCount, 1);
            if (UnitType == UnitTypeEnum.Psiloi && opposingDbmUnit.UnitType == UnitTypeEnum.Psiloi &&
                SupportingDbmUnit.UnitType == UnitTypeEnum.Psiloi &&
                SupportingDbmUnit.GradeType == GradeTypeEnum.Ordinary)
                result += Math.Min(RearSupportCount, 1);
            return result;
        }

        public int GetTacticalFactor(IDbmUnit opposingDbmUnit)
        {
            var result = 0;
            if (IsGeneral) result += 1;
            if (IsElevated && !IsShooting && !opposingDbmUnit.IsShooting) result += 1;
            if (opposingDbmUnit.IsShooting) result -= Math.Min(EnemySupportShootingCount, 2);
            if (!opposingDbmUnit.IsShooting) result -= EnemyOverlapCount;
            if (DispositionType == DispositionTypeEnum.Mounted && (IsFortified || opposingDbmUnit.IsFortified) ||
                opposingDbmUnit.TerrainGoing != TerrainGoingEnum.Good)
                result -= 2;
            if (UnitType == UnitTypeEnum.Blades ||
                (UnitType == UnitTypeEnum.Warband &&
                 (GradeType == GradeTypeEnum.Superior || GradeType == GradeTypeEnum.Ordinary)) &&
                opposingDbmUnit.DispositionType == DispositionTypeEnum.Foot &&
                opposingDbmUnit.TerrainGoing != TerrainGoingEnum.Good)
                result -= 2;
            if ((UnitType == UnitTypeEnum.Spear || UnitType == UnitTypeEnum.Pike ||
                (UnitType == UnitTypeEnum.Hordes && GradeType == GradeTypeEnum.Ordinary) ||
                UnitType == UnitTypeEnum.WarWagons ||
                UnitType == UnitTypeEnum.Baggage) && TerrainGoing != TerrainGoingEnum.Good)
                result -= 2;
            if (DispositionType != DispositionTypeEnum.Foot || !IsFortified) return result;
            if (UnitType == UnitTypeEnum.WarWagons) return result;
            if (FortificationType == FortificationTypeEnum.Permanent && opposingDbmUnit.UnitType == UnitTypeEnum.Artillary && opposingDbmUnit.GradeType == GradeTypeEnum.Superior && opposingDbmUnit.IsShooting) return result;
            if (FortificationType == FortificationTypeEnum.Temporary &&
                opposingDbmUnit.UnitType == UnitTypeEnum.Artillary ||
                (opposingDbmUnit.UnitType == UnitTypeEnum.Psiloi && opposingDbmUnit.GradeType == GradeTypeEnum.Exception))
                return result;
            if ((opposingDbmUnit.UnitType == UnitTypeEnum.WarWagons &&
                 opposingDbmUnit.GradeType == GradeTypeEnum.Superior) ||
                (opposingDbmUnit.UnitType == UnitTypeEnum.Ships && opposingDbmUnit.GradeType == GradeTypeEnum.Exception))
                return result;
            result += 2;
            return result;
        }

        public int GetGradingFactor(IDbmUnit opposingDbmUnit, int score, int opponentScore)
        {
            var result = 0;
            if (GradeType == GradeTypeEnum.Superior &&
                (opposingDbmUnit.GradeType != GradeTypeEnum.Superior || opposingDbmUnit.UnitType != UnitType) &&
                (opposingDbmUnit.UnitType != UnitTypeEnum.Elephants ||
                 opposingDbmUnit.UnitType != UnitTypeEnum.Artillary))
            {
                if (score < opponentScore && (opposingDbmUnit.IsShooting || !IsShooting)) result += 1;
                if (score > opponentScore && IsShooting) result += 1;
            }
            if (GradeType == GradeTypeEnum.Inferior &&
                (opposingDbmUnit.IsShooting || !IsShooting && score <= opponentScore))
                result -= 1;
            if (GradeType == GradeTypeEnum.Fast && score < opponentScore &&
                ((opposingDbmUnit.IsShooting && opposingDbmUnit.UnitType != UnitTypeEnum.Artillary) || !IsShooting))
                result -= 1;
            return result;
        }

        public CombatOutcomeEnum GetCombatOutcome(IDbmUnit opposingDbmUnit, int score, int opponentScore)
        {
            if (score == opponentScore && UnitType == UnitTypeEnum.Expendables) return CombatOutcomeEnum.Destroyed;
            if (score < opponentScore && 2 * score > opponentScore)
            {
                if (UnitType == UnitTypeEnum.Elephants)
                {
                    if (opposingDbmUnit.UnitType == UnitTypeEnum.LightHorse ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Auxilia ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Psiloi ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Artillary ||
                        (!IsShooting && !opposingDbmUnit.IsShooting && TerrainGoing == TerrainGoingEnum.Difficult))
                        return CombatOutcomeEnum.Destroyed;
                    return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.Knights)
                {
                    if (opposingDbmUnit.UnitType == UnitTypeEnum.Elephants ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Expendables ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.LightHorse ||
                        (opposingDbmUnit.UnitType == UnitTypeEnum.Bow &&
                         opposingDbmUnit.GradeType == GradeTypeEnum.Superior && !opposingDbmUnit.IsShooting &&
                         IsContactThisRound) ||
                        (!IsShooting && !opposingDbmUnit.IsShooting && TerrainGoing == TerrainGoingEnum.Difficult))
                        return CombatOutcomeEnum.Destroyed;
                    return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.Expendables) return CombatOutcomeEnum.Destroyed;
                if (DispositionType == DispositionTypeEnum.Mounted)
                {
                    if (TerrainGoing == TerrainGoingEnum.Difficult && !IsShooting && !opposingDbmUnit.IsShooting ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Expendables)
                        return CombatOutcomeEnum.Flee;
                    return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.Spear || UnitType == UnitTypeEnum.Pike || UnitType == UnitTypeEnum.Blades)
                {
                    if ((opposingDbmUnit.UnitType == UnitTypeEnum.Knights ||
                         (opposingDbmUnit.UnitType == UnitTypeEnum.Camelry &&
                          opposingDbmUnit.GradeType == GradeTypeEnum.Superior) ||
                         opposingDbmUnit.UnitType == UnitTypeEnum.Expendables) &&
                        opposingDbmUnit.TerrainGoing == TerrainGoingEnum.Good ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Warband)
                        return CombatOutcomeEnum.Destroyed;
                    return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.Warband)
                {
                    if ((opposingDbmUnit.UnitType == UnitTypeEnum.Knights ||
                         (opposingDbmUnit.UnitType == UnitTypeEnum.Camelry &&
                          opposingDbmUnit.GradeType == GradeTypeEnum.Superior) ||
                         opposingDbmUnit.UnitType == UnitTypeEnum.Expendables) &&
                        opposingDbmUnit.TerrainGoing == TerrainGoingEnum.Good ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Elephants)
                        return CombatOutcomeEnum.Destroyed;
                    return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.Auxilia)
                {
                    if ((opposingDbmUnit.UnitType == UnitTypeEnum.Knights ||
                         (opposingDbmUnit.UnitType == UnitTypeEnum.Camelry &&
                          opposingDbmUnit.GradeType == GradeTypeEnum.Superior)) &&
                        opposingDbmUnit.TerrainGoing == TerrainGoingEnum.Good)
                        return CombatOutcomeEnum.Destroyed;
                    return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.Bow)
                {
                    if (opposingDbmUnit.DispositionType == DispositionTypeEnum.Mounted && !IsShooting &&
                        !opposingDbmUnit.IsShooting)
                        return CombatOutcomeEnum.Destroyed;
                    return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.Psiloi)
                {
                    if ((opposingDbmUnit.UnitType == UnitTypeEnum.Knights ||
                         opposingDbmUnit.UnitType == UnitTypeEnum.Cavalry ||
                         opposingDbmUnit.UnitType == UnitTypeEnum.LightHorse ||
                         (opposingDbmUnit.UnitType == UnitTypeEnum.Camelry &&
                          opposingDbmUnit.GradeType == GradeTypeEnum.Superior)) &&
                        opposingDbmUnit.TerrainGoing == TerrainGoingEnum.Good)
                        return CombatOutcomeEnum.Destroyed;
                    if (opposingDbmUnit.UnitType == UnitTypeEnum.Elephants ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Expendables || opposingDbmUnit.IsShooting ||
                        (TerrainGoing != TerrainGoingEnum.Good && opposingDbmUnit.TerrainGoing != TerrainGoingEnum.Good))
                        return CombatOutcomeEnum.Recoil;
                    return CombatOutcomeEnum.Flee;
                }
                if (UnitType == UnitTypeEnum.Artillary)
                {
                    if (!IsShooting && !opposingDbmUnit.IsShooting) return CombatOutcomeEnum.Destroyed;
                    if (!IsFortified) return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.WarWagons)
                {
                    if ((opposingDbmUnit.UnitType == UnitTypeEnum.Artillary &&
                         opposingDbmUnit.GradeType != GradeTypeEnum.Exception) ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Elephants)
                        return CombatOutcomeEnum.Destroyed;
                    if (GradeType == GradeTypeEnum.Superior && opposingDbmUnit.IsFortified)
                        return CombatOutcomeEnum.Recoil;
                }
                if (UnitType == UnitTypeEnum.Hordes)
                {
                    if ((opposingDbmUnit.UnitType == UnitTypeEnum.Knights ||
                         (opposingDbmUnit.UnitType == UnitTypeEnum.Camelry &&
                          opposingDbmUnit.GradeType == GradeTypeEnum.Superior) ||
                         opposingDbmUnit.UnitType == UnitTypeEnum.Expendables) &&
                        opposingDbmUnit.TerrainGoing == TerrainGoingEnum.Good ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Elephants ||
                        opposingDbmUnit.UnitType == UnitTypeEnum.Warband)
                        return CombatOutcomeEnum.Destroyed;
                    return CombatOutcomeEnum.Recoil;
                }
                if (DispositionType == DispositionTypeEnum.Naval)
                {
                    if(!IsUnladenNaval)return CombatOutcomeEnum.Recoil;
                    if (IsUnladenNaval && opposingDbmUnit.UnitType != UnitTypeEnum.Expendables)
                        return CombatOutcomeEnum.Destroyed;
                }
                if (UnitType == UnitTypeEnum.Baggage) return IsMobile ? CombatOutcomeEnum.Flee : CombatOutcomeEnum.Destroyed;
            }
            if (2*score > opponentScore) return CombatOutcomeEnum.Continue;
            if (UnitType == UnitTypeEnum.Cavalry)
            {
                if (TerrainGoing == TerrainGoingEnum.Good &&
                    (opposingDbmUnit.UnitType == UnitTypeEnum.Spear || opposingDbmUnit.UnitType == UnitTypeEnum.Pike) ||
                    opposingDbmUnit.DispositionType == DispositionTypeEnum.Naval) return CombatOutcomeEnum.Flee;
                return CombatOutcomeEnum.Destroyed;
            }
            if (UnitType == UnitTypeEnum.LightHorse)
            {
                if ((opposingDbmUnit.DispositionType == DispositionTypeEnum.Mounted ||
                     opposingDbmUnit.UnitType == UnitTypeEnum.Bow ||
                     opposingDbmUnit.UnitType == UnitTypeEnum.WarWagons ||
                     TerrainGoing == TerrainGoingEnum.Difficult) && !IsShooting && !opposingDbmUnit.IsShooting)
                    return CombatOutcomeEnum.Destroyed;
                return CombatOutcomeEnum.Flee;
            }
            if (UnitType == UnitTypeEnum.Psiloi)
            {
                if ((opposingDbmUnit.DispositionType == DispositionTypeEnum.Mounted &&
                     opposingDbmUnit.TerrainGoing == TerrainGoingEnum.Good) ||
                    opposingDbmUnit.UnitType == UnitTypeEnum.Bow ||
                    opposingDbmUnit.UnitType == UnitTypeEnum.Auxilia |
                    opposingDbmUnit.UnitType == UnitTypeEnum.Psiloi || GradeType == GradeTypeEnum.Exception)
                    return CombatOutcomeEnum.Destroyed;
                return CombatOutcomeEnum.Flee;
            }
            if (DispositionType != DispositionTypeEnum.Naval)
                return opposingDbmUnit.DispositionType == DispositionTypeEnum.Naval
                    ? CombatOutcomeEnum.Flee
                    : CombatOutcomeEnum.Destroyed;
            if (!IsUnladenNaval && opposingDbmUnit.UnitType == UnitTypeEnum.Artillary ||
                (opposingDbmUnit.UnitType != UnitTypeEnum.Expendables &&
                 !opposingDbmUnit.IsShooting)) return CombatOutcomeEnum.Destroyed;
            if (!IsUnladenNaval && opposingDbmUnit.IsShooting) return CombatOutcomeEnum.Flee;
            if (opposingDbmUnit.UnitType != UnitTypeEnum.Expendables) return CombatOutcomeEnum.Destroyed;
            return opposingDbmUnit.DispositionType == DispositionTypeEnum.Naval ? CombatOutcomeEnum.Flee : CombatOutcomeEnum.Destroyed;
        }

        private int UnitAttackValue(IDbmUnit opponentDbmUnit, int mounted, int naval, int shooting, int foot)
        {
            if (IsShooting) return shooting;
            var table = new Dictionary<DispositionTypeEnum, int>
            {
                { DispositionTypeEnum.Mounted, mounted },
                { DispositionTypeEnum.Naval, naval },
                { DispositionTypeEnum.Foot, foot }
            };
            return table[opponentDbmUnit.DispositionType];
        }

    }
}