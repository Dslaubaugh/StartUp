using System.Data.Common;
using System.Runtime.InteropServices.JavaScript;
using Dapper;
using StartUp.Web.models;

namespace StartUp.Web.database;

public interface IStartUpDBContext
{
    Task<Guid> InsertIntoTable(InsertValues values);
}

public class StartUpDBContext : IStartUpDBContext
{
    private DbConnection _db;

    public StartUpDBContext(IDBConnectionFactory factory)
    {
        _db = factory.GetDbConnection();
    }

    public async Task<Guid> InsertIntoTable(InsertValues values)
    {
        var query =
            @"insert into  demo_schema.demo_data( date, ui_value, button_click, language, favorite_number) values(@date, @ui_value, @button_click, @language, @favorite_number)
                        returning demo_data.id";
        return (Guid)await _db.ExecuteScalarAsync(query, new
        {
            date = values.Date,
            ui_value = values.UIValue,
            button_click = values.ButtonClick,
            language = values.Language,
            favorite_number = values.FavoriteNumber
        });
    }
}