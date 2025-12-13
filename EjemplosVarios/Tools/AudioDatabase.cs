
using SQLite;

namespace EjemplosVarios.Tools
{
    public class AudioDatabase
    {
        private readonly SQLiteAsyncConnection _db;
        public AudioDatabase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Models.GrabacionAudio>().Wait();
        }
        public Task<List<Models.GrabacionAudio>> GetGrabacionesAsync()
        {
            return _db.Table<Models.GrabacionAudio>().OrderByDescending(g => g.FechaGrabacion).ToListAsync();
        }
        public Task<Models.GrabacionAudio> GetGrabacionAsync(int id)
            => _db.Table<Models.GrabacionAudio>().Where(g => g.Id == id).FirstOrDefaultAsync();
        public Task<int> GuardarGrabacionAsync(Models.GrabacionAudio grabacion) =>
            _db.InsertAsync(grabacion);
        public Task<int> ModificarGrabacionAsync(Models.GrabacionAudio grabacion) =>
            _db.UpdateAsync(grabacion);
        public Task<int> BorrarGrabacionAsync(Models.GrabacionAudio grabacion) =>
            _db.DeleteAsync(grabacion);
    }
}
