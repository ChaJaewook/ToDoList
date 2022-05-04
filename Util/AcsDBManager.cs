using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Util
{
    public class AcsDBManager
    {
        OleDbConnection _olc;
        private string _dbPath= "D:\\ToDoListDB.accdb";
        private string _connStr="Provider=Microsoft.ACE.OLEDB.12.0;Data Source =";
        private bool _checkDB=false;
        public AcsDBManager()
        {
            _olc = new OleDbConnection(_connStr + _dbPath);
            //_olc.Open();
        }

        public bool OpenDB()
        {
            _checkDB = false;
            try
            {
                _olc.Open();
                _checkDB = true;
            }
            catch(Exception ex)
            {
                _checkDB = false;
            }

            return _checkDB;
        }

        public bool CloseDB()
        {
            _checkDB = false;
            try
            {
                _olc.Close();
                _checkDB = true;
            }
            catch(Exception ex)
            {
                _checkDB = false;
            }

            return _checkDB;
        }

        public bool Query(string p_query)
        {
            try
            {
                if (p_query.ToLower().Contains("insert") || p_query.ToLower().Contains("delete") || p_query.ToLower().Contains("update"))
                {
                    string query = p_query;
                    OleDbCommand cmd = new OleDbCommand(query, _olc);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                    throw new Exception();
               
            }
            catch(Exception ex)
            {
                return false;
            }       
        }

        public DataSet Select(string p_query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (!p_query.Contains("select"))
                    throw new Exception();
                string query = p_query;

                OleDbDataAdapter adp = new OleDbDataAdapter(query, _olc);
                adp.Fill(ds);             

            }
            catch(Exception ex)
            {
                
            }
            return ds;
        }
    }
}
