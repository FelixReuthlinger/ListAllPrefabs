using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ModTemplate;

[BepInPlugin(ModGuid, ModName, ModVersion)]
public class ModTemplatePlugin : BaseUnityPlugin
{
    private const string ModName = "ModTemplate";
    private const string ModVersion = "1.0.0";
    private const string Author = "{your name here}";
    private const string ModGuid = Author + "." + ModName;
    private const string ConfigFileName = ModGuid + ".cfg";
    private static string ConfigFileFullPath = Paths.ConfigPath + Path.DirectorySeparatorChar + ConfigFileName;

    private readonly Harmony _harmony = new(ModGuid);

    public static readonly ManualLogSource ModTemplateLogger =
        BepInEx.Logging.Logger.CreateLogSource(ModName);

    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {ModGuid} is loaded!");
        
        Assembly assembly = Assembly.GetExecutingAssembly();
        _harmony.PatchAll(assembly);
    }
}
