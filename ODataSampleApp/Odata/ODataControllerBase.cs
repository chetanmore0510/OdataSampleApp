﻿using MediatR;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;


namespace Api.OData
{
    [ODataRouteComponent("odata")]

    public class ODataControllerBase : ODataController
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}