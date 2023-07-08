namespace Putin.Commands;

using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class Spawn : ICommand
{
    public string Command { get; } = "putin";

    public string[] Aliases { get; } = new[] { "vlad" };

    public string Description { get; } = "Spawn Putin, usage: putin <player name or id>";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (!sender.CheckPermission("putin.spawn"))
        {
            response = "You don't have permission to execute this command.";
            return false;
        }

        if (arguments.Count != 1)
        {
            response = "Usage: putin <player name or id>";
            return false;
        }

        if (Player.Get(arguments.At(0)) is Player player)
        {
            if (!API.PutinAPI.TrySpawnPutin(player))
            {
                response = $"{player.Nickname} Has been already spawned as Putin!";
                return false;
            }

            response = $"{player.Nickname} Has been spawned as Putin";
            return true;
        }

        response = "Player not found";
        return false;
    }
}