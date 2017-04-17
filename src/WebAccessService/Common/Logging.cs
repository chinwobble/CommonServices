//using System;
//using System.Diagnostics;
//using NLog;
//using NLog.Targets;
//using PostSharp;
//using PostSharp.Aspects;

//namespace MvcApp.Web.Aspects
//{
//    [Serializable]
//    public class LogMethodCallAttribute : MethodInterceptionAspect
//    {
//        public override void OnInvoke(MethodInterceptionArgs eventArgs)
//        {
//            var methodName = eventArgs.Method.Name.Replace("~", String.Empty);
//            var className = eventArgs.Method.DeclaringType.ToString();
//            className = className.Substring(className.LastIndexOf(".") + 1, (className.Length - className.LastIndexOf(".") - 1));
//            var log = LogManager.GetCurrentClassLogger();
//            var stopWatch = new Stopwatch();

//            var contextId = Guid.NewGuid().ToString();
//            NestedDiagnosticsContext.Push(contextId);

//            log.Info("{0}() called", methodName);
//            stopWatch.Start();
//            NestedDiagnosticsContext.Pop();

//            try
//            {
//                eventArgs.Proceed();
//            }
//            catch (Exception ex)
//            {
//                var innermostException = GetInnermostException(ex);
//                NestedDiagnosticsContext.Set("exception", innermostException.ToString().Substring(0, Math.Min(innermostException.ToString().Length, 2000)));
//                log.Error("{0}() failed with error: {1}", methodName, innermostException.Message);
//                NestedDiagnosticsContext.Remove("exception");
//                throw innermostException;
//            }

//            NLog.NDC.Push(contextId);
//            stopWatch.Stop();
//            NLog.MDC.Set("DurationInMs", stopWatch.ElapsedMilliseconds.ToString());
//            log.Info("{0}() completed", methodName);
//            NLog.MDC.Remove("DurationInMs");
//            stopWatch = null;
//            NLog.NDC.Pop();
//        }

//        private static Exception GetInnermostException(Exception ex)
//        {
//            var exception = ex;
//            while (null != exception.InnerException)
//            {
//                exception = exception.InnerException;
//            }

//            return exception;
//        }
//    }
//}