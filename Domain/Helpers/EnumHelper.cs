using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Coink.Microservice.Domain.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value
                .GetType()
                .GetField(value.ToString())!;

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes != null && attributes.Length > 0
                ? attributes[0].Description
                : value.ToString();
        }

        public static string GetEnumNameFromDescription<TEnum>(string description) where TEnum : struct, Enum
        {
            foreach (var field in typeof(TEnum).GetFields())
            {
                if (
                    Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute &&
                    attribute.Description == description
                )
                {
                    return field.Name;
                }
            }

            return string.Empty;
        }

        public static bool ExistValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (
                    Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute &&
                    attribute.Description == description
                )
                {
                    return true;
                }
            }

            return false;
        }

        public static T GetEnumFromDescription<T>(string description) where T : Enum
        {
            var enumType = typeof(T);
            var enumValues = Enum.GetValues(enumType);

            foreach (var enumValue in enumValues)
            {
                var field = enumType.GetField(enumValue.ToString()!);
                var attribute = Attribute.GetCustomAttribute(field!, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null && attribute.Description == description)
                {
                    return (T)enumValue;
                }
            }

            return default!;
        }
    }
}
