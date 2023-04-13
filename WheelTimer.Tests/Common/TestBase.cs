// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WheelTimer.Tests.Common
{
    using WheelTimer.Internal.Logging;
    using Xunit.Abstractions;

    public abstract class TestBase
    {
        protected readonly ITestOutputHelper Output;

        protected TestBase(ITestOutputHelper output)
        {
            Output = output;
            InternalLoggerFactory.DefaultFactory.AddProvider(new XUnitOutputLoggerProvider(output));
        }
    }
}