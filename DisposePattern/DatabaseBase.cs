using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DisposePattern
{
    public class DatabaseBase : IDisposable
    {
        private bool _disposed = false;
        protected SqlConnection _sqlConnection;

        public virtual string GetDate()
        {
            if (_disposed)
                throw new ObjectDisposedException("DatabaseState");

            if (_sqlConnection == null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["master"];
                _sqlConnection = new SqlConnection(connectionString.ConnectionString);
                _sqlConnection.Open();
            }
            using (var command = _sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT getdate()";
                return command.ExecuteScalar().ToString();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //supress GC collect. anyway the class dont have finilizer and will not be called by GC
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return; //Since unmanaged resources is not present we can return safely

            if (disposing) //Call from users free up Managed Resources
            {
                if(_sqlConnection != null)
                {
                    _sqlConnection.Dispose();
                    _sqlConnection = null;

                    Console.WriteLine("Base Managed Resources Freed");
                }
            }

            ////Always free up unmanaged code here if using any also write Finilize method incase user forgets to call Dispose on this class

            _disposed = true;
        }
    }
}
