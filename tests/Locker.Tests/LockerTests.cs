using LockUtility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockerTests
{
    [TestFixture]
    public class Tests
    {
        private object lobj;
        private ReaderWriterLockSlim rwlock;
        private int _loops = 10000;
        private int _loopsInner = 50000;
        [TestFixtureSetUp]
        public void SetUp()
        {
            rwlock = new ReaderWriterLockSlim();
            lobj = new object();

            TestLockHelper(1, 1);
            TestReadWriteLockHelper(1, 1);
            TestLockerHelper(1, 1);
        }

        [Test]
        public void A_Jit() { }

        [Test]
        public void TestLock()
        {
            Parallel.For(0, 8, (i) => TestLockHelper(_loops, _loopsInner));
        }

        public int TestLockHelper(int loops, int loopsInner)
        {
            int a = 0;
            for(int i = 0; i < loops; i++)
            {
                lock(lobj)
                {
                    for (int j = 0; j < loopsInner; j++)
                    {
                        a++;
                    }
                }
            }

            return a;
        }

        [Test]
        public void TestReadWriteLock()
        {
            Parallel.For(0, 8, (i) => TestReadWriteLockHelper(_loops, _loopsInner));
        }

        public int TestReadWriteLockHelper(int loops, int loopsInner)
        {
            int a = 0;
            for (int i = 0; i < loops; i++)
            {
                try
                {
                    rwlock.EnterReadLock();
                    for (int j = 0; j < loopsInner; j++)
                    {
                        a++;
                    }
                }
                finally
                {
                    rwlock.ExitReadLock();
                }
            }

            return a;
        }

        [Test]
        public void TestLocker()
        {
            Parallel.For(0, 8, (i) => TestLockerHelper(_loops, _loopsInner));
        }

        public int TestLockerHelper(int loops, int loopsInner)
        {
            int a = 0;
            for (int i = 0; i < loops; i++)
            {
                Locker.ReadLock(rwlock, () =>
                {
                    for (int j = 0; j < loopsInner; j++)
                    {
                        a++;
                    }
                });
            }

            return a;
        }
    }
}
