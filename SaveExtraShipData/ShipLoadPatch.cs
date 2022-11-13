using HarmonyLib;
using PulsarModLoader.Utilities;
using System.Collections.Generic;

namespace SaveExtraShipData
{
    [HarmonyPatch(typeof(PLGlobal), "EnterNewGame")]
    internal class ShipLoadPatch
    {
        static void Postfix()
        {
            if(SaveExtraShipData.CachedDataInstance == null)
            {
                return;
            }
            PLShipInfo playership = PLEncounterManager.Instance.PlayerShip;
            if (SaveExtraShipData.SaveAutoTargeting)
            {
                playership.AutoTarget = SaveExtraShipData.CachedDataInstance.AutoTarget;
            }
            if (SaveExtraShipData.SaveShieldStatus)
            {
                playership.ShieldFreqMode = SaveExtraShipData.CachedDataInstance.ShieldFrequency;
            }
            if (SaveExtraShipData.SaveShieldIntegrity)
            {
                playership.MyShieldGenerator.Current = SaveExtraShipData.CachedDataInstance.ShieldIntegrity;
            }
            if (SaveExtraShipData.SaveReactorPowerSettings)
            {
                for (int i = 0; i < 4; i++)
                {
                    playership.SystemPowerLevels[i] = SaveExtraShipData.CachedDataInstance.ReactorPowerLevels[i];
                }
                playership.ReactorTotalPowerLimitPercent = SaveExtraShipData.CachedDataInstance.ReactorPowerLevels[4];
            }
            if (SaveExtraShipData.SaveReactorSafetyToggle)
            {
                playership.ReactorCoolingEnabled = SaveExtraShipData.CachedDataInstance.ReactorCoolingEnabled;
            }
            if (SaveExtraShipData.SaveAuxReactor)
            {
                playership.AuxConfig = SaveExtraShipData.CachedDataInstance.AuxReactorConfig;
            }
            if (SaveExtraShipData.SaveFuelCellLoaded)
            {
                playership.WarpCapsuleIsLoaded = SaveExtraShipData.CachedDataInstance.WarpCapsuleLoaded;
            }
            if (SaveExtraShipData.SaveShipPowerLevers)
            {
                playership.StartupSwitchBoard.SetStatus(0, SaveExtraShipData.CachedDataInstance.ShipPowerLevers[0]);
                playership.ShipOSIsBooted = SaveExtraShipData.CachedDataInstance.ShipPowerLevers[1];
                playership.StartupSwitchBoard.SetStatus(1, SaveExtraShipData.CachedDataInstance.ShipPowerLevers[2]);
                playership.CrewControlEnabled = SaveExtraShipData.CachedDataInstance.ShipPowerLevers[3];
                playership.WarpDriveIsPrimed = SaveExtraShipData.CachedDataInstance.ShipPowerLevers[4];
                playership.StartupSwitchBoard.SetStatus(2, SaveExtraShipData.CachedDataInstance.ShipPowerLevers[5]);
            }
            if (SaveExtraShipData.SaveSystemPowerSettings)
            {
                playership.PowerPercent_SysIntConduits = SaveExtraShipData.CachedDataInstance.PowerPercent_SysIntConduits;
            }
            if (SaveExtraShipData.SaveSystemHealthLevels)
            {
                playership.ComputerSystem.Health = SaveExtraShipData.CachedDataInstance.SystemHealth0;
                playership.EngineeringSystem.Health = SaveExtraShipData.CachedDataInstance.SystemHealth1;
                playership.WeaponsSystem.Health = SaveExtraShipData.CachedDataInstance.SystemHealth2;
                playership.LifeSupportSystem.Health = SaveExtraShipData.CachedDataInstance.SystemHealth3;
            }
            if (SaveExtraShipData.SaveCloakState)
            {
                playership.SetIsCloakingSystemActive(SaveExtraShipData.CachedDataInstance.CloakingSystemActive);
                playership.SetIsCloakingSystemPriming(SaveExtraShipData.CachedDataInstance.CloakingSystemCharging);
                playership.CloakingSystemPrimeAmt = SaveExtraShipData.CachedDataInstance.CloakingSystemCharge;
            }
            if (SaveExtraShipData.SaveNuclearDeviceStatus)
            {
                playership.NuclearLaunchStage = SaveExtraShipData.CachedDataInstance.NuclearDeviceLaunchStage;
                foreach (PLNuclearDevice item in playership.MyStats.GetSlot(ESlotType.E_COMP_NUCLEARDEVICE))
                {
                    if (item.SubType == SaveExtraShipData.CachedDataInstance.Loadedtype && item.Level == SaveExtraShipData.CachedDataInstance.Loadedlevel)
                    {
                        playership.LoadedNuclearDevice = item;
                        break;
                    }
                }
                if (SaveExtraShipData.CachedDataInstance.SwitchStatus0)
                {
                    playership.NukeActivator.OpenSwitch(0);
                }
                if (SaveExtraShipData.CachedDataInstance.SwitchStatus1)
                {
                    playership.NukeActivator.OpenSwitch(1);
                }

            }
            if (SaveExtraShipData.SaveMissileLauncherSetup)
            {
                foreach (PLTrackerMissile item in playership.MyStats.GetSlot(ESlotType.E_COMP_TRACKERMISSILE))
                {
                    uint keyToRemove = 0u;
                    foreach (KeyValuePair<uint, int> pair in SaveExtraShipData.CachedDataInstance.items)
                    {
                        if (item.getHash() == pair.Key)
                        {
                            item.TargetedSystemID = pair.Value;
                            keyToRemove = pair.Key;
                            break;
                        }
                    }
                    SaveExtraShipData.CachedDataInstance.items.Remove(keyToRemove);
                }
            }
            if (SaveExtraShipData.SaveO2Level)
            {
                playership.MyStats.OxygenLevel = SaveExtraShipData.CachedDataInstance.OxygenLevel;
            }
            if (SaveExtraShipData.SaveBiohazardLevel)
            {
                playership.AcidicAtmoBoostAlpha = SaveExtraShipData.CachedDataInstance.BiohazardLevel;
            }
            if (SaveExtraShipData.SaveShipAlertLevel)
            {
                playership.AlertLevel = SaveExtraShipData.CachedDataInstance.ShipAlertLevel;
            }
            if (SaveExtraShipData.SaveCrewAllowance)
            {
                PLServer.Instance.CurrentCrewCreditsAvailableToCrew = SaveExtraShipData.CachedDataInstance.CrewAllowance;
            }
            if (SaveExtraShipData.SaveWarpCharge)
            {
                playership.WarpChargeStage = (EWarpChargeStage)SaveExtraShipData.CachedDataInstance.WarpChargeStage;
                playership.WarpChargeState_Levels = SaveExtraShipData.CachedDataInstance.WarpCharge;
            }
            if (SaveExtraShipData.SaveWarpTargets)
            {
                int length = SaveExtraShipData.CachedDataInstance.CourseGoals.Length;
                for (int i = 0; i < length; i++)
                {
                    PLServer.Instance.m_ShipCourseGoals.Add(SaveExtraShipData.CachedDataInstance.CourseGoals[i]);
                }
            }
            if (SaveExtraShipData.SaveCaptainOrder)
            {
                PLServer.Instance.CaptainsOrdersID = SaveExtraShipData.CachedDataInstance.CaptainOrderID;
            }
            if (SaveExtraShipData.SaveCoolantPumpRate)
            {
                playership.ReactorCoolingPumpState = SaveExtraShipData.CachedDataInstance.CoolantPumpRate;
            }
            if (SaveExtraShipData.SaveDistressSignal)
            {
                if (SaveExtraShipData.CachedDataInstance.DistressSignalType != byte.MaxValue)
                {
                    foreach (PLDistressSignal item in playership.MyStats.GetSlot(ESlotType.E_COMP_DISTRESS_SIGNAL))
                    {
                        if (item.SubType == SaveExtraShipData.CachedDataInstance.DistressSignalType)
                        {
                            playership.SelectedDistressSignalNetID = item.NetID;
                            break;
                        }
                    }
                    playership.DistressSignalActive = SaveExtraShipData.CachedDataInstance.DistressSignalActive;
                }
            }
            if (SaveExtraShipData.SaveBlindJumpLock)
            {
                playership.BlindJumpUnlocked = SaveExtraShipData.CachedDataInstance.BlindJumpUnlocked;
            }
            if (SaveExtraShipData.SaveAmmoBoxSupply)
            {
                for (int i = 0; i < SaveExtraShipData.CachedDataInstance.AmmoSupplys.Length; i++)
                {
                    playership.MyAmmoRefills[i].SupplyAmount = SaveExtraShipData.CachedDataInstance.AmmoSupplys[i];
                }
            }
            if (SaveExtraShipData.SaveReactorHeat)
            {
                playership.MyStats.ReactorTempCurrent = SaveExtraShipData.CachedDataInstance.ReactorHeat;
            }
            if (SaveExtraShipData.SaveShipPosition)
            {
                playership.ExteriorRigidbody.position = SaveExtraShipData.CachedDataInstance.ShipPosition;
                playership.ExteriorRigidbody.rotation = SaveExtraShipData.CachedDataInstance.ShipRotation;
            }
            if (!SaveExtraShipData.SavePerFile)
            {
                SaveExtraShipData.LoadGlobalSettings();
            }
        }
    }
}
