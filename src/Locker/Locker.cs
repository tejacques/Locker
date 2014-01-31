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
        /// <param name="rwlock">
        /// The ReaderWriterLockSlim
        /// </param>
        /// <param name="whileReadLocked">
        /// The action to perform while read locked
        /// </param>
        public static void ReadLock(
            ReaderWriterLockSlim rwlock,
            Action whileReadLocked)
        {
            rwlock.EnterReadLock();

            try
            {
                whileReadLocked();
            }
            finally
            {
                rwlock.ExitReadLock();
            }
        }

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// read locked, while taking the necessary exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="timeout">The number of miliseconds to wait</param>
        /// <param name="whileReadLocked">
        /// The action to perform while read locked
        /// </param>
        /// <returns>
        /// true if the lock was acquired successfully false otherwise
        /// </returns>
        public static bool TryReadLock(
            ReaderWriterLockSlim rwlock,
            int timeout,
            Action whileReadLocked)
        {
            if (rwlock.TryEnterReadLock(timeout))
            {
                try
                {
                    whileReadLocked();
                }
                finally
                {
                    rwlock.ExitReadLock();
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// read locked, while taking the necessary exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="timeout">The number of miliseconds to wait</param>
        /// <param name="whileReadLocked">
        /// The action to perform while read locked
        /// </param>
        /// <returns>
        /// true if the lock was acquired successfully false otherwise
        /// </returns>
        public static bool TryReadLock(
            ReaderWriterLockSlim rwlock,
            TimeSpan timeout,
            Action whileReadLocked)
        {
            if (rwlock.TryEnterReadLock(timeout))
            {
                try
                {
                    whileReadLocked();
                }
                finally
                {
                    rwlock.ExitReadLock();
                }

                return true;
            }

            return false;
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
            rwlock.EnterWriteLock();

            try
            {
                whileWriteLocked();
            }
            finally
            {
                rwlock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// write locked, while taking the necessary exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="timeout">The number of miliseconds to wait</param>
        /// <param name="whileWriteLocked">
        /// The action to perform while write locked
        /// </param>
        /// <returns>
        /// true if the lock was acquired successfully false otherwise
        /// </returns>
        public static bool TryWriteLock(
            ReaderWriterLockSlim rwlock,
            int timeout,
            Action whileWriteLocked)
        {
            if (rwlock.TryEnterWriteLock(timeout))
            {
                try
                {
                    whileWriteLocked();
                }
                finally
                {
                    rwlock.ExitWriteLock();
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// write locked, while taking the necessary exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="timeout">The number of miliseconds to wait</param>
        /// <param name="whileWriteLocked">
        /// The action to perform while write locked
        /// </param>
        /// <returns>
        /// true if the lock was acquired successfully false otherwise
        /// </returns>
        public static bool TryWriteLock(
            ReaderWriterLockSlim rwlock,
            TimeSpan timeout,
            Action whileWriteLocked)
        {
            if (rwlock.TryEnterWriteLock(timeout))
            {
                try
                {
                    whileWriteLocked();
                }
                finally
                {
                    rwlock.ExitWriteLock();
                }

                return true;
            }

            return false;
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
            rwlock.EnterUpgradeableReadLock();

            try
            {
                whileUpgradeableReadLocked();
            }
            finally
            {
                rwlock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// upgradeably read locked, while taking the necessary
        /// exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="timeout">The number of miliseconds to wait</param>
        /// <param name="whileUpgradeableReadLocked">
        /// The action to perform while upgradeably read locked
        /// </param>
        /// <returns>
        /// true if the lock was acquired successfully false otherwise
        /// </returns>
        public static bool TryUpgradeableReadLock(
            ReaderWriterLockSlim rwlock,
            int timeout,
            Action whileUpgradeableReadLocked)
        {
            if (rwlock.TryEnterUpgradeableReadLock(timeout))
            {
                try
                {
                    whileUpgradeableReadLocked();
                }
                finally
                {
                    rwlock.ExitUpgradeableReadLock();
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Performs an action while the provided ReaderWriterLockSlim is
        /// upgradeably read locked, while taking the necessary
        /// exception precautions.
        /// </summary>
        /// <param name="rwlock">The ReaderWriterLockSlim</param>
        /// <param name="timeout">The number of miliseconds to wait</param>
        /// <param name="whileUpgradeableReadLocked">
        /// The action to perform while upgradeably read locked
        /// </param>
        /// <returns>
        /// true if the lock was acquired successfully false otherwise
        /// </returns>
        public static bool TryUpgradeableReadLock(
            ReaderWriterLockSlim rwlock,
            TimeSpan timeout,
            Action whileUpgradeableReadLocked)
        {
            if (rwlock.TryEnterUpgradeableReadLock(timeout))
            {
                try
                {
                    whileUpgradeableReadLocked();
                }
                finally
                {
                    rwlock.ExitUpgradeableReadLock();
                }

                return true;
            }

            return false;
        }
    }
}
