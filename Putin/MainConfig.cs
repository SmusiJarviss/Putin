namespace Putin;

using Exiled.API.Interfaces;
using global::Putin.Configs;
using System.ComponentModel;

public class MainConfig : IConfig
{
    [Description("If the plugin is enabled or not.")]
    public bool IsEnabled { get; set; } = true;

    [Description("Whether or not debug messages should be shown.")]
    public bool Debug { get; set; } = false;

    public PutinConfigs PutinConfigs { get; private set; } = new();

    public KGBConfigs KGBConfigs { get; private set; } = new();
}