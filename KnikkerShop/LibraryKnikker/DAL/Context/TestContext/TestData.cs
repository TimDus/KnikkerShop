using LibraryKnikker.Core.DAL.Data;

namespace LibraryKnikker.Core.DAL.Context.TestContext
{
    public class TestData
    {
        public TestData()
        {
            BaseTestContext.baseAccounts.Add(new BaseAccount(1, "Tim", "mail@mail.mail", "Test123!", 1) { });
        }
    }
}
