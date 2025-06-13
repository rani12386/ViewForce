namespace ViewForce.Reports.DataAccess
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Data Access Helper class 
    /// </summary>
    public static class DataAccessHelper
    {
        #region Private ParamList

        private static List<KeyValuePair<string, object>?> paramList = new List<KeyValuePair<string, object>?>();

        private static List<KeyValuePair<string, object>?> outputParamList = new List<KeyValuePair<string, object>?>();

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Add Input Parameters
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddInputParameters(string key, object value)
        {
            KeyValuePair<string, object>? inputParam = new KeyValuePair<string, object>(key, value);
            paramList.Add(inputParam);
            inputParam = null;

        }

        /// <summary>
        /// Add Output ParamList
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddOutputParamList(string key, object value)
        {
            KeyValuePair<string, object>? OutputParam = new KeyValuePair<string, object>(key, value);
            outputParamList.Add(OutputParam);
            OutputParam = null;
        }

        /// <summary>
        /// Execute NonQuery
        /// </summary>
        /// <param name="storeProcedureName"></param>
        /// <param name="connection"></param>
        /// <returns>int?</returns>
        public static int? ExecuteNonQuery(string storeProcedureName, IDbConnection connection)
        {
            int? result = null;
            IDataParameter parameters = null;
            //check for valid Connection
            if (connection != null)
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = storeProcedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    foreach (KeyValuePair<string, object> input in paramList)
                    {
                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = input.Key,
                            Value = input.Value
                        });
                    }
                    foreach (KeyValuePair<string, object> ouput in outputParamList)
                    {
                        parameters = new SqlParameter
                        {
                            ParameterName = ouput.Key,
                            Value = ouput.Value,
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(parameters);
                    }
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        command.Dispose();
                        connection.Close();
                        throw;
                    }
                }
                result = parameters.Value as int? ?? default(int);
            }
            paramList.Clear();
            outputParamList.Clear();
            return result;
        }

        /// <summary>
        /// Execute Reader
        /// </summary>
        /// <param name="storeProcedureName"></param>
        /// <param name="connection"></param>
        /// <returns>IDataReader</returns>
        public static IDataReader ExecuteReader(string storeProcedureName, IDbConnection connection)
        {
            IDataReader reader = null;

            if (connection != null)
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = storeProcedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    foreach (KeyValuePair<string, object> input in paramList)
                    {
                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = input.Key,
                            Value = input.Value
                        });
                    }
                    try
                    {
                        connection.Open();
                        reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                    catch (SqlException ex)
                    {
                        ex.Message.ToString();
                        connection.Close();
                        reader.Close();
                        command.Dispose();
                        throw;
                    }
                }
            }
            paramList.Clear();
            return reader;
        }

        #endregion

        #region Public Property

        /// <summary>
        /// Get Connection
        /// </summary>
        public static string GetConnection
        {
            get
            {
                return "Data Source=OUTLOOK-PC; Initial Catalog=AdventureWorksDW2012;persist security info=True; Integrated Security=SSPI;";
            }
        }

        #endregion

    }
}
