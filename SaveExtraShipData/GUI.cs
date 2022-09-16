using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.GUILayout;

namespace SaveExtraShipData
{
    internal class GUI : PulsarModLoader.CustomGUI.ModSettingsMenu
    {
        public override string Name()
        {
            return "ExtraShipData Save Options";
        }

        public override void OnOpen()
        {
            if (PLServer.Instance == null)
            {
                SaveExtraShipData.SavePerFile = true;
                SaveExtraShipData.LoadGlobalSettings();
            }
        }

        public override void Draw()
        {
            if (Button("Save settings to this game file:" + (SaveExtraShipData.SavePerFile ? "<color=blue>On</color>" : "<color=blue>Off</color>")))
            {
                SaveExtraShipData.SavePerFile = !SaveExtraShipData.SavePerFile;
                if(!SaveExtraShipData.SavePerFile)
                {
                    SaveExtraShipData.LoadGlobalSettings();
                }
            }
            GlobalConfigSettings.SavePerFileDefault.Value = Toggle(GlobalConfigSettings.SavePerFileDefault.Value, "Default");

            if (Button("Save O2 Level:" + (SaveExtraShipData.SaveO2Level ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveO2Level = !SaveExtraShipData.SaveO2Level;
                if(!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveO2Level.Value = SaveExtraShipData.SaveO2Level;
                }
            }
            if (Button("Save Biohazard Level:" + (SaveExtraShipData.SaveBiohazardLevel ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveBiohazardLevel = !SaveExtraShipData.SaveBiohazardLevel;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveBiohazardLevel.Value = SaveExtraShipData.SaveBiohazardLevel;
                }
            }
            if (Button("Save Warp Charge:" + (SaveExtraShipData.SaveWarpCharge ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveWarpCharge = !SaveExtraShipData.SaveWarpCharge;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveWarpCharge.Value = SaveExtraShipData.SaveWarpCharge;
                }
            }
            if (Button("Save Auto Targeting:" + (SaveExtraShipData.SaveAutoTargeting ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveAutoTargeting = !SaveExtraShipData.SaveAutoTargeting;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveAutoTargeting.Value = SaveExtraShipData.SaveAutoTargeting;
                }
            }
            if (Button("Save Shield Status:" + (SaveExtraShipData.SaveShieldStatus ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveShieldStatus = !SaveExtraShipData.SaveShieldStatus;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveShieldStatus.Value = SaveExtraShipData.SaveShieldStatus;
                }
            }
            if (Button("Save Shield Integrity:" + (SaveExtraShipData.SaveShieldIntegrity ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveShieldIntegrity = !SaveExtraShipData.SaveShieldIntegrity;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveShieldIntegrity.Value = SaveExtraShipData.SaveShieldIntegrity;
                }
            }
            if (Button("Save Reactor Power Settings:" + (SaveExtraShipData.SaveReactorPowerSettings ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveReactorPowerSettings = !SaveExtraShipData.SaveReactorPowerSettings;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveReactorPowerSettings.Value = SaveExtraShipData.SaveReactorPowerSettings;
                }
            }
            if (Button("Save Reactor OC Status:" + (SaveExtraShipData.SaveReactorOCStatus ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveReactorOCStatus = !SaveExtraShipData.SaveReactorOCStatus;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveReactorOCStatus.Value = SaveExtraShipData.SaveReactorOCStatus;
                }
            }
            if (Button("Save Aux Reactor Config:" + (SaveExtraShipData.SaveAuxReactor ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveAuxReactor = !SaveExtraShipData.SaveAuxReactor;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveAuxReactor.Value = SaveExtraShipData.SaveAuxReactor;
                }
            }
            if (Button("Save System Health Levels:" + (SaveExtraShipData.SaveSystemHealthLevels ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveSystemHealthLevels = !SaveExtraShipData.SaveSystemHealthLevels;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveSystemHealthLevels.Value = SaveExtraShipData.SaveSystemHealthLevels;
                }
            }
            if (Button("Save Cloak State:" + (SaveExtraShipData.SaveCloakState ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveCloakState = !SaveExtraShipData.SaveCloakState;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveCloakState.Value = SaveExtraShipData.SaveCloakState;
                }
            }
            if (Button("Save Nuclear Device Status:" + (SaveExtraShipData.SaveNuclearDeviceStatus ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveNuclearDeviceStatus = !SaveExtraShipData.SaveNuclearDeviceStatus;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveNuclearDeviceStatus.Value = SaveExtraShipData.SaveNuclearDeviceStatus;
                }
            }
            if (Button("Save Missile Launcher Setup:" + (SaveExtraShipData.SaveMissileLauncherSetup ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveMissileLauncherSetup = !SaveExtraShipData.SaveMissileLauncherSetup;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveMissileLauncherSetup.Value = SaveExtraShipData.SaveMissileLauncherSetup;
                }
            }
            if (Button("Save Ship Power Levers:" + (SaveExtraShipData.SaveShipPowerLevers ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveShipPowerLevers = !SaveExtraShipData.SaveShipPowerLevers;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveShipPowerLevers.Value = SaveExtraShipData.SaveShipPowerLevers;
                }
            }
            if (Button("Save Reactor Safety Toggle:" + (SaveExtraShipData.SaveReactorSafetyToggle ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveReactorSafetyToggle = !SaveExtraShipData.SaveReactorSafetyToggle;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveReactorSafetyToggle.Value = SaveExtraShipData.SaveReactorSafetyToggle;
                }
            }
            if (Button("Save Ship Alert Level:" + (SaveExtraShipData.SaveShipAlertLevel ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveShipAlertLevel = !SaveExtraShipData.SaveShipAlertLevel;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveShipAlertLevel.Value = SaveExtraShipData.SaveShipAlertLevel;
                }
            }
            if (Button("Save Warp Targets:" + (SaveExtraShipData.SaveWarpTargets ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveWarpTargets = !SaveExtraShipData.SaveWarpTargets;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveWarpTargets.Value = SaveExtraShipData.SaveWarpTargets;
                }
            }
            if (Button("Save Crew Allowance:" + (SaveExtraShipData.SaveCrewAllowance ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveCrewAllowance = !SaveExtraShipData.SaveCrewAllowance;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveCrewAllowance.Value = SaveExtraShipData.SaveCrewAllowance;
                }
            }
            if (Button("Save Captain Order:" + (SaveExtraShipData.SaveCaptainOrder ? "<color=green>On</color>" : "<color=red>Off</color>")))
            {
                SaveExtraShipData.SaveCaptainOrder = !SaveExtraShipData.SaveCaptainOrder;
                if (!SaveExtraShipData.SavePerFile)
                {
                    GlobalConfigSettings.SaveCaptainOrder.Value = SaveExtraShipData.SaveCaptainOrder;
                }
            }
        }
    }
}
