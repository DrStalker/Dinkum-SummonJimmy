using System;
using System.Collections;
using System.Linq;
using BepInEx;
using BepInEx.Configuration;
using Mirror;
using UnityEngine;

namespace SummonJimmy;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private readonly ConfigEntry<KeyCode> _hotKey;
    public Plugin()
    {

    _hotKey        = Config.Bind("General", "HotKey",        KeyCode.F10,"Press to summon Jimmy");
    }
    
    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(_hotKey.Value))
        {
            // Is Jimmy already here?
            for (int i = 0; i < SaveLoad.saveOrLoad.vehiclesToSave.Count; i++)
            {
                if (SaveLoad.saveOrLoad.vehiclesToSave[i].saveId == 10)
                {
                    return;
                }
            }
            // No Jimmy (or at least no boat for him) so summon him
            MarketPlaceManager.manage.spawnJimmysBoat();
        }
    }



}

