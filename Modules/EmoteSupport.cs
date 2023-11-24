using EmotesAPI;
using RoR2.ContentManagement;
using System;
using System.Collections;
using TurboEditionZ;
using UnityEngine;

namespace TurboEditionX.Modules
{
    public static class EmoteSupport
    {
        public static void Enable()
        {
            Version ver = new Version(CustomEmotesAPI.VERSION);
            if (CustomEmotesAPI.instance.Info.Metadata.Version < ver)
            {
                TEXLog.LogW($"Using a CustomEmotesAPI version lower than what TurboEditionX was made for! Issues might arise.\nExpected version: CustomEmotesAPI {ver} or higher.");
            }
            TurboEdition.TEContent.onFinalizeAsync += SetupSkeletons;
        }

        private static IEnumerator SetupSkeletons(FinalizeAsyncArgs args)
        {
            TEXLog.LogW("Importing Grenadier's humanoid skeleton to CustomEmotesAPI...");
            GameObject skeleton = TurboEdition.Assets.mainAssetBundle.LoadAsset<GameObject>("GrenadierHumanoidSkeleton");
            if (skeleton == null)
            {
                TEXLog.LogE("Couldn't load Grenadier's humanoid skeleton. What went wrong?!");
            }
            else
            {
                CustomEmotesAPI.ImportArmature(TurboEdition.TEContent.Survivors.Grenadier.bodyPrefab, skeleton);
                CustomEmotesAPI.CreateNameTokenSpritePair(TurboEdition.TEContent.Survivors.Grenadier.displayNameToken, TurboEdition.Assets.mainAssetBundle.LoadAsset<Sprite>("texGrenadierUnlockIcon"));

                CustomEmotesAPI.animChanged += GrenadierAnimChanged;
            }
            yield return null;
        }

        private static void GrenadierAnimChanged(string newAnimation, BoneMapper mapper)
        {
            if (mapper.transform.name == "GrenadierHumanoidSkeleton")
            {
                //nooooooo stalkerrrrrrrrrrr chiildddddd, you /cannot/ hide your weeeeeeapons
                ChildLocator stalkerChild = mapper.transform.parent.GetComponent<ChildLocator>();
                if (newAnimation != "none")
                {
                    stalkerChild.FindChild("DemoGrenadeLauncherGrip").gameObject.SetActive(false);
                    stalkerChild.FindChild("DemoGrenadeLauncherCylinder").gameObject.SetActive(false);
                }
                else
                {
                    stalkerChild.FindChild("DemoGrenadeLauncherGrip").gameObject.SetActive(true);
                    stalkerChild.FindChild("DemoGrenadeLauncherCylinder").gameObject.SetActive(true);
                }
            }
        }
    }
}