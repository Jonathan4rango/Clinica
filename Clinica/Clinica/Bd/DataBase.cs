using Clinica.Model;
using Clinica.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics.Contracts;

namespace Clinica.Bd
{
    public class DataBase
    {

        readonly SQLiteAsyncConnection _database;

        public DataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RegistroModel>().Wait();
            _database.CreateTableAsync<PacienteModel>().Wait();
            _database.CreateTableAsync<DiagnosticoModel>().Wait();
            _database.CreateTableAsync<IncapacidadModel>().Wait();
        }

        #region Crud


        public Task<int> SaveModelAsync<T>(T model, bool isInsert) where T : new()
        {
            if (isInsert != true)
            {
                return _database.UpdateAsync(model);
            }
            else
            {
                return _database.InsertAsync(model);
            }

        }

        public Task<RegistroModel> GetRegistromodel(string usr, string pass)
        {
            return _database.Table<RegistroModel>().Where(x => x.Usuario == usr && x.Contrasena == pass).FirstOrDefaultAsync();
        }

        public Task<List<T>> GetModel<T>() where T : new()
        {
            return _database.Table<T>().ToListAsync();

        }

       


        #endregion

    }
}
