using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LockUtility
{
    /// <summary>
    /// A utility class for interacting with ReaderWriterLockSlim.
    /// </summary>
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
        /// <param name="whileWriteLocked">
        /// The action to perform while write locked
        /// </param>
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

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// upgradeably read locked, while taking the necessary
        /// exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="whileUpgradeableReadLocked">
        /// The action to perform while upgradeably read locked
        /// </param>
        public static void UpgradeableReadLock(
            ReaderWriterLockSlim rwlock,
            Action whileUpgradeableReadLocked)
        {
            try
            {
                rwlock.EnterUpgradeableReadLock();
                whileUpgradeableReadLocked();
            }
            finally
            {
                rwlock.ExitUpgradeableReadLock();
            }
        }
    }
}
