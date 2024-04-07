using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Common
{

    [AttributeUsage(AttributeTargets.Field)]
    public class SerializedOptionAttribute(string serializedValue) : Attribute
    {
        public string SerializedValue { get; } = serializedValue;
    }

    public static class SerializedEnumAttributeExtensions
    {
        public static string Serialize<T>(this T direction) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"{typeof(T)} is not a enum");
            }

            var enumMember = typeof(T).GetField(direction.ToString())
                ?? throw new ArgumentException($"{typeof(T)} enum member \"{direction}\" not found");

            return Attribute.GetCustomAttribute(enumMember, typeof(SerializedOptionAttribute)) is SerializedOptionAttribute attribute
                ? attribute.SerializedValue
                : throw new ArgumentException($"{typeof(T)} enum is missing {nameof(SerializedOptionAttribute)}");
        }
    }
}
