namespace Putin.Component;

using Exiled.API.Features;
using System;
using UnityEngine;

public class KGBComponent : MonoBehaviour
{
    internal Player Player { get; private set; }

    private void Awake()
    {
        Player = Player.Get(gameObject);
    }

    private void Start()
    {
        Player.Role.Set(Putin.Singleton.Config.KGBConfigs.Role);
        Player.Health = Player.MaxHealth = Putin.Singleton.Config.KGBConfigs.Health;
        Player.Broadcast(Putin.Singleton.Config.KGBConfigs.SpawnBroadcast.Duration, Putin.Singleton.Config.KGBConfigs.SpawnBroadcast.Content.Replace("{player}", Player.Nickname));

        if (Putin.Singleton.Config.KGBConfigs.EnableRank)
        {
            Player.RankName = Putin.Singleton.Config.KGBConfigs.RankName.Replace("{number}", UnityEngine.Random.Range(0, 101).ToString());
            Player.RankColor = Putin.Singleton.Config.KGBConfigs.RankColor;
        }

        Player.ResetInventory(Putin.Singleton.Config.KGBConfigs.Inventory);
    }

    private void FixedUpdate()
    {
        if (Player is null || Player.Role.Type != Putin.Singleton.Config.KGBConfigs.Role)
            Destroy();
    }

    public void Destroy()
    {
        try
        {
            Destroy(this);
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
    }
}
