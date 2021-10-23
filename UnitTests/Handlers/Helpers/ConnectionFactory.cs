using Microsoft.EntityFrameworkCore;
using System;
using UnitTests.Handlers.Helpers;

namespace UnitTests.Handlers
{
    public class ConnectionFactory : IDisposable
    {
        private bool disposedValue = false;
        private readonly FakeUserContextAccessor _userResolverService;
        public readonly string UserId = "031eca6d-8300-4cb0-b0c8-3d7eecf9b718";

        public ConnectionFactory()
        {
            _userResolverService = new FakeUserContextAccessor();
        }


        public FakeHouseProjectDbContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<FakeHouseProjectDbContext>()
                   .UseInMemoryDatabase("test_database")
                   .Options;

            var houseProjectDbContext = new FakeHouseProjectDbContext(option, _userResolverService);

            var context = new FakeHouseProjectDbContext(option, _userResolverService);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            return houseProjectDbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
