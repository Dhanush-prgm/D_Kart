using D_Kart.Domain.Interfaces;
using D_Kart.Domain.Interfaces.IProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BaseController : Controller
{

    protected readonly IBaseService _baseService;

    public BaseController(IBaseService baseService)
    {
        _baseService = baseService;
    }

    protected async Task<int> GetCartCountAsync()
    {
        return await (_baseService).GetCartCountAsync();
    }
}
