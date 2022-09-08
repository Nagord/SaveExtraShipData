using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveExtraShipData
{
    public class SaveExtraShipData : PulsarModLoader.SaveData.PMLSaveData
    {
        public static bool SavePerFileDefault = true;
        public static bool SavePerFile = true;
        public static bool SaveO2Level = true;
        public static bool SaveBiohazardLevel = true;
        public static bool SaveWarpCharge = true;
        public static bool SaveAutoTargeting = true;
        public static bool SaveShieldStatus = true;
        public static bool SaveShieldIntegrity = true;
        public static bool SaveReactorPowerSettings = true;
        public static bool SaveReactorOCStatus = true;
        public static bool SaveAuxReactor = true;
        public static bool SaveFuelCellLoaded = true;
        public static bool SaveSystemPowerSettings = true;
        public static bool SaveSystemHealthLevels = true;
        public static bool SaveCloakState = true;
        public static bool SaveNuclearDeviceStatus = true;
        public static bool SaveMissileLauncherSetup = true;
        public static bool SaveShipPowerLevers = true;
        public static bool SaveReactorSafetyToggle = true;
        public static bool SaveShipAlertLevel = true;
        public static bool SaveWarpTargets = true;
        public static bool SaveCrewAllowance = true;
        public static bool SaveCommandState = true;

        public override string Identifier()
        {
            return "SaveExtraShipData";
        }

        public override void LoadData(MemoryStream dataStream, uint VersionID)
        {
            throw new NotImplementedException();
        }

        public override MemoryStream SaveData()
        {
            PLShipInfo playerShip = PLEncounterManager.Instance.PlayerShip;
            using (MemoryStream myStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(myStream))
                {
                    writer.Write(SavePerFile);                  //bool SavePerFile
                    writer.Write(SaveAutoTargeting);            //bool SaveAutoTargeting
                    writer.Write(playerShip.AutoTarget);
                    writer.Write(SaveShieldStatus);             //bool SaveShieldStatus
                    writer.Write(playerShip.ShieldFreqMode);
                    writer.Write(SaveShieldIntegrity);          //bool SaveShieldIntegrity
                    writer.Write(playerShip.MyStats.ShieldsCurrent);
                    writer.Write(SaveReactorPowerSettings);     //bool SaveReactorPowerSettings
                    writer.Write(playerShip.SystemPowerLevels[0]);
                    writer.Write(playerShip.SystemPowerLevels[1]);
                    writer.Write(playerShip.SystemPowerLevels[2]);
                    writer.Write(playerShip.SystemPowerLevels[3]);
                    writer.Write(playerShip.ReactorTotalPowerLimitPercent);
                    writer.Write(SaveReactorSafetyToggle);      //bool SaveReactorSafetyToggle
                    writer.Write(playerShip.ReactorCoolingEnabled);
                    writer.Write(SaveAuxReactor);               //bool SaveAuxReactor
                    writer.Write(playerShip.AuxConfig);
                    writer.Write(SaveFuelCellLoaded);           //bool SaveFuelCellLoaded
                    writer.Write(playerShip.WarpCapsuleIsLoaded);
                    writer.Write(SaveShipPowerLevers);          //bool SaveShipPowerLevers
                    writer.Write(playerShip.StartupSwitchBoard.GetStatus(0));
                    writer.Write(playerShip.IsShipOSBootingUp);
                    writer.Write(playerShip.StartupSwitchBoard.GetStatus(1));
                    writer.Write(playerShip.CrewControlEnabled);
                    writer.Write(playerShip.IsPrimingWarpDrive);
                    writer.Write(playerShip.StartupSwitchBoard.GetStatus(2));
                    writer.Write(SaveSystemPowerSettings);      //bool SaveSystemPowerSettings
                    writer.Write(playerShip.PowerPercent_SysIntConduits[0]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[1]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[2]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[3]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[4]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[5]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[6]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[7]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[8]);
                    writer.Write(playerShip.PowerPercent_SysIntConduits[10]);
                    int maxturrets = playerShip.MyStats.GetSlot(ESlotType.E_COMP_TURRET).MaxItems;
                    for (int i = 0; i < maxturrets; i++)
                    {
                        writer.Write(playerShip.PowerPercent_SysIntConduits[11 + i]);
                    }
                    if (playerShip.MyStats.GetSlot(ESlotType.E_COMP_AUTO_TURRET).MaxItems > 0)
                    {
                        writer.Write(playerShip.PowerPercent_SysIntConduits[15]);
                    }
                    writer.Write(SaveSystemHealthLevels);       //bool SaveSystemHealthLevels
                    writer.Write(playerShip.ComputerSystem.Health);
                    writer.Write(playerShip.EngineeringSystem.Health);
                    writer.Write(playerShip.WeaponsSystem.Health);
                    writer.Write(playerShip.LifeSupportSystem.Health);
                    writer.Write(SaveCloakState);               //bool SaveCloakState
                    writer.Write(playerShip.GetIsCloakingSystemBeingPrimed());
                    writer.Write(playerShip.CloakingSystemPrimeAmt);
                    writer.Write(SaveNuclearDeviceStatus);      //bool SaveNuclearDeviceStatus
                    writer.Write(playerShip.NuclearLaunchStage);
                    if (playerShip.NuclearLaunchStage > 0)
                    {
                        writer.Write(playerShip.LoadedNuclearDevice.SubType);
                        writer.Write(playerShip.LoadedNuclearDevice.Level);
                        writer.Write(playerShip.NukeActivator.GetSwitchStatus(0));
                        writer.Write(playerShip.NukeActivator.GetSwitchStatus(0));
                    }
                    writer.Write(SaveMissileLauncherSetup);     //bool SaveMissileLauncherSetup
                    Dictionary<uint, int> items = new Dictionary<uint, int>();
                    foreach(PLSlotItem slot in playerShip.MyStats.GetSlot(ESlotType.E_COMP_TRACKERMISSILE))
                    {
                        if(slot != null)
                        {
                            items.Add(slot.getHash(), ((PLTrackerMissile)slot).TargetedSystemID);
                        }
                    }
                    writer.Write(items.Count);
                    foreach(KeyValuePair<uint, int> item in items)
                    {
                        writer.Write(item.Key);
                        writer.Write(item.Value);
                    }
                    writer.Write(SaveO2Level);                  //bool Save02Level 
                    writer.Write(playerShip.MyStats.OxygenLevel);
                    writer.Write(SaveBiohazardLevel);           //bool SaveBiohazardLevel
                    writer.Write(playerShip.AcidicAtmoBoostAlpha);
                    writer.Write(SaveShipAlertLevel);           //bool SaveShipAlertLevel
                    writer.Write(playerShip.AlertLevel);
                    writer.Write(SaveCrewAllowance);            //bool SaveCrewAllowance
                    writer.Write(PLServer.Instance.CurrentCrewCreditsAvailableToCrew);
                    writer.Write(SaveWarpCharge);               //bool SaveWarpCharge
                    writer.Write((int)playerShip.WarpChargeStage);
                    writer.Write(playerShip.WarpChargeState_Levels[0]);
                    writer.Write(playerShip.WarpChargeState_Levels[1]);
                    writer.Write(playerShip.WarpChargeState_Levels[2]);
                    writer.Write(SaveWarpTargets);              //bool SaveWarpTargets
                    writer.Write(PLServer.Instance.m_ShipCourseGoals.Count);
                    foreach(int coursegoal in PLServer.Instance.m_ShipCourseGoals)
                    {
                        writer.Write(coursegoal);
                    }
                    writer.Write(SaveCommandState);             //bool SaveCommandState
                    writer.Write(PLServer.Instance.CaptainsOrdersID);
                }
                return myStream;
            }
        }
    }
}
