# Np.PostgreSQL

Сервис представляет собой базовые классы для работы с PostgresSQl

## Установка

### 1

Для использования всех функций необходимо унаследовать ваш `DataDbContext` от `DefaultDbContext`

Всю необходимую конфигурацию можно реализовать переопределив метод `ConfigureEntityAndApplyConfiguration`

``` C#
    /// <summary>
    /// Используется для дополнительной конфигурации сущностей
    /// </summary>
    protected virtual void ConfigureEntityAndApplyConfiguration(ModelBuilder modelBuilder)
```

Так же есть вохмоность перееопредлить `SetQueryFilter`, для уставновки своих фильтров

``` C#
    /// <summary>
    /// Устанавливаем фильтр на запросы к бд, в данном случае не будут подбираться данные с флагом IsDeleted.<br/>
    /// Есть возможность переопределения метод
    /// </summary>
    protected virtual void SetQueryFilter(ModelBuilder modelBuilder)
```

Так же необходимо зарегестрировать настройку сервиса `DbSettings` в `ConfigureSettings`

``` C#
    services.ConfigureSettings<DbSettings>(config, nameof(DbSettings));
```

Перед использование обязательно необходимо в `env` приложения добавить настройки

``` json
    "DBSETTINGS__HOST": "127.0.0.1",
    "DBSETTINGS__PORT": "5430",
    "DBSETTINGS__USER": "developer",
    "DBSETTINGS__PASSWORD": "developer",
    "DBSETTINGS__DBNAME": "db-name",
```

### 2

При создании репозиториев можно использовать интерфейс `IBaseRepository` и реализующий его класс `BaseRepository`, данный класс помогает реализовывать базовую логику `DbContext`