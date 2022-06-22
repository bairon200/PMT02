using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PMT02.Models;
using System.Threading.Tasks;

namespace PMT02.Data
{
    public class SqliteHelper
    {

        SQLiteAsyncConnection db;
        public SqliteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Datos>().Wait();
        }

        public Task <int> SaveDatosAsync(Datos dato)
        {
            if (dato.id != 0)
            {
                return db.UpdateAsync(dato);
            }
            else
            {
                return db.InsertAsync(dato);    
            }
        }

        public Task<int> DeleteDatosAsync(Datos datos) { 
            return db.DeleteAsync(datos);
        }

        //para visualizar los datos
        public Task <List<Datos>> GetDatosAsync()
        {
            return db.Table<Datos>().ToListAsync();
        }
        // nos permite buscar por id

        public Task<Datos> GetDatosByIdAsync(int id)
        {
            return db.Table<Datos>().Where(a => a.id==id).FirstOrDefaultAsync();    
        }

        internal Task GetDatosListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
