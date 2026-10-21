using KrustyKrab.Domain.MenuItems;
using Microsoft.AspNetCore.Mvc;

namespace KrustyKrab.Api.Controllers;

[ApiController]
[Route("api/menu-items")]
public sealed class MenuItemsController(IMenuItemRepository menuItems) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<MenuItem>>(StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<MenuItem>> GetAll(CancellationToken cancellationToken)
        => await menuItems.GetAllAsync(cancellationToken);
}
