namespace Putin.Component;

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using UnityEngine;

public class PutinComponent : MonoBehaviour
{
    internal Player Player { get; private set; }

    private void Awake()
    {
        Player = Player.Get(gameObject);
        Player.SessionVariables.Add("putin", true);
        SubscribeEvents();
    }

    private void Start()
    {
        Player.Role.Set(Putin.Singleton.Config.PutinConfigs.Role);
        Player.Health = Player.MaxHealth = Putin.Singleton.Config.PutinConfigs.Health;
        Player.HumeShield = Putin.Singleton.Config.PutinConfigs.HumeShield;
        Player.Broadcast(Putin.Singleton.Config.PutinConfigs.SpawnBroadcast.Duration, Putin.Singleton.Config.PutinConfigs.SpawnBroadcast.Content.Replace("{player}", Player.Nickname));

        if (Putin.Singleton.Config.PutinConfigs.EnableRank)
        {
            Player.RankName = Putin.Singleton.Config.PutinConfigs.RankName;
            Player.RankColor = Putin.Singleton.Config.PutinConfigs.RankColor;
        }

        Player.IsBypassModeEnabled = Putin.Singleton.Config.PutinConfigs.BypassMode;
        Player.Position = Room.Get(Putin.Singleton.Config.PutinConfigs.SpawnLocation).Position + (Vector3.up * 1.3f);
        Player.ResetInventory(new ItemType[] { ItemType.GrenadeHE, ItemType.GunCOM18, ItemType.GunCOM15 });
    }

    private void FixedUpdate()
    {
        if (Player is null || Player.Role.Type != Putin.Singleton.Config.PutinConfigs.Role)
            Destroy();
    }

    private void PartiallyDestroy()
    {
        UnsubscribeEvents();
        if (Player is null)
            return;

        Player.SessionVariables.Remove("putin");
        Player.RankColor = null;
        Player.RankName = null;
    }

    private void OnDestroy() => PartiallyDestroy();

    public void Destroy()
    {
        try
        {
            Destroy(this);
        }
        catch (Exception ex)
        {
            Log.Error(ex);
        }
    }

    private void SubscribeEvents()
    {
        Exiled.Events.Handlers.Player.ProcessingHotkey += OnProcessingHotkey;
        Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUpItem;
        Exiled.Events.Handlers.Player.ChangingItem += OnChangingItem;
    }

    private void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Player.ProcessingHotkey -= OnProcessingHotkey;
        Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUpItem;
        Exiled.Events.Handlers.Player.ChangingItem -= OnChangingItem;
    }

    private void OnProcessingHotkey(ProcessingHotkeyEventArgs ev)
    {
        if (ev.Player != Player)
            return;

        switch (ev.Hotkey)
        {
            case HotkeyButton.Grenade:
                Functions.Abilities.ThermobaricAbility(Player);
                break;
            case HotkeyButton.PrimaryFirearm:
                Functions.Abilities.KGBAbility(Player);
                break;
            case HotkeyButton.SecondaryFirearm:
                Functions.Abilities.NukeAbility(Player);
                break;
        }

        ev.IsAllowed = false;
    }

    private void OnPickingUpItem(PickingUpItemEventArgs ev)
    {
        if (ev.Player != Player)
            return;

        ev.IsAllowed = false;
    }

    private void OnChangingItem(ChangingItemEventArgs ev)
    {
        if (ev.Player != Player)
            return;

        ev.IsAllowed = false;
    }
}