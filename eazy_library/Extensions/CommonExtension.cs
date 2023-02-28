using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace eazy_library.Extensions
{
    public static class CommonExtension
    {
        public static string PasswordHashed(this string password, string passwordSalt)
        {
            string concatSaltAndPassword = string.Concat(password, passwordSalt);

            var securityKey = Encoding.UTF8.GetBytes(concatSaltAndPassword);

            var sha1 = System.Security.Cryptography.SHA1.Create();

            var hash = sha1.ComputeHash(securityKey);

            return BitConverter.ToString(hash).Replace("-", "");
        }

        public static string GetNormalizeString(this string str)
        {
            return str.Trim().Replace(' ', '-').Replace("\"", "");
        }

        public static string GetNormalize(this string str)
        {
            return str.Trim().Replace('-', '_');
        }

        public static string RemoveSpecialCharactersVn(this string str)
        {
            var strNotVn = RemoveSign4VietnameseString(str);
            var sb = new StringBuilder();
            foreach (char c in strNotVn)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ' || c == '_' || c == '-')
                {
                    sb.Append(c);
                }
            }
            var text = ReplaceSpaceToPlus(sb.ToString());
            return text;
        }

        public static string ReplaceSpaceToPlus(string text)
        {
            return Regex.Replace(text, @"\s+", "-").Trim();
        }

        private static readonly string[] VietnameseSigns = new[]
                                                               {
                                                                   "aAeEoOuUiIdDyY",
                                                                   "áàạảãâấầậẩẫăắằặẳẵ",
                                                                   "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                                                                   "éèẹẻẽêếềệểễ",
                                                                   "ÉÈẸẺẼÊẾỀỆỂỄ",
                                                                   "óòọỏõôốồộổỗơớờợởỡ",
                                                                   "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                                                                   "úùụủũưứừựửữ",
                                                                   "ÚÙỤỦŨƯỨỪỰỬỮ",
                                                                   "íìịỉĩ",
                                                                   "ÍÌỊỈĨ",
                                                                   "đ",
                                                                   "Đ",
                                                                   "ýỳỵỷỹ",
                                                                   "ÝỲỴỶỸ"
                                                               };
        public static string RemoveSign4VietnameseString(string str)
        {
            //remove wildcard
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public static DataTable ToDataTableNullable<T>(this List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }


            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
    }
}