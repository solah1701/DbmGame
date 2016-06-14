using System.Runtime.Serialization;

namespace GameCore.WcfService.DebellisMultitudinis.Enumerations
{
    [DataContract]
    public enum DispositionTypeEnum
    {
        [EnumMember]
        Mounted,
        [EnumMember]
        Foot,
        [EnumMember]
        Naval
    }
}