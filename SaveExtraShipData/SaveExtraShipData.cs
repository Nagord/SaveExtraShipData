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
        public static bool SaveCaptainOrder = true;

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
                    if (SaveAutoTargeting)
                    {
                        writer.Write(playerShip.AutoTarget);    //bool TutoTarget
                    }
                    writer.Write(SaveShieldStatus);             //bool SaveShieldStatus
                    if (SaveShieldStatus)
                    {
                        writer.Write(playerShip.ShieldFreqMode);//int ShieldFrequency
                    }
                    writer.Write(SaveShieldIntegrity);          //bool SaveShieldIntegrity
                    if (SaveShieldIntegrity)
                    {
                        writer.Write(playerShip.MyStats.ShieldsCurrent); //float ShieldIntegrity
                    }
                    writer.Write(SaveReactorPowerSettings);     //bool SaveReactorPowerSettings
                    if (SaveReactorPowerSettings)
                    {
                        writer.Write(playerShip.SystemPowerLevels[0]); //float
                        writer.Write(playerShip.SystemPowerLevels[1]); //float
                        writer.Write(playerShip.SystemPowerLevels[2]); //float
                        writer.Write(playerShip.SystemPowerLevels[3]); //float
                        writer.Write(playerShip.ReactorTotalPowerLimitPercent); //float
                    }
                    writer.Write(SaveReactorSafetyToggle);      //bool SaveReactorSafetyToggle
                    if (SaveReactorSafetyToggle)
                    {
                        writer.Write(playerShip.ReactorCoolingEnabled); //bool
                    }
                    writer.Write(SaveAuxReactor);               //bool SaveAuxReactor
                    if (SaveAuxReactor)
                    {
                        writer.Write(playerShip.AuxConfig);     //byte
                    }
                    writer.Write(SaveFuelCellLoaded);           //bool SaveFuelCellLoaded
                    if (SaveFuelCellLoaded)
                    {
                        writer.Write(playerShip.WarpCapsuleIsLoaded); //bool
                    }
                    writer.Write(SaveShipPowerLevers);          //bool SaveShipPowerLevers
                    if (SaveShipPowerLevers)
                    {
                        writer.Write(playerShip.StartupSwitchBoard.GetStatus(0)); //bool
                        writer.Write(playerShip.IsShipOSBootingUp);               //bool
                        writer.Write(playerShip.StartupSwitchBoard.GetStatus(1)); //bool
                        writer.Write(playerShip.CrewControlEnabled);              //bool
                        writer.Write(playerShip.IsPrimingWarpDrive);              //bool
                        writer.Write(playerShip.StartupSwitchBoard.GetStatus(2)); //bool
                    }
                    writer.Write(SaveSystemPowerSettings);      //bool SaveSystemPowerSettings
                    if (SaveSystemPowerSettings)
                    {
                        writer.Write(playerShip.PowerPercent_SysIntConduits[0]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[1]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[2]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[3]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[4]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[5]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[6]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[7]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[8]); //float
                        writer.Write(playerShip.PowerPercent_SysIntConduits[10]);//float
                        int maxturrets = playerShip.MyStats.GetSlot(ESlotType.E_COMP_TURRET).MaxItems;
                        for (int i = 0; i < maxturrets; i++)
                        {
                            writer.Write(playerShip.PowerPercent_SysIntConduits[11 + i]); //float
                        }
                        if (playerShip.MyStats.GetSlot(ESlotType.E_COMP_AUTO_TURRET).MaxItems > 0)
                        {
                            writer.Write(playerShip.PowerPercent_SysIntConduits[15]); //float
                        }
                    }
                    writer.Write(SaveSystemHealthLevels);       //bool SaveSystemHealthLevels
                    if (SaveSystemHealthLevels)
                    {
                        writer.Write(playerShip.ComputerSystem.Health);    //float
                        writer.Write(playerShip.EngineeringSystem.Health); //float
                        writer.Write(playerShip.WeaponsSystem.Health);     //float
                        writer.Write(playerShip.LifeSupportSystem.Health); //float
                    }
                    writer.Write(SaveCloakState);               //bool SaveCloakState
                    if (SaveCloakState)
                    {
                        writer.Write(playerShip.GetIsCloakingSystemBeingPrimed()); //bool
                        writer.Write(playerShip.CloakingSystemPrimeAmt);           //float
                    }
                    writer.Write(SaveNuclearDeviceStatus);      //bool SaveNuclearDeviceStatus
                    if (SaveNuclearDeviceStatus)
                    {
                        writer.Write(playerShip.NuclearLaunchStage);                  //int
                        if (playerShip.NuclearLaunchStage > 0)
                        {
                            writer.Write(playerShip.LoadedNuclearDevice.SubType);     //int
                            writer.Write(playerShip.LoadedNuclearDevice.Level);       //int
                            writer.Write(playerShip.NukeActivator.GetSwitchStatus(0));//bool
                            writer.Write(playerShip.NukeActivator.GetSwitchStatus(0));//bool
                        }
                    }
                    writer.Write(SaveMissileLauncherSetup);     //bool SaveMissileLauncherSetup
                    if (SaveMissileLauncherSetup)
                    {
                        Dictionary<uint, int> items = new Dictionary<uint, int>();
                        foreach (PLSlotItem slot in playerShip.MyStats.GetSlot(ESlotType.E_COMP_TRACKERMISSILE))
                        {
                            if (slot != null)
                            {
                                items.Add(slot.getHash(), ((PLTrackerMissile)slot).TargetedSystemID);
                            }
                        }
                        writer.Write(items.Count);              //int
                        foreach (KeyValuePair<uint, int> item in items)
                        {
                            writer.Write(item.Key);             //uint
                            writer.Write(item.Value);           //int
                        }
                    }
                    writer.Write(SaveO2Level);                  //bool Save02Level 
                    if (SaveO2Level)
                    {
                        writer.Write(playerShip.MyStats.OxygenLevel);//float
                    }
                    writer.Write(SaveBiohazardLevel);           //bool SaveBiohazardLevel
                    if (SaveBiohazardLevel)
                    {
                        writer.Write(playerShip.AcidicAtmoBoostAlpha);//float
                    }
                    writer.Write(SaveShipAlertLevel);           //bool SaveShipAlertLevel
                    if (SaveShipAlertLevel)
                    {
                        writer.Write(playerShip.AlertLevel);    //int
                    }
                    writer.Write(SaveCrewAllowance);            //bool SaveCrewAllowance
                    if (SaveCrewAllowance)
                    {
                        writer.Write(PLServer.Instance.CurrentCrewCreditsAvailableToCrew); //int
                    }
                    writer.Write(SaveWarpCharge);               //bool SaveWarpCharge
                    if (SaveWarpCharge)
                    {
                        writer.Write((int)playerShip.WarpChargeStage);     //int
                        writer.Write(playerShip.WarpChargeState_Levels[0]);//float
                        writer.Write(playerShip.WarpChargeState_Levels[1]);//float
                        writer.Write(playerShip.WarpChargeState_Levels[2]);//float
                    }
                    writer.Write(SaveWarpTargets);              //bool SaveWarpTargets
                    if (SaveWarpTargets)
                    {
                        writer.Write(PLServer.Instance.m_ShipCourseGoals.Count);//int
                        foreach (int coursegoal in PLServer.Instance.m_ShipCourseGoals)
                        {
                            writer.Write(coursegoal);           //int
                        }
                    }
                    writer.Write(SaveCaptainOrder);             //bool SaveCommandState
                    if (SaveCaptainOrder)
                    {
                        writer.Write(PLServer.Instance.CaptainsOrdersID);//int
                    }
                }
                return myStream;
            }
        }
    }
}
