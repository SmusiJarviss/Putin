namespace Putin.API;

using Exiled.API.Features;
using global::Putin.Component;
using System.Collections.Generic;
using System.Linq;

public static class PutinAPI
{
    /// <summary>
    /// Gets all active Putin instances.
    /// </summary>
    public static HashSet<Player> PutinPlayers => Player.List.Where(p => p.SessionVariables.ContainsKey("putin")).ToHashSet();

    /// <summary>
    /// Checks if the specified player is Putin.
    /// </summary>
    /// <param name="player">The player to check.</param>
    /// <returns>True if the player is Putin, otherwise false.</returns>
    public static bool IsPutin(this Player player) => PutinPlayers.Contains(player);

    /// <summary>
    /// Tries to spawn a player as Putin if they are not already.
    /// </summary>
    /// <param name="player">The player to spawn Putin for.</param>
    /// <returns>True if Putin was successfully spawned, false if the player is already Putin.</returns>
    public static bool TrySpawnPutin(this Player player) => PutinPlayers.Contains(player) ? false : player.GameObject.AddComponent<PutinComponent>();

    /// <summary>
    /// Tries to kill the specified player if they are Putin.
    /// </summary>
    /// <param name="player">The player to kill.</param>
    /// <param name="reason">The reason for the player's death.</param>
    /// <returns>True if the player was successfully killed, false if the player is not Putin.</returns>
    public static bool TryKillPutin(this Player player, string reason)
    {
        if (!PutinPlayers.Contains(player))
            return false;

        player.Kill(reason);
        return true;
    }
}