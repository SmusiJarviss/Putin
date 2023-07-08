namespace Putin;

using Exiled.API.Features;
using global::Putin.Component;
using MEC;
using System.Linq;

public class ServerHandlers
{
    public void RoundStarted()
    {
        Timing.CallDelayed(0.8f, () =>
        {
            Player player = Player.List.Where(x => x.Role.Team != PlayerRoles.Team.SCPs).First();

            if (player is not null)
                player.GameObject.AddComponent<PutinComponent>();
        });
    }
}