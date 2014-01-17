using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LockUtility
{
    public static class Locker
    {

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// read locked, while taking the necessary exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="whileReadLocked">The action to perform while read locked</param>
        public static void ReadLock(
            ReaderWriterLockSlim rwlock,
            Action whileReadLocked)
        {
            try
            {
                rwlock.EnterReadLock();
                whileReadLocked();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                rwlock.ExitReadLock();
            }
        }

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// write locked, while taking the necessary exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="whileWriteLocked">The action to perform while write locked</param>
        public static void WriteLock(
            ReaderWriterLockSlim rwlock,
            Action whileWriteLocked)
        {
            try
            {
                rwlock.EnterWriteLock();
                whileWriteLocked();
            }
            finally
            {
                rwlock.ExitWriteLock();
            }
        }
    }
}
