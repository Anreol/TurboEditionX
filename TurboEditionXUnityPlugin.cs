using BepInEx;
using EmotesAPI;
using System;
using System.IO;
using TurboEditionX.Modules;
using TurboEditionZ;

namespace TurboEditionX
{
    [BepInDependency(TurboEdition.TurboUnityPlugin.ModGuid, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(CustomEmotesAPI.PluginGUID,BepInDependency.DependencyFlags.SoftDependency)]
    [BepInPlugin(ModGuid, ModIdentifier, ModVer)]
    public class TurboEditionXUnityPlugin : BaseUnityPlugin
    {
        internal const string ModVer =
#if DEBUG
            "9999." +
#endif
            "0.0.1";

        internal const string ModIdentifier = "TurboEditionX";
        internal const string ModGuid = "com.Anreol." + ModIdentifier;

        public static TurboEditionXUnityPlugin instance;
        public static PluginInfo pluginInfo;

        public void Awake()
        {
            pluginInfo = Info;
            TEXLog tEXLog = new TEXLog(Logger);
            TEXLog.outputAlways = true;
            if (!BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TurboEdition.TurboUnityPlugin.ModGuid))
            {
                //Huh?
                Destroy(this);
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(CustomEmotesAPI.PluginGUID))
            {
                EmoteSupport.Enable();
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(AncientScepter.AncientScepterMain.ModGuid))
            {
                //ScepterSupport.Enable();
            }
        }
    }
}
