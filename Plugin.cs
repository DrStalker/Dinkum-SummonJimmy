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
    private readonly ConfigEntry<KeyCode> _hotKeyDisable;
    public Plugin()
    {

    _hotKey        = Config.Bind("General", "HotKey",        KeyCode.F10,"Press to summon Jimmy");
    _hotKeyDisable = Config.Bind("General", "HotKeyDisable", KeyCode.F11,"Press to dismiss Jimmy");
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
        else if (Input.GetKeyDown(_hotKeyDisable.Value))
        {
            MarketPlaceManager.manage.despawnJimmiesBoat();
        }

    }



}

