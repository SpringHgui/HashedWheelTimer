// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WheelTimer.Tests.Common
{
    using System;
    using System.Threading;

    public sealed class Disposable : IDisposable
    {
        Action disposeAction;

        public Disposable(Action disposeAction)
        {
            this.disposeAction = disposeAction;
        }

        public void Dispose()
        {
            Action action = Interlocked.Exchange(ref disposeAction, null);
            action?.Invoke();
        }
    }
}