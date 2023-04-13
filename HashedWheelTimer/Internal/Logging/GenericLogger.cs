// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WheelTimer.Internal.Logging
{
    using System;
    using Microsoft.Extensions.Logging;

    sealed class GenericLogger : AbstractInternalLogger
    {
        static readonly Func<string, Exception, string> MessageFormatterFunc = (s, e) => s;
        readonly ILogger logger;

        public GenericLogger(string name, ILogger logger)
            : base(name)
        {
            this.logger = logger;
        }

        public override bool TraceEnabled => logger.IsEnabled(LogLevel.Trace);

        public override void Trace(string msg) => logger.Log(LogLevel.Trace, 0, msg, null, MessageFormatterFunc);

        public override void Trace(string format, object arg)
        {
            if (TraceEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                logger.Log(LogLevel.Trace, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Trace(string format, object argA, object argB)
        {
            if (TraceEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                logger.Log(LogLevel.Trace, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Trace(string format, params object[] arguments)
        {
            if (TraceEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                logger.Log(LogLevel.Trace, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Trace(string msg, Exception t) => logger.Log(LogLevel.Trace, 0, msg, t, MessageFormatterFunc);

        public override bool DebugEnabled => logger.IsEnabled(LogLevel.Debug);

        public override void Debug(string msg) => logger.Log(LogLevel.Debug, 0, msg, null, MessageFormatterFunc);

        public override void Debug(string format, object arg)
        {
            if (DebugEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                logger.Log(LogLevel.Debug, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Debug(string format, object argA, object argB)
        {
            if (DebugEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                logger.Log(LogLevel.Debug, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Debug(string format, params object[] arguments)
        {
            if (DebugEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                logger.Log(LogLevel.Debug, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Debug(string msg, Exception t) => logger.Log(LogLevel.Debug, 0, msg, t, MessageFormatterFunc);

        public override bool InfoEnabled => logger.IsEnabled(LogLevel.Information);

        public override void Info(string msg) => logger.Log(LogLevel.Information, 0, msg, null, MessageFormatterFunc);

        public override void Info(string format, object arg)
        {
            if (InfoEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                logger.Log(LogLevel.Information, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Info(string format, object argA, object argB)
        {
            if (InfoEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                logger.Log(LogLevel.Information, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Info(string format, params object[] arguments)
        {
            if (InfoEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                logger.Log(LogLevel.Information, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Info(string msg, Exception t) => logger.Log(LogLevel.Information, 0, msg, t, MessageFormatterFunc);

        public override bool WarnEnabled => logger.IsEnabled(LogLevel.Warning);

        public override void Warn(string msg) => logger.Log(LogLevel.Warning, 0, msg, null, MessageFormatterFunc);

        public override void Warn(string format, object arg)
        {
            if (WarnEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                logger.Log(LogLevel.Warning, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Warn(string format, object argA, object argB)
        {
            if (WarnEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                logger.Log(LogLevel.Warning, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Warn(string format, params object[] arguments)
        {
            if (WarnEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                logger.Log(LogLevel.Warning, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Warn(string msg, Exception t) => logger.Log(LogLevel.Warning, 0, msg, t, MessageFormatterFunc);

        public override bool ErrorEnabled => logger.IsEnabled(LogLevel.Error);

        public override void Error(string msg) => logger.Log(LogLevel.Error, 0, msg, null, MessageFormatterFunc);

        public override void Error(string format, object arg)
        {
            if (ErrorEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                logger.Log(LogLevel.Error, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Error(string format, object argA, object argB)
        {
            if (ErrorEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                logger.Log(LogLevel.Error, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Error(string format, params object[] arguments)
        {
            if (ErrorEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                logger.Log(LogLevel.Error, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Error(string msg, Exception t) => logger.Log(LogLevel.Error, 0, msg, t, MessageFormatterFunc);
    }
}