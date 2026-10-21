using System.Data;
using KrustyKrab.Domain.MenuItems;
using MySqlConnector;

namespace KrustyKrab.Infrastructure.MenuItems;

public sealed class MenuItemRepository(MySqlDataSource dataSource) : IMenuItemRepository
{
    public async Task<IReadOnlyList<MenuItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = await dataSource.OpenConnectionAsync(cancellationToken);
        using var command = new MySqlCommand("get_menu_items", connection)
        {
            CommandType = CommandType.StoredProcedure,
        };

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var menuItems = new List<MenuItem>();
        while (await reader.ReadAsync(cancellationToken))
            menuItems.Add(ReadMenuItem(reader));

        return menuItems;
    }

    private static MenuItem ReadMenuItem(MySqlDataReader reader) => new(
        MenuItemId: reader.GetUInt32("menu_item_id"),
        Name: reader.GetString("name"),
        Price: reader.GetDecimal("price"));
}
