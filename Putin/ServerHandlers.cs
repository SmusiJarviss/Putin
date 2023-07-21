namespace Putin;

using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using global::Putin.API;
using global::Putin.Component;
using MEC;
using System.Linq;

public class ServerHandlers
{
    public void RoundStarted()
    {
        Timing.CallDelayed(0.8f, () =>
        {
            if (UnityEngine.Random.Range(0, 101) <= Putin.Singleton.Config.PutinConfigs.SpawnChance)
            {
                Player player = Player.List.Where(x => x.Role.Team != PlayerRoles.Team.SCPs).First();

                if (player is not null)
                    player.GameObject.AddComponent<PutinComponent>();
            }
        });
    }

    public void OnEndingRound(EndingRoundEventArgs ev)
    {
        bool ntfDetected = false;
        bool putinDetected = false;

        foreach (Player player in Player.List)
        {
            if (player is null)
                continue;

            if (!putinDetected && player.IsPutin())
            {
                putinDetected = true;
                continue;
            }

            if (!ntfDetected)
                ntfDetected = player.Role.Team == PlayerRoles.Team.FoundationForces;
        }

        if (ntfDetected && putinDetected)
            ev.IsRoundEnded = false;
    }
}