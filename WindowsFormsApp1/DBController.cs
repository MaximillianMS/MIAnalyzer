using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace MIAnalyzer
{
    enum DBType { SQLite}
    struct DBConnectionParams
    {
        public string PathToDBFile;
        public string Username;
        public string Password;
        public DBType DBType;
        
    }
    struct Answer
    {
        public List<string> Header;
        public List<List<string>> Body;
        public bool Result;
    }
    class SQLiteConnector : DBConnector
    {
        SQLiteConnection Connection=null;
        public ConnectionState Connect(DBConnectionParams ConnectionParams)
        {
            if(Connection!=null)
            {
                Connection.Close();
            }
            Connection = new SQLiteConnection();
            try
            {
                Connection.ConnectionString = "Data Source=\"" + ConnectionParams.PathToDBFile + "\"";
                Connection.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, e.Source);
            }
            return GetConnectionState();
        }

        public ConnectionState GetConnectionState()
        {
            return Connection.State;
        }
        List<string> ReadRow(SQLiteDataReader reader)
        {
            var res = new List<string>(reader.FieldCount);
            for(int i=0;i<reader.FieldCount;i++)
            {
                res.Add(reader.GetValue(i).ToString());
            }
            return res;
        }
        List<string> ReadAnswerHeader(SQLiteDataReader reader)
        {
            var res = new List<string>();

            for(int i=0;i<reader.FieldCount;i++)
            {
                res.Add(reader.GetName(i));
            }
            return res;
        }
        List<List<string>> ReadAnswerBody(SQLiteDataReader reader)
        {

            var res = new List<List<string>>();

            while (reader.Read())
            {
                res.Add(ReadRow(reader));
            }
            return res;
        }
        public Answer MakeQuery(string Query)
        {
            var res = new Answer();
            try
            {
                var cmd = Connection.CreateCommand();
                cmd.CommandText = Query;
                var reader = cmd.ExecuteReader();
                res.Header = ReadAnswerHeader(reader);
                res.Body = ReadAnswerBody(reader);
                res.Result = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, e.Source);
                res.Result = false;
            }
            return res;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Connection.Close();
                    Connection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SQLiteConnector() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    interface DBConnector:IDisposable
    {
        ConnectionState GetConnectionState();
        ConnectionState Connect(DBConnectionParams ConnectionParams);
        Answer MakeQuery(string Query);
    }

    class DBController
    {
        DBConnector db;
        Answer MakeQuery(string Query)
        {
            return db.MakeQuery(Query);
        }
        public ConnectionState ConnectToDB(DBConnectionParams ConnectionParams)
        {
            if (Program._USEHARDCODE)
                return ConnectionState.Connecting;
            switch (ConnectionParams.DBType)
            {
                case DBType.SQLite:
                    {
                        db = new SQLiteConnector();
                        return db.Connect(ConnectionParams);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                        break;
                    }
            }
        }
        public List<DirectoryInfo> GetScannedFolders()
        {
            if (!Program._USEHARDCODE)
                throw new NotImplementedException();
            else
                return new List<DirectoryInfo>();
        }
        public void ClearScannedFoldersInfo()
        {
            throw new NotImplementedException();
        }
        public void ClearAll()
        {
            throw new NotImplementedException();
        }
        public void MarkFolderAsScanned(DirectoryInfo Folder)
        {
            throw new NotImplementedException();
        }
        public void SaveTrial(Trial trial)
        {
            throw new NotImplementedException();
        }

        public void SaveTrialSequence(TrialSequence trialSequence)
        {
            throw new NotImplementedException();
        }
    }
}
