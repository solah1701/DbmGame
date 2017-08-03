using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GameCore.DebellisMultitudinis;
using GameCore.DebellisMultitudinis.Enumerations;

namespace GameCore.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        DbmUnit GetUnit(DbmUnit unit);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "GameCore.Wcf.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class DbmUnit //: IDbmUnit
    {
        [DataMember]
        public bool IsGeneral { get; set; }
        [DataMember]
        public bool IsChariot { get; set; }
        [DataMember]
        public bool IsMountedInfantry { get; set; }
        [DataMember]
        public bool IsAlly { get; set; }
        [DataMember]
        public bool IsShooting { get; set; }
        [DataMember]
        public bool IsFortified { get; set; }
        [DataMember]
        public bool IsElevated { get; set; }
        [DataMember]
        public bool IsDoubleElement { get; set; }
        [DataMember]
        public bool IsContactThisRound { get; set; }
        [DataMember]
        public bool IsMobile { get; set; }
        [DataMember]
        public bool IsUnladenNaval { get; set; }
        [DataMember]
        public int EnemyOverlapCount { get; set; }
        [DataMember]
        public int RearSupportCount { get; set; }
        [DataMember]
        public int EnemySupportShootingCount { get; set; }
        [DataMember]
        public DbmUnit SupportingDbmUnit { get; set; }
        //[DataMember]
        //public FortificationTypeEnum FortificationType { get; set; }
        //[DataMember]
        //public TerrainGoingEnum TerrainGoing { get; set; }
        //[DataMember]
        //public DisciplineTypeEnum DisciplineType { get; set; }
        //[DataMember]
        //public UnitTypeEnum UnitType { get; set; }
        //[DataMember]
        //public GradeTypeEnum GradeType { get; set; }
        //[DataMember]
        //public DispositionTypeEnum DispositionType { get; }

        //private IDbmUnit _unit;

        //public DbmUnit()
        //{
        //    _unit = new Unit();
        //}


        //public int GetAttackValue(IDbmUnit opposingDbmUnit)
        //{
        //    return _unit.GetAttackValue(opposingDbmUnit);
        //}

        //public CombatOutcomeEnum GetCombatOutcome(IDbmUnit opposingDbmUnit, int score, int opponentScore)
        //{
        //    return _unit.GetCombatOutcome(opposingDbmUnit, score, opponentScore);
        //}

        //public int GetGradingFactor(IDbmUnit opposingDbmUnit, int score, int opponentScore)
        //{
        //    return _unit.GetGradingFactor(opposingDbmUnit, score, opponentScore);
        //}

        //public int GetRearSupportingFactor(IDbmUnit opposingDbmUnit)
        //{
        //    return _unit.GetRearSupportingFactor(opposingDbmUnit);
        //}

        //public int GetTacticalFactor(IDbmUnit opposingDbmUnit)
        //{
        //    return _unit.GetTacticalFactor(opposingDbmUnit);
        //}
    }
}
