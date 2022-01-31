using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;
using TicketGenerate.Infrastructure.EntityConfigurations;

namespace TicketGenerate.Infrastructure
{
    public class TicketContext : DbContext
    {

        private readonly IMediator _mediator;
        public const string DEFAULT_SCHEMA = "ticket";

        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }

        public TicketContext(DbContextOptions<TicketContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("TicketContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new TicketEntityTypeConfiguration().Configure(builder.Entity<Ticket>());
        }

        public DbSet<Ticket> Tickets { get; set; }
    }

    public class OrderingContextDesignFactory : IDesignTimeDbContextFactory<TicketContext>
    {
        public TicketContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TicketContext>()
                .UseSqlServer("Server=localhost;Database=SampleDb-DD;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new TicketContext(optionsBuilder.Options, new NoMediator());
        }

        class NoMediator : IMediator
        {
            public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
            {
                return Task.CompletedTask;
            }

            public Task Publish(object notification, CancellationToken cancellationToken = default)
            {
                return Task.CompletedTask;
            }

            public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.FromResult<TResponse>(default(TResponse));
            }

            public Task<object> Send(object request, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(default(object));
            }
        }
    }
}
