namespace Putin.Functions;

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Components;
using global::Putin.Component;
using InventorySystem.Items.ThrowableProjectiles;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class Abilities
{
    private static bool isThermoBaricCooldown;
    private static bool isKGBCooldown;

    private static IEnumerator<float> ThermobaricCooldown()
    {
        isThermoBaricCooldown = true;
        yield return Timing.WaitForSeconds(Putin.Singleton.Config.PutinConfigs.ThermoBaricCooldown);
        isThermoBaricCooldown = false;
    }

    private static IEnumerator<float> KGBCooldown()
    {
        isKGBCooldown = true;
        yield return Timing.WaitForSeconds(Putin.Singleton.Config.PutinConfigs.KGBCooldown);
        isKGBCooldown = false;
    }

    private static IEnumerator<float> AnnounceNuke()
    {
        Cassie.Clear();
        Cassie.Message(Putin.Singleton.Config.PutinConfigs.NukeCassie);

        foreach (Room room in Room.List)
            room.RoomLightController.NetworkOverrideColor = Color.red;

        yield return Timing.WaitForSeconds(3);

        while (true)
        {
            if (!Cassie.IsSpeaking)
            {
                foreach (Player player in Player.List.Where(x => x.Role.Type != PlayerRoles.RoleTypeId.Spectator))
                    player.Kill("Putin has thrown a Tsar Bomb.");

                Warhead.Detonate();
                break;
            }

            yield return Timing.WaitForSeconds(0.65f);
        }
    }

    internal static void ThermobaricAbility(Player player)
    {
        if (isThermoBaricCooldown)
        {
            player.ShowHint($"You have to wait {Putin.Singleton.Config.PutinConfigs.ThermoBaricCooldown} in order to use the Thermobaric bomb ability.", 5);
            return;
        }

        for (int i = 0; i < Putin.Singleton.Config.PutinConfigs.ThermoBaricAmount; i++)
        {
            ThrownProjectile projectile = player.ThrowGrenade(ProjectileType.FragGrenade).Projectile.Base;
            projectile.gameObject.AddComponent<CollisionHandler>().Init(player.GameObject, projectile);
            player.PlayGunSound(ItemType.GrenadeHE, 1);
        }

        Timing.RunCoroutine(ThermobaricCooldown());
        player.ShowHint("You have destroyed some American outposts.", 5);
    }

    internal static void KGBAbility(Player player)
    {
        if (isKGBCooldown)
        {
            player.ShowHint($"You have to wait {Putin.Singleton.Config.PutinConfigs.KGBCooldown} in order to use the KGB ability.", 5);
            return;
        }

        for (int i = 0; i < Putin.Singleton.Config.PutinConfigs.KGBAmount; i++)
        {
            Player[] players = Player.List.Where(x => x.Role.Type == PlayerRoles.RoleTypeId.Spectator).ToArray();

            if (players.Count() >= i)
                break;

            players[i].GameObject.AddComponent<KGBComponent>().Player.Position = player.Position + (Vector3.up * 1.3f);
        }

        Timing.RunCoroutine(KGBCooldown());
        player.ShowHint("You have summoned Russian Federation protectors.", 5);
    }

    internal static void NukeAbility(Player player)
    {
        if (player.Health <= Putin.Singleton.Config.PutinConfigs.NukeMinHealth)
        {
            player.ShowHint("You have to wait until you have 1HP in order to use the Nuke ability.", 5);
            return;
        }

        Timing.RunCoroutine(AnnounceNuke());
    }
}