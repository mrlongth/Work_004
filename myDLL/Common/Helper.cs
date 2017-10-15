using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace myDLL
{
    public static class Helper
    {
    
        #region CStr

        public static string CStr(object value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    return Convert.ToString(value);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string CStr(object value, string defaultValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    return value.ToString();
                }
                else
                {
                    return defaultValue;
                }

            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion

        #region CDate

        public static DateTime? CDate(object value)
        {
            try
            {
                if (value != null)
                {
                    return DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public static DateTime? CDate(object value, DateTime defaultValue)
        {
            try
            {
                if (value != null)
                {
                    return DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
                }
                else
                {
                    return defaultValue;
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion

        #region CInt

        public static int CInt(object value)
        {
            try
            {
                return int.Parse(value.ToString());
            }
            catch
            {

                return 0;
            }
        }
        public static int CInt(object value, int defaultValue)
        {
            try
            {
                return int.Parse(value.ToString());
            }
            catch
            {

                return defaultValue;
            }
        }

        #endregion

        #region CLong

        public static long CLong(object value)
        {
            try
            {
                return long.Parse(value.ToString());
            }
            catch
            {

                return 0;
            }
        }
        public static long CLong(object value, int defaultValue)
        {
            try
            {
                return long.Parse(value.ToString());
            }
            catch
            {

                return defaultValue;
            }
        }

        #endregion


        #region CDec

        public static decimal CDec(object value)
        {
            try
            {
                return decimal.Parse(value.ToString());
            }
            catch
            {

                return 0;
            }
        }
        public static decimal CDec(object value, decimal defaultValue)
        {
            try
            {
                return decimal.Parse(value.ToString());
            }
            catch
            {

                return defaultValue;
            }
        }

        #endregion

        #region CDbl

        public static double CDbl(object value)
        {
            try
            {
                return double.Parse(value.ToString());
            }
            catch
            {

                return 0;
            }
        }
        public static double CDbl(object value, double defaultValue)
        {
            try
            {
                return double.Parse(value.ToString());
            }
            catch
            {

                return defaultValue;
            }
        }

        #endregion

        #region CBool

        public static bool CBool(object value)
        {
            try
            {
                return bool.Parse(value.ToString());
            }
            catch
            {

                return false;
            }
        }


        #endregion

        
        #region Insert a single quote

        public static string ISql(string stringData)
        {
            try
            {
                return stringData.Replace("'", "''");
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }

        }

        #endregion

        public static bool DeleteUnusedFile(string strFilePath, short sintFileAliveTime)
        {
            bool blnResult = false;

            DateTime dtNow = DateTime.Now;
            TimeSpan span = default(TimeSpan);

            DirectoryInfo dirInfo = new DirectoryInfo(strFilePath);

            if (dirInfo.Exists)
            {
                foreach (FileInfo fi in dirInfo.GetFiles())
                {
                    span = dtNow.Subtract(fi.LastWriteTime);
                    if (span.TotalMinutes > sintFileAliveTime)
                    {
                        try
                        {
                            fi.IsReadOnly = false;
                            fi.Delete();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
                blnResult = true;
            }
            return blnResult;
        }

        public static string ReplaceScript(string strText)
        {
            strText = strText.Replace("\n", "\\n");
            strText = strText.Replace("\r", "\\r");
            strText = strText.Replace("'", "\\'");
            return strText;
        }

        public static bool IsValidDatatable(DataTable dataTable, bool ignoreZeroRows = false)
        {
            if (dataTable == null)
                return false;
            if (dataTable.Columns.Count == 0)
                return false;
            if (ignoreZeroRows)
                return true;

            return dataTable.Rows.Count != 0;
        }


        public static IList<T> ToClassInstanceCollection<T>(DataTable dataTable) where T : class, new()
        {
            if (!IsValidDatatable(dataTable))
                return new List<T>();

            var classType = typeof(T);
            IList<PropertyInfo> propertyList = classType.GetProperties();

            // Parameter class has no public properties.
            if (propertyList.Count == 0)
                return new List<T>();

            var columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();
            var result = new List<T>();

            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var classObject = new T();

                    foreach (var property in propertyList)
                    {
                        if (!IsValidObjectData(property, columnNames, row))
                            continue;

                        var propertyValue = ChangeType(
                                row[property.Name],
                                property.PropertyType
                            );

                        property.SetValue(classObject, propertyValue, null);
                    }

                    result.Add(classObject);
                }
                return result;
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        public static bool IsValidObjectData(PropertyInfo property, List<string> columnNames, DataRow row)
        {
            return property != null && property.CanWrite && columnNames.Contains(property.Name) && row[property.Name] != DBNull.Value;
        }


        public static object ChangeType(object value, Type conversion)
        {
            var type = conversion;

            if (!type.IsGenericType || !(type.GetGenericTypeDefinition() == typeof(Nullable<>)))
                return Convert.ChangeType(value, type);

            if (value == null)
            {
                return null;
            }

            type = Nullable.GetUnderlyingType(type);
            return Convert.ChangeType(value, type);
        }


        public static void CopyTo(this object Source, object Target)
        {
            try
            {
                foreach (var pS in Source.GetType().GetProperties())
                {
                    foreach (var pT in Target.GetType().GetProperties())
                    {
                        if (pT.Name != pS.Name) continue;
                        (pT.GetSetMethod()).Invoke(Target, new object[] { pS.GetGetMethod().Invoke(Source, null) });
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T Clone<T>(T source)
        {
            try
            {
                if (!typeof(T).IsSerializable)
                {
                    throw new ArgumentException("The type must be serializable.", "source");
                }

                // Don't serialize a null object, simply return the default for that object
                if (Object.ReferenceEquals(source, null))
                {
                    return default(T);
                }

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new MemoryStream();
                using (stream)
                {
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
