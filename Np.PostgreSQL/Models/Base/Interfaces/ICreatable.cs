namespace Np.PostgreSQL.Models.Base.Interfaces;

/// <summary>
/// Управление датой создания объекта
/// </summary>
public interface ICreatable
{
    /// <summary>
    /// Дата создания
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// Установка даты
    /// </summary>
    void SetDate(DateTime date);
}
