# HashedWheelTimer
[![Nuget](https://img.shields.io/nuget/v/WheelTimer)](https://www.nuget.org/packages/WheelTimer/)

High performance and light weight `HashedWheelTimer` implement by c#

fork from [DotNetty](https://github.com/Azure/DotNetty/blob/dev/src/DotNetty.Common/Utilities/HashedWheelTimer.cs)

# Install nuget package
```
dotnet add package WheelTimer
```
# Usages

```c#

// 1. Inheritance interface: `ITimerTask`
// such as:
public class ActionTimerTask : ITimerTask
{
    readonly Action<ITimeout> action;

    public ActionTimerTask(Action<ITimeout> action) => this.action = action;

    public void Run(ITimeout timeout) => this.action(timeout);
}

// 2. add ITimerTask by `NewTimeout` method
ITimer timer = new HashedWheelTimer(TimeSpan.FromMilliseconds(100), 512, -1);
ITimeout timeout = timer.NewTimeout(
    new ActionTimerTask(
        t =>
        {
           // do what you want here
        }),
    TimeSpan.FromSeconds(10));

timer.StopAsync().Wait();
``
