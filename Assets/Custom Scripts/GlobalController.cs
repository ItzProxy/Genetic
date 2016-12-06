using UnityEngine;
using System.Collections;
using System;

public class GlobalController : MonoBehaviour
{
    public MyLogHandler Log { get; set; }

    void Start()
    {
        Log = new MyLogHandler();
    }
}

public class MyLogHandler : ILogHandler
{
    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        Debug.logger.logHandler.LogFormat(logType, context, format, args);
    }

    public void LogException(Exception exception, UnityEngine.Object context)
    {
        Debug.logger.LogException(exception, context);
    }
}