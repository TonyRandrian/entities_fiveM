using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;

namespace Entities.Client
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers["onClientResourceStart"] +=
                new Action<string>(OnClientResourceStart);

            API.RegisterCommand("get",
                new Action<int, List<object>, string>((source, args, raw) =>
                {
                    int ped = API.PlayerPedId();

                    Vector3 position =
                        API.GetEntityCoords(ped, true);

                    Debug.WriteLine(position.ToString());

                    List<Entity> entities =
                        API.GetEntitiesInRadius(
                            position.X,
                            position.Y,
                            position.Z,
                            10.0f,
                            2,
                            true,
                            null
                        );

                    foreach (Entity entity in entities)
                    {
                        Debug.WriteLine(entity.ToString());
                    }

                }), false);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (API.GetCurrentResourceName() != resourceName)
                return;

            Debug.WriteLine("Entity script enabled");
        }
    }
}