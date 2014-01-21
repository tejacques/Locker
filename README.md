Locker
======

What is it?
-----------

A dependencyless Read/Write Locking Helper library for C# to aid in the writing of read/write locked code. Locker allows you to write code in a more similar fashion to the extremely intuitive built-in style `lock(obj) { /* code */ }`.

How can I get it?
-----------------

Locker is available as a NuGet package: https://nuget.org/packages/Locker

```
PM> Install-Package Locker
```

Why was it made?
----------------

It's easy to make mistakes when writing multi-threaded code. Worse, it's annoying and time consuming to do it correctly using `ReaderWriterLockSlim`. C#'s build in `lock` syntax is a beautiful intuitive way of writing locking code, but there is no equivalent syntax for `readlock` and `writelock`. That's where Locker comes in.

Example Usage
-------------

#### C#'s lock usage ####

``` csharp
lock(obj)
{
    // do something while locked
}
```

#### ReaderWriterLockSlim usage ####

``` csharp
rwlock.EnterReadLock();

try
{
    // do something while read locked
}
finally
{
    rwlock.ExitReadLock();
}
```

``` csharp
rwlock.EnterWriteLock();

try
{
    // do something while write locked
}
finally
{
    rwlock.ExitWriteLock();
}
```

``` csharp

rwlock.EnterUpgradeableReadLock();

try
{
    bool shouldUpgrade;
    // do something while upgradeably read locked
    
    if (shouldUpgrade)
    {
        rwlock.EnterWriteLock();
        
        try
        {
            // do something while write locked
        }
        finally
        {
            rwlock.ExitWriteLock();
        }
    }
}
finally
{
    rwlock.ExitUpgradeableReadLock();
}
```

#### Locker usage ####

``` csharp
Locker.ReadLock(rwlock, () =>
{
    // do something while read locked
});
```

``` csharp
Locker.WriteLock(rwlock, () =>
{
    // do something while write locked
});
```

``` csharp
Locker.UpgradeableReadLock(rwlock, () =>
{
    bool shouldUpgrade;
    // do something while upgradeably read locked
    
    if (shouldUpgrade)
    {
        // upgrad to write lock
        Locker.WriteLock(rwlock, () =>
        {
            // do something while write locked
        });
    }
});
```

Performance
-----------

`Locker` has equivalent performance as using raw `ReaderWriterLockSlim` in .NET 4.0+ due to the CLR inlining the calls. In .NET 3.5, the performance overhead of raw calls is about 20% worse. A .NET 3.5 NuGet package will be released soon.
