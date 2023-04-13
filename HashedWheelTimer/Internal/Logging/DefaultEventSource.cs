// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WheelTimer.Internal.Logging
{
    using System;
    using System.Diagnostics.Tracing;

    [EventSource(
        Name = "DotNetty-Default",
        Guid = "d079e771-0495-4124-bd2f-ab63c2b50525")]
    public sealed class DefaultEventSource : EventSource
    {
        const int TraceEventId = 1;
        const int DebugEventId = 2;
        const int InfoEventId = 3;
        const int WarningEventId = 4;
        const int ErrorEventId = 5;

        public class Keywords
        {
            public const EventKeywords TraceEventKeyword = (EventKeywords)1;
            public const EventKeywords DebugEventKeyword = (EventKeywords)(1 << 1);
        }

        public static readonly DefaultEventSource Log = new DefaultEventSource();

        DefaultEventSource()
        {
        }

        public bool IsTraceEnabled => IsEnabled(EventLevel.Verbose, Keywords.TraceEventKeyword);

        public bool IsDebugEnabled => IsEnabled(EventLevel.Verbose, Keywords.DebugEventKeyword);

        public bool IsInfoEnabled => IsEnabled(EventLevel.Informational, EventKeywords.None);

        public bool IsWarningEnabled => IsEnabled(EventLevel.Warning, EventKeywords.None);

        public bool IsErrorEnabled => IsEnabled(EventLevel.Error, EventKeywords.None);

        [NonEvent]
        public void Trace(string source, string message) => Trace(source, message, string.Empty);

        [NonEvent]
        public void Trace(string source, string message, Exception exception)
        {
            if (IsTraceEnabled)
            {
                Trace(source, message, exception?.ToString() ?? string.Empty);
            }
        }

        [Event(TraceEventId, Level = EventLevel.Verbose, Keywords = Keywords.TraceEventKeyword)]
        public void Trace(string source, string message, string info)
        {
            if (IsTraceEnabled)
            {
                WriteEvent(TraceEventId, source, message, info);
            }
        }

        [NonEvent]
        public void Debug(string source, string message) => Debug(source, message, string.Empty);

        [NonEvent]
        public void Debug(string source, string message, Exception exception)
        {
            if (IsDebugEnabled)
            {
                Debug(source, message, exception?.ToString() ?? string.Empty);
            }
        }

        [Event(DebugEventId, Level = EventLevel.Verbose, Keywords = Keywords.DebugEventKeyword)]
        public void Debug(string source, string message, string info)
        {
            if (IsDebugEnabled)
            {
                WriteEvent(DebugEventId, source, message, info);
            }
        }

        [NonEvent]
        public void Info(string source, string message) => Info(source, message, string.Empty);

        [NonEvent]
        public void Info(string source, string message, Exception exception)
        {
            if (IsInfoEnabled)
            {
                Info(source, message, exception?.ToString() ?? string.Empty);
            }
        }

        [Event(InfoEventId, Level = EventLevel.Informational)]
        public void Info(string source, string message, string info)
        {
            if (IsInfoEnabled)
            {
                WriteEvent(InfoEventId, source, message, info);
            }
        }

        [NonEvent]
        public void Warning(string source, string message) => Warning(source, message, string.Empty);

        [NonEvent]
        public void Warning(string source, string message, Exception exception)
        {
            if (IsWarningEnabled)
            {
                Warning(source, message, exception?.ToString() ?? string.Empty);
            }
        }

        [Event(WarningEventId, Level = EventLevel.Warning)]
        public void Warning(string source, string message, string exception)
        {
            if (IsWarningEnabled)
            {
                WriteEvent(WarningEventId, source, message, exception);
            }
        }

        [NonEvent]
        public void Error(string source, string message) => Error(source, message, string.Empty);

        [NonEvent]
        public void Error(string source, string message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                Error(source, message, exception?.ToString() ?? string.Empty);
            }
        }

        [Event(ErrorEventId, Level = EventLevel.Error)]
        public void Error(string source, string message, string exception)
        {
            if (IsErrorEnabled)
            {
                WriteEvent(ErrorEventId, source, message, exception);
            }
        }
    }
}