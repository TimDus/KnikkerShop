using LibraryKnikker.Core.DAL.Context.TestContext;
using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestKnikkerShop.TestRepositories
{
    public class ClearLists
    {
        public void EmptyLists()
        {
            BaseTestContext.baseAccounts = new List<BaseAccount>();

            TestData testData = new TestData();
        }
    }
}
