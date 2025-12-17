namespace Coink.Microservice.Ports
{
    public interface IQueryWrapper
    {
        /// <summary>
        /// Ejecuta un comando sin retornar datos
        /// </summary>
        Task ExecuteAsync(string resourceItemDescription, object parameters);

        /// <summary>
        /// Ejecuta una consulta que retorna múltiples resultados
        /// </summary>
        Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription, object? parameters = null);

        /// <summary>
        /// Ejecuta una consulta que retorna un solo resultado o null
        /// </summary>
        Task<T?> QueryFirstOrDefaultAsync<T>(string resourceItemDescription, object? parameters = null);

        /// <summary>
        /// Ejecuta una consulta que retorna un valor escalar (bool, int, etc.)
        /// </summary>
        Task<T> QuerySingleAsync<T>(string resourceItemDescription, object? parameters = null);
    }
}
