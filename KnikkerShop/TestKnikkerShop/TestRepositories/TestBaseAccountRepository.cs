using LibraryKnikker.Core.BLL.Repositories;
using LibraryKnikker.Core.DAL.Context.IContext;
using LibraryKnikker.Core.DAL.Context.TestContext;
using LibraryKnikker.Core.DAL.Data;
using Xunit;

namespace TestKnikkerShop.TestRepositories
{
    public class TestBaseAccountRepository : ClearLists
    {
        IAccountContext context = new TestAccountContext();
        AccountRepository accountRepository;

        [Fact]
        public void BaseAccountRepositoryConstructor()
        {
            EmptyLists();
            accountRepository = new AccountRepository(context);

            Assert.NotNull(accountRepository);
        }

        [Fact]
        public void Update()
        {
            EmptyLists();
            BaseAccount baseAccount = new BaseAccount(1, "klant", "mail@mail.mail", "wachtwoord", 1);
            accountRepository = new AccountRepository(context);
            Assert.True(accountRepository.Update(baseAccount));
        }

        [Fact]
        public void GetById()
        {
            EmptyLists();
            accountRepository = new AccountRepository(context);
            Assert.Equal("Tim", accountRepository.GetById(1).UserName);
        }
    }
}
