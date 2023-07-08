namespace Putin.Configs;

using Exiled.API.Features;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;

public class KGBConfigs
{
    [Description("KGB role starting health.")]
    public float Health { get; set; } = 120;

    [Description("The broadcast displayed at the initial spawn.")]
    public Broadcast SpawnBroadcast { get; set; } = new("<b><size=20><color=red>{player}</color>, you have spawned as a<color=cyan>KGB</color> member.\nProtect Putin!</size></b>", 10);

    [Description("The RoleTypeId of the KGB role.")]
    public RoleTypeId Role { get; set; } = RoleTypeId.ClassD;

    [Description("If the rank is enabled or not.")]
    public bool EnableRank { get; set; } = true;

    [Description("The rank name.")]
    public string RankName { get; set; } = "KGB #{number}";

    [Description("The rank color.")]
    public string RankColor { get; set; } = "red";

    [Description("The list of starting items for KGB.")]
    public IEnumerable<ItemType> Inventory { get; set; } = new ItemType[]
    {
        ItemType.GunAK,
        ItemType.Ammo762x39,
        ItemType.Ammo762x39,
        ItemType.ArmorCombat,
        ItemType.Adrenaline,
    };
}