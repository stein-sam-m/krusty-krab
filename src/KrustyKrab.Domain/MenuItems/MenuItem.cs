namespace KrustyKrab.Domain.MenuItems;

public sealed record MenuItem(
    uint MenuItemId,
    string Name,
    decimal Price);
