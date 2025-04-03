using System.Runtime.Serialization;

namespace SQL_Result_To_Query.DataModels;
public enum OptionEnum
{
    [EnumMember(Value = "String")]
    String,
    [EnumMember(Value = "Number")]
    Number,
    [EnumMember(Value = "Empty")]
    Empty
}
