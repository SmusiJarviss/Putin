# Putin

The Putin plugin is a plugin for SCP: Secret Laboratory that works with EXILED 7.2.0.
It adds a simple role called "Putin" with some unique features, fully configurable in the configs.
This plugin also includes an API that can be integrated with other plugins.

## Features

- The Putin role spawns on the surface at the beginning of the game.
- Putin has the bypass mode enabled and cannot pick up or use items.
- Using the grenade hotkey, Putin can activate thermobaric missiles by throwing multiple grenades in the direction they are looking.
- Using the primary weapon hotkey, Putin can spawn the KGB, which are players taken from the spectators and turned into custom roles to protect Putin.
- Using the secondary weapon hotkey, Putin can activate a nuclear bomb that detonates the entire site, killing themselves as well. This ability can only be activated when Putin has 5 HP.

## API

The Putin plugin includes an API that can be used to interact with active instances of Putin.
Summary:

- `PutinPlayers`: Gets all active Putin instances.
- `IsPutin(player)`: Checks if the specified player is Putin.
- `TrySpawnPutin(player)`: Tries to spawn a player as Putin if they are not already.
- `TryKillPutin(player, reason)`: Tries to kill the specified player if they are Putin.


# DISCLAIMER
The Putin Plugin is solely intended as an entertainment product for the game SCP: Secret Laboratory and does not aim to promote, endorse, or spread any form of political or ideological propaganda.
The plugin has been developed with the sole purpose of providing an enjoyable gaming experience and does not represent a stance or commentary on the current political situation between Russia and Ukraine.
Please consider the Putin Plugin as a fictional creation within the game's context and refrain from drawing any political or diplomatic conclusions or implications.
