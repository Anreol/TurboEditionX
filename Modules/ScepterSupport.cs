using EmotesAPI;
using RoR2.Skills;
using System;
using System.Collections.Generic;
using System.Text;
using TurboEditionZ;
using UnityEngine;

namespace TurboEditionX.Modules
{
    internal class ScepterSupport
    {
        public static void Enable()
        {
            Version ver = new Version(AncientScepter.AncientScepterMain.ModVer);
            if (AncientScepter.AncientScepterMain..Info.Metadata.Version < ver)
            {
                TEXLog.LogW($"Using a CustomEmotesAPI version lower than what TurboEditionX was made for! Issues might arise.\nExpected version: CustomEmotesAPI {ver} or higher.");
            }
            AncientScepter.AncientScepterItem.instance.RegisterScepterSkill(TurboEdition.Assets.mainAssetBundle.LoadAsset<SkillDef>("todo1"), "GrenadierBody", TurboEdition.Assets.mainAssetBundle.LoadAsset<SkillDef>("todo2"));
        }
    }
}
