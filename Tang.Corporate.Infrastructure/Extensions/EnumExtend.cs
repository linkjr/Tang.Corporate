using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Infrastructure.Extensions
{
    public static class EnumExtend
    {
        /// <summary>
        /// 返回指定枚举值的描述信息。
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this IComparable enumVal)
        {
            var val = enumVal.ToString();
            Type typ = enumVal.GetType();
            FieldInfo fieldInfo = typ.GetField(enumVal.ToString());
            string result;
            if (fieldInfo == null)
                result = val;
            else
            {
                object[] objs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs == null || objs.Length == 0)
                {
                    result = val;
                }
                else
                {
                    DescriptionAttribute da = (DescriptionAttribute)objs[0];
                    result = da.Description;
                }
            }
            return result;
        }
    }
}
