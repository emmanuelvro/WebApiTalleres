using System.ComponentModel;
using System.Reflection;

namespace System
{
    public static class ExtendEnum
    {
        public static String GetDescription(this Enum e)
        {
            String result = String.Empty;

            MemberInfo[] mi = e.GetType().GetMember(e.ToString());
            if (mi != null && mi.Length > 0)
            {
                Object[] attrs = mi[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    result = ((DescriptionAttribute)attrs[0]).Description;
                }
                else
                {
                    result = e.ToString();
                }
            }
            else
            {
                result = e.ToString();
            }

            return result;
        }
    }
}