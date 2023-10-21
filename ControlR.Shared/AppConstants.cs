﻿using ControlR.Shared.Enums;
using ControlR.Shared.Services;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ControlR.Shared;

public static partial class AppConstants
{
    public const string AgentCertificateThumbprint = "4b6235f1c44ab3a5f29bf40ad85b442269f6ee52";

    public static string AgentFileName
    {
        get
        {
            return EnvironmentHelper.Instance.Platform switch
            {
                SystemPlatform.Windows => "ControlR.Agent.exe",
                SystemPlatform.Linux => "ControlR.Agent",
                SystemPlatform.MacOS => throw new PlatformNotSupportedException(),
                SystemPlatform.MacCatalyst => throw new PlatformNotSupportedException(),
                _ => throw new PlatformNotSupportedException(),
            };
        }
    }

    public static string DownloadsUri => "https://controlr.app";

    public static string ServerUri
    {
        get
        {
            var envUri = Environment.GetEnvironmentVariable("ControlRServerUri");
            if (Uri.TryCreate(envUri, UriKind.Absolute, out _))
            {
                return envUri;
            }

            if (OperatingSystem.IsWindows() && Debugger.IsAttached)
            {
                return "http://localhost:5120";
            }
            return "https://app.controlr.app";
        }
    }

    public static string VncFileName
    {
        get
        {
            return EnvironmentHelper.Instance.Platform switch
            {
                SystemPlatform.Windows => "winvnc.exe",
                SystemPlatform.Linux => "vncserver",
                SystemPlatform.MacOS => throw new PlatformNotSupportedException(),
                SystemPlatform.MacCatalyst => throw new PlatformNotSupportedException(),
                _ => throw new PlatformNotSupportedException(),
            };
        }
    }

    public static string VncZipFileName
    {
        get
        {
            return EnvironmentHelper.Instance.Platform switch
            {
                SystemPlatform.Windows => "winvnc.zip",
                SystemPlatform.Linux => "vncserver.zip",
                SystemPlatform.MacOS => throw new PlatformNotSupportedException(),
                SystemPlatform.MacCatalyst => throw new PlatformNotSupportedException(),
                _ => throw new PlatformNotSupportedException(),
            };
        }
    }

    [GeneratedRegex("[^A-Za-z0-9_-]")]
    public static partial Regex UsernameValidator();
}