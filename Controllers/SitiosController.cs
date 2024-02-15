using PM2E17321.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2E17321.Controllers
{
    

    public class SitiosController
    {
        readonly SQLiteAsyncConnection _connection;

        public SitiosController()
        {
            SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite |
                                                SQLite.SQLiteOpenFlags.Create |
                                                SQLite.SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBSitios.db3"), extensiones);

            _connection.CreateTableAsync<Sitios>();
        }

        public async Task<int> StoreSitios(Sitios sitios)
        {

            if (sitios.Id == 0)
            {
                return await _connection.InsertAsync(sitios);
            }
            else
            {
                return await _connection.UpdateAsync(sitios);
            }
        }

        // Read
        public async Task<List<Models.Sitios>> GetListSitios()
        {

            return await _connection.Table<Sitios>().ToListAsync();
        }

        // Read Element
        public async Task<Models.Sitios> GetSitio(int pid)
        {

            return await _connection.Table<Sitios>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        // Delete Element
        public async Task<int> DeleteSitios(Sitios sitios)
        {

            return await _connection.DeleteAsync(sitios);
        }

    }
}
