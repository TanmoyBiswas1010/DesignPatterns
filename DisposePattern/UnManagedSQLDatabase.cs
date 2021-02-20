using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;

namespace DisposePattern
{
    public class UnManagedSQLDatabase :DatabaseBase
    {
        private SqlCommand _command;
        private IntPtr _unmanagedResourcePointer = IntPtr.Zero;

        public override string GetDate()
        {
            var sqlDate = base.GetDate();
            if (_command == null)
            {
                _command = _sqlConnection.CreateCommand();
            }
            if (_unmanagedResourcePointer == IntPtr.Zero)
            {
                _unmanagedResourcePointer = Marshal.AllocHGlobal(100 * 1024 * 1024);
            }
            return sqlDate;
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                //Free Managed Resources
                if(_command != null)
                {
                    _command.Dispose();
                    _command = null;
                }

                Console.WriteLine("Child Managed Resources Freed");
            }

            //Free Unmanaged Resources and Suppress GC Collect
            if (_unmanagedResourcePointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_unmanagedResourcePointer);
                _unmanagedResourcePointer = IntPtr.Zero;
                Console.WriteLine("Child Un Managed Resources Freed");
            }

            base.Dispose(disposing);
        }

        //In case user dont call Dispose, GC will not suppress Finilize hence this will be called eventually.
        ~UnManagedSQLDatabase()
        {
            Console.WriteLine("Finilize called");
            Dispose(false);//false because will be called from GC
        }
    }
}
