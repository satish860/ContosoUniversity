using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContosoUniversity.IntegerationTests
{
    public class IntegerationTestBase : IAsyncLifetime
    {
        private static readonly AsyncLock Mutex = new AsyncLock();

        private static bool _initialized;

        public Task DisposeAsync()
        {
            return SliceFixture.ResetCheckpoint();
            
        }

        public virtual async  Task InitializeAsync()
        {
            if (_initialized)
                return;

            using (await Mutex.LockAsync())
            {
                if (_initialized)
                    return;

                await SliceFixture.ResetCheckpoint();

                _initialized = true;
            }
        }
    }
}
