using System.Runtime.Serialization;

namespace GameCore.WcfService.DebellisMultitudinis.Enumerations
{
    [DataContract]
    public enum DisciplineTypeEnum
    {
        [EnumMember]
        Regular,
        [EnumMember]
        Irregular
    }
}