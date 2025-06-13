namespace ViewForce.Reports.DataAccess
{
    using System;
    using System.Data;

    /// <summary>
    /// Data Extension class
    /// </summary>
    public static class DataExtension
    {        
        #region Public Method

        /// <summary>
        /// Get Value 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns> T</returns>
        public static T GetValue<T>(this IDataReader reader, string name)
        {
            return (T)Convert.ChangeType(reader[name], typeof(T));
        }

        #endregion
    }
}
