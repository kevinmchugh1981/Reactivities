using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;

namespace Application.Activites
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Activities.Add(request.Activity);
                await context.SaveChangesAsync();
                return Unit.Value;
            }

        }
    }
}