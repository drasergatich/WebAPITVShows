using Microsoft.EntityFrameworkCore;
using WebAPITVShows.Models.Data;

namespace WebAPITVShows.Repositories
{
    /// <summary>
    /// Implementación genérica de un repositorio para interactuar con la base de datos.
    /// Proporciona métodos CRUD para manejar entidades de tipo <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad que el repositorio manejará.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Inicializa una nueva instancia del repositorio genérico.
        /// </summary>
        /// <param name="context">El contexto de base de datos que se usará para las operaciones CRUD.</param>
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        /// <summary>
        /// Obtiene una entidad por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad.</param>
        /// <returns>La entidad con el ID especificado, o <c>null</c> si no se encuentra.</returns>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Obtiene todas las entidades de la base de datos.
        /// </summary>
        /// <returns>Una colección de todas las entidades de tipo <typeparamref name="T"/>.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        /// <summary>
        /// Agrega una nueva entidad a la base de datos.
        /// </summary>
        /// <param name="entity">La entidad a agregar.</param>
        /// <returns>Un número entero 1 si se guardaron cambios, en caso contrario un 0.</returns>
        public async Task<int> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Actualiza una entidad existente en la base de datos.
        /// </summary>
        /// <param name="entity">La entidad con los datos actualizados.</param>
        /// <returns>Un número entero 1 si se guardaron cambios, en caso contrario un 0.</returns>
        public async Task<int> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Elimina una entidad de la base de datos por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la entidad a eliminar.</param>
        /// <returns>Un número entero 1 si se guardaron cambios, en caso contrario un 0.</returns>
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
