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

    _hotKey = Config.Bind("General", "HotKey", KeyCode.F10,
        "Press to summon Jimmy");

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
            MarketPlaceManager.manage.despawnJimmiesBoat();
            MarketPlaceManager.manage.spawnJimmysBoat();

        }
    }



}

