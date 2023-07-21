namespace Putin.Configs;

using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using System.ComponentModel;

public class PutinConfigs
{
    [Description("Putin spawn chance.")]
    public float SpawnChance { get; set; } = 60f;

    [Description("Putin role starting health.")]
    public float Health { get; set; } = 1000;

    [Description("Putin role starting shield.")]
    public float HumeShield { get; set; } = 300;

    [Description("If the bypass mode is enabled or not.")]
    public bool BypassMode { get; set; } = true;

    [Description("The broadcast displayed at the initial spawn.")]
    public Broadcast SpawnBroadcast { get; set; } = new("<b><size=20><color=red>{player}</color>, you have spawned as <color=blue>Putin</color>.\nAvailable abilities:\n-Grenade Hotkey: <color=orange>Thermobaric Launcher</color>\n-Primary Firearm Hotkey: <color=orange>KGB Spawn</color>\n-Secondary Firearm Hotkey: <color=orange>Nuke Ability</color></size></b>", 10);

    [Description("The RoleTypeId of the KGB role.")]
    public RoleTypeId Role { get; set; } = RoleTypeId.Tutorial;

    [Description("If the rank is enabled or not.")]
    public bool EnableRank { get; set; } = true;

    [Description("The rank name.")]
    public string RankName { get; set; } = "Vladimir Putin";

    [Description("The rank color.")]
    public string RankColor { get; set; } = "red";

    [Description("The RoomType where Putin will be spawned.")]
    public RoomType SpawnLocation { get; set; } = RoomType.Surface;

    [Description("The cooldown for the thermobaric ability. (grenade hotkey).")]
    public float ThermoBaricCooldown { get; set; } = 30;

    [Description("The amount of grenade spawned by the thermobaric ability.")]
    public int ThermoBaricAmount { get; set; } = 8;

    [Description("The cooldown for the kgb ability. (primary weapon hotkey).")]
    public float KGBCooldown { get; set; } = 30;

    [Description("The amount of spectator taken and spawned as kgb.")]
    public int KGBAmount { get; set; } = 3;

    [Description("The amount of health required to activate the nuke ability. (secondary weapon hotkey).")]
    public float NukeMinHealth { get; set; } = 5;

    [Description("The cassie that will be played when nuke ability is active.")]
    public string NukeCassie { get; set; } = "pitch_0.15 .g4 pitch_0.2 jam_099_2 .g1 pitch_0.15 .g4 pitch_0.25 jam_099_2 pitch_0.949 .g4 danger . danger pitch_0.15 .g4 pitch_0.2 jam_099_2 .g1 pitch_0.15 .g4 pitch_0.25 jam_099_2 pitch_0.949 .g4 . . . pitch_0.949 .g4 warhead is about to detonate in T seconds 10 . 9 . 8 . 7 . 6 . 5 . 4 . 3 . 2 . 1";
}