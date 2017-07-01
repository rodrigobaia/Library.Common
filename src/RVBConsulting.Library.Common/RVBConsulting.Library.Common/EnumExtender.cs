using System;
using System.Reflection;

namespace RVBConsulting.Library.Common
{
    /// <summary>
	/// Extender Enum
	/// </summary>
	public class EnumExtender
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(Type enumType, object value)
        {
            string result = string.Empty;

            object enumItem = Enum.GetName(enumType, value);
            FieldInfo fieldInfo = Enum.Parse(enumType, enumItem.ToString()).GetType().GetField(enumItem.ToString());

            object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(EnumExtenderItemAttribute), false);
            if (customAttributes != null && customAttributes.Length > 0)
            {
                EnumExtenderItemAttribute enumExtenderItem = (EnumExtenderItemAttribute)customAttributes[0];
                result = enumExtenderItem.GetDescription();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string[] GetDescriptions(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("enumType is not an Enum.");

            FieldInfo[] fieldsInfo = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            string[] result = new string[fieldsInfo.Length];

            for (int i = 0; i < fieldsInfo.Length; i++)
            {
                object[] customAttributes = fieldsInfo[i].GetCustomAttributes(typeof(EnumExtenderItemAttribute), false);
                if (customAttributes != null && customAttributes.Length > 0)
                {
                    EnumExtenderItemAttribute enumExtenderItem = (EnumExtenderItemAttribute)customAttributes[0];
                    result[i] = enumExtenderItem.GetDescription();
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetExtendedValue(Type enumType, object value)
        {
            string result = null;

            object enumItem = Enum.GetName(enumType, value);
            FieldInfo fieldInfo = Enum.Parse(enumType, enumItem.ToString()).GetType().GetField(enumItem.ToString());

            object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(EnumExtenderItemAttribute), false);
            if (customAttributes != null && customAttributes.Length > 0)
            {
                EnumExtenderItemAttribute enumExtenderItem = (EnumExtenderItemAttribute)customAttributes[0];
                result = enumExtenderItem.GetExtendedValue();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string[] GetExtendedValues(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("enumType não é um Enum.");

            FieldInfo[] fieldsInfo = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            string[] result = new string[fieldsInfo.Length];

            for (int i = 0; i < fieldsInfo.Length; i++)
            {
                object[] customAttributes = fieldsInfo[i].GetCustomAttributes(typeof(EnumExtenderItemAttribute), false);
                if (customAttributes != null && customAttributes.Length > 0)
                {
                    EnumExtenderItemAttribute enumExtenderItem = (EnumExtenderItemAttribute)customAttributes[0];
                    result[i] = enumExtenderItem.GetExtendedValue();
                }
            }

            return result;
        }
    }
}
