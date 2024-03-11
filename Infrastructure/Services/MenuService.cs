using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
namespace Infrastructure.Services;


public class MenuService
{

    private readonly DapperContext context;

    public MenuService()
    {
        context = new DapperContext();
    }

    public async Task AddMenu(Menu menu)
    {
        var sql = "insert into Menu (MenuName,Status_Menu,Price) values(@MenuName,@Status_Menu,@Price)";

        await context.Connection().ExecuteAsync(sql, menu);

    }

    public async Task DeleteMenu(int menuId)
    {
        var sql = "delete from Menu where MenuId=@menuId";

        await context.Connection().ExecuteAsync(sql, new { MenuId = menuId });
    }

    public async Task UpdateMenu(Menu menu)
    {
        var sql = "update Menu set MenuName=@MenuName,Status_Menu=@Status_Menu,Price=@Price where MenuId=@menuId ";

        await context.Connection().ExecuteAsync(sql, menu);
    }

    public async Task<List<Menu>> GetMenus()
    {
        var sql = "select * from Menu";

        var list = await context.Connection().QueryAsync<Menu>(sql);

        return list.ToList();
    }




















}
