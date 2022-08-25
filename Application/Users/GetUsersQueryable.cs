using Domain.Data;
using MediatR;


namespace Application.Users
{
    public class GetUsersQueryable : IRequest<IQueryable<Domain.Models.Users>>
    {
        public class Handler : IRequestHandler<GetUsersQueryable, IQueryable<Domain.Models.Users>>
        {
            private readonly SamplesContext _context;

            public Handler(SamplesContext context)
            {
                _context = context;
            }

            public Task<IQueryable<Domain.Models.Users>> Handle(GetUsersQueryable query, CancellationToken cancellationToken)
            {
                return Task.FromResult((IQueryable<Domain.Models.Users>)_context.Users);
            }
        }
    }
}

