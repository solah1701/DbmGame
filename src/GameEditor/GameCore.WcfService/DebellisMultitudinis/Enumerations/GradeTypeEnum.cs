using System.Runtime.Serialization;

namespace GameCore.WcfService.DebellisMultitudinis.Enumerations
{
    [DataContract]
    public enum GradeTypeEnum
    {
        [EnumMember]
        Superior,
        [EnumMember]
        Ordinary,
        [EnumMember]
        Inferior,
        [EnumMember]
        Fast,
        [EnumMember]
        Exception
    }
}