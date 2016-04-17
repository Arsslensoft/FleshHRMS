namespace PHRMS.ViewModels
{
    /// <summary>
    ///     The base interface for view models representing a single entity.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
    public interface ISingleObjectViewModel<TEntity, TPrimaryKey>
    {
        /// <summary>
        ///     The entity represented by a view model.
        /// </summary>
        /// <returns></returns>
        TEntity Entity { get; }

        /// <summary>
        ///     The entity primary key value.
        /// </summary>
        /// <returns></returns>
        TPrimaryKey PrimaryKey { get; }
    }
}