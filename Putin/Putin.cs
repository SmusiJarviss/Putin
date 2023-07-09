namespace Putin;

using Exiled.API.Features;
using System;

public class Putin : Plugin<MainConfig>
{
    public override string Name => "Putin";

    public override string Author => "Smusi Jarvis";

    public override Version Version => new(1, 0, 1);

    public override Version RequiredExiledVersion => new(7, 2, 0);

    public static Putin Singleton { get; private set; }

    public ServerHandlers ServerHandlers { get; private set; }

    public override void OnEnabled()
    {
        Singleton = this;
        SubscribeEvents();

        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        UnSubscribeEvents();

        base.OnDisabled();
    }

    private void SubscribeEvents()
    {
        ServerHandlers = new();
        Exiled.Events.Handlers.Server.RoundStarted += ServerHandlers.RoundStarted;
    }

    private void UnSubscribeEvents()
    {
        Exiled.Events.Handlers.Server.RoundStarted -= ServerHandlers.RoundStarted;

        ServerHandlers = null;
        Singleton = null;
    }
}