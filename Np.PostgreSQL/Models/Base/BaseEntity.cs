using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Np.PostgreSQL.Models.Base.Interfaces;

namespace Np.PostgreSQL.Models.Base;

/// <summary>
/// Базовая сущность для таблиц в БД
/// </summary>
public abstract class BaseEntity : ICreatable, IUpdatable, ISoftDeletableEntity
{
    /// <summary>
    /// Ошибка о попытке несанкционированного изменения свойств
    /// </summary>
    protected const string ErrorUnauthorizedAccess = "Попытка изменения значений из несанкционированного источника";
    
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public Guid Id { get; set; }
        
    /// <summary>
    /// Дата создания сущности в БД
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; private set; }
        
    /// <summary>
    /// Дата обновления сущности в БД
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; private set; }
        
    void IUpdatable.SetDate(DateTime date)
    {
        UpdatedAt = date;
    }

    void ICreatable.SetDate(DateTime date)
    {
        CreatedAt = date;
    }

    /// <summary>
    /// Удалена ли сущность
    /// </summary>
    public bool IsDeleted { get; private set; }
        
    /// <summary>
    /// Пометить объект удаленным
    /// </summary>
    public void Delete()
    {
        IsDeleted = true;
    }
    
    /// <summary>
    /// Выбросить ошибку если была попытка несанкционированного доступа к полям
    /// </summary>
    /// <param name="validationResult">результат при котором должна упасть ошибка</param>
    protected static void ThrowIfFailedValidation(bool validationResult)
    {
        if (validationResult)
            throw new InvalidOperationException(ErrorUnauthorizedAccess);
    }
}
