namespace UnitTests.Handlers.Helpers
{
    public class FakeUserContextAccessor
    {
        private readonly string username = "tomek";

        public string GetUser()
        {
            return username;
        }
    }
}
