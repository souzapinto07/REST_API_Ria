//using Microsoft.EntityFrameworkCore;
//using Ria.Domain.Common.Data;
//using Ria.Domain.Customers.Entities;
//using Ria.Infrastructure.Mapping;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ria.Infrastructure.Data
//{
//    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
//    {
//        //private readonly IMediator? _mediator;

//        public ApplicationDbContext(DbContextOptions options/*, IMediator? mediator = null*/) : base(options)
//        {
//            //_mediator = mediator;
//        }

//        public DbSet<Customer> Customer { get; set; }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            //modelBuilder.Ignore<Event>();

//            modelBuilder.ApplyConfiguration(new CustomerMapping());
//        }

//        public async Task<bool> Commit()
//        {
//            //if (_mediator != null)
//            //{
//            //    //dispatch domain events from MediatorExtrension class to their respective event handlers
//            //    await _mediator.DispatchDomainEventsAsync(this);
//            //}

//            // Save changes to the database
//            return await base.SaveChangesAsync() > 0;
//        }
//    }
//}