using LibraryKnikker.Core.DAL.Context.IContext;
using LibraryKnikker.Core.DAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace LibraryKnikker.Core.DAL.Context.TestContext
{
    public class TestAccountContext : IAccountContext
    {
        public bool Activation(long id, bool active)
        {
            throw new System.NotImplementedException();
        }

        public List<BaseAccount> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public BaseAccount GetById(long id)
        {
            return BaseTestContext.baseAccounts.FirstOrDefault(b => b.Id == id);
        }

        public long Insert(BaseAccount obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BaseAccount baseAccount)
        {
            int index = BaseTestContext.baseAccounts.FindIndex(p => p.Id == baseAccount.Id);
            if (index >= 0)
            {
                BaseTestContext.baseAccounts[index].UserName = baseAccount.UserName;
                BaseTestContext.baseAccounts[index].Email = baseAccount.Email;
                return true;
            }
            return false;
        }
    }
}
