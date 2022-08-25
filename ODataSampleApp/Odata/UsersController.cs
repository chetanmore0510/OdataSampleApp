using Application.Users;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Api.OData
{
    public class UsersController : ODataControllerBase
    {
        [EnableQuery]
        [HttpGet]
        public async Task<IQueryable<Users>> Get() =>
            await Mediator.Send(new GetUsersQueryable());

    }
}
