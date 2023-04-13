// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WheelTimer.Internal.Logging
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// A skeletal implementation of <see cref="IInternalLogger"/>. This class implements
    /// all methods that have a <see cref="InternalLogLevel"/> parameter by default to call
    /// specific logger methods such as <see cref="Info(string)"/> or <see cref="InfoEnabled"/>.
    /// </summary>
    public abstract class AbstractInternalLogger : IInternalLogger
    {
        static readonly string EXCEPTION_MESSAGE = "Unexpected exception:";

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="name">A friendly name for the new logger instance.</param>
        protected AbstractInternalLogger(string name)
        {
            Contract.Requires(name != null);

            Name = name;
        }

        public string Name { get; }

        public bool IsEnabled(InternalLogLevel level)
        {
            switch (level)
            {
                case InternalLogLevel.TRACE:
                    return TraceEnabled;
                case InternalLogLevel.DEBUG:
                    return DebugEnabled;
                case InternalLogLevel.INFO:
                    return InfoEnabled;
                case InternalLogLevel.WARN:
                    return WarnEnabled;
                case InternalLogLevel.ERROR:
                    return ErrorEnabled;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public abstract bool TraceEnabled { get; }

        public abstract void Trace(string msg);

        public abstract void Trace(string format, object arg);

        public abstract void Trace(string format, object argA, object argB);

        public abstract void Trace(string format, params object[] arguments);

        public abstract void Trace(string msg, Exception t);

        public void Trace(Exception t) => Trace(EXCEPTION_MESSAGE, t);

        public abstract bool DebugEnabled { get; }

        public abstract void Debug(string msg);

        public abstract void Debug(string format, object arg);

        public abstract void Debug(string format, object argA, object argB);

        public abstract void Debug(string format, params object[] arguments);

        public abstract void Debug(string msg, Exception t);

        public void Debug(Exception t) => Debug(EXCEPTION_MESSAGE, t);

        public abstract bool InfoEnabled { get; }

        public abstract void Info(string msg);

        public abstract void Info(string format, object arg);

        public abstract void Info(string format, object argA, object argB);

        public abstract void Info(string format, params object[] arguments);

        public abstract void Info(string msg, Exception t);

        public void Info(Exception t) => Info(EXCEPTION_MESSAGE, t);

        public abstract bool WarnEnabled { get; }

        public abstract void Warn(string msg);

        public abstract void Warn(string format, object arg);

        public abstract void Warn(string format, params object[] arguments);

        public abstract void Warn(string format, object argA, object argB);

        public abstract void Warn(string msg, Exception t);

        public void Warn(Exception t) => Warn(EXCEPTION_MESSAGE, t);

        public abstract bool ErrorEnabled { get; }

        public abstract void Error(string msg);

        public abstract void Error(string format, object arg);

        public abstract void Error(string format, object argA, object argB);

        public abstract void Error(string format, params object[] arguments);

        public abstract void Error(string msg, Exception t);

        public void Error(Exception t) => Error(EXCEPTION_MESSAGE, t);

        public void Log(InternalLogLevel level, string msg, Exception cause)
        {
            switch (level)
            {
                case InternalLogLevel.TRACE:
                    Trace(msg, cause);
                    break;
                case InternalLogLevel.DEBUG:
                    Debug(msg, cause);
                    break;
                case InternalLogLevel.INFO:
                    Info(msg, cause);
                    break;
                case InternalLogLevel.WARN:
                    Warn(msg, cause);
                    break;
                case InternalLogLevel.ERROR:
                    Error(msg, cause);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Log(InternalLogLevel level, Exception cause)
        {
            switch (level)
            {
                case InternalLogLevel.TRACE:
                    Trace(cause);
                    break;
                case InternalLogLevel.DEBUG:
                    Debug(cause);
                    break;
                case InternalLogLevel.INFO:
                    Info(cause);
                    break;
                case InternalLogLevel.WARN:
                    Warn(cause);
                    break;
                case InternalLogLevel.ERROR:
                    Error(cause);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Log(InternalLogLevel level, string msg)
        {
            switch (level)
            {
                case InternalLogLevel.TRACE:
                    Trace(msg);
                    break;
                case InternalLogLevel.DEBUG:
                    Debug(msg);
                    break;
                case InternalLogLevel.INFO:
                    Info(msg);
                    break;
                case InternalLogLevel.WARN:
                    Warn(msg);
                    break;
                case InternalLogLevel.ERROR:
                    Error(msg);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Log(InternalLogLevel level, string format, object arg)
        {
            switch (level)
            {
                case InternalLogLevel.TRACE:
                    Trace(format, arg);
                    break;
                case InternalLogLevel.DEBUG:
                    Debug(format, arg);
                    break;
                case InternalLogLevel.INFO:
                    Info(format, arg);
                    break;
                case InternalLogLevel.WARN:
                    Warn(format, arg);
                    break;
                case InternalLogLevel.ERROR:
                    Error(format, arg);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Log(InternalLogLevel level, string format, object argA, object argB)
        {
            switch (level)
            {
                case InternalLogLevel.TRACE:
                    Trace(format, argA, argB);
                    break;
                case InternalLogLevel.DEBUG:
                    Debug(format, argA, argB);
                    break;
                case InternalLogLevel.INFO:
                    Info(format, argA, argB);
                    break;
                case InternalLogLevel.WARN:
                    Warn(format, argA, argB);
                    break;
                case InternalLogLevel.ERROR:
                    Error(format, argA, argB);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Log(InternalLogLevel level, string format, params object[] arguments)
        {
            switch (level)
            {
                case InternalLogLevel.TRACE:
                    Trace(format, arguments);
                    break;
                case InternalLogLevel.DEBUG:
                    Debug(format, arguments);
                    break;
                case InternalLogLevel.INFO:
                    Info(format, arguments);
                    break;
                case InternalLogLevel.WARN:
                    Warn(format, arguments);
                    break;
                case InternalLogLevel.ERROR:
                    Error(format, arguments);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString() => GetType().Name + '(' + Name + ')';
    }
}