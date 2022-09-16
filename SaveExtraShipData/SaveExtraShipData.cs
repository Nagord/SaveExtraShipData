using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaveExtraShipData
{
    public class SaveExtraShipData : PulsarModLoader.SaveData.PMLSaveData
    {
        public static bool LoadingData = false;
        public static bool SavePerFile = GlobalConfigSettings.SavePerFileDefault;
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

        public static CachedData CachedDataInstance = null;
        public class CachedData
        {
            public bool AutoTarget = true;
            public int ShieldFrequency = 0;
            public float ShieldIntegrity = 0f;
            public float[] ReactorPowerLevels = { .5f, .5f, .5f, .5f, 1f };
            public bool ReactorCoolingEnabled = true;
            public byte AuxReactorConfig = byte.MaxValue;
            public bool WarpCapsuleLoaded = false;
            public bool[] ShipPowerLevers = new bool[] { true, true, true, true, true, true };
            public float[] PowerPercent_SysIntConduits = { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };
            public float SystemHealth0 = 1f;
            public float SystemHealth1 = 1f;
            public float SystemHealth2 = 1f;
            public float SystemHealth3 = 1f;
            public bool CloakingSystemActive = false;
            public bool CloakingSystemCharging = false;
            public float CloakingSystemCharge = 0f;
            public int NuclearDeviceLaunchStage = 0;
            public int Loadedtype = 0;
            public int Loadedlevel = 0;
            public bool SwitchStatus0 = false;
            public bool SwitchStatus1 = false;
            public Dictionary<uint, int> items = new Dictionary<uint, int>();
            public float OxygenLevel = 1f;
            public float BiohazardLevel = 0f;
            public int ShipAlertLevel = 0;
            public int CrewAllowance = 2000;
            public int WarpChargeStage = 0;
            public float[] WarpCharge = new float[3];
            public int[] CourseGoals = new int[0];
            public int CaptainOrderID = 0;
        }

        public static void LoadGlobalSettings()
        {
            SaveO2Level = GlobalConfigSettings.SaveO2Level;
            SaveBiohazardLevel = GlobalConfigSettings.SaveBiohazardLevel;
            SaveWarpCharge = GlobalConfigSettings.SaveWarpCharge;
            SaveAutoTargeting = GlobalConfigSettings.SaveAutoTargeting;
            SaveShieldStatus = GlobalConfigSettings.SaveShieldStatus;
            SaveShieldIntegrity = GlobalConfigSettings.SaveShieldIntegrity;
            SaveReactorPowerSettings = GlobalConfigSettings.SaveReactorPowerSettings;
            SaveReactorOCStatus = GlobalConfigSettings.SaveReactorOCStatus;
            SaveAuxReactor = GlobalConfigSettings.SaveAuxReactor;
            SaveFuelCellLoaded = GlobalConfigSettings.SaveFuelCellLoaded;
            SaveSystemPowerSettings = GlobalConfigSettings.SaveSystemPowerSettings;
            SaveSystemHealthLevels = GlobalConfigSettings.SaveSystemHealthLevels;
            SaveCloakState = GlobalConfigSettings.SaveCloakState;
            SaveNuclearDeviceStatus = GlobalConfigSettings.SaveNuclearDeviceStatus;
            SaveMissileLauncherSetup = GlobalConfigSettings.SaveMissileLauncherSetup;
            SaveShipPowerLevers = GlobalConfigSettings.SaveShipPowerLevers;
            SaveReactorSafetyToggle = GlobalConfigSettings.SaveReactorSafetyToggle;
            SaveShipAlertLevel = GlobalConfigSettings.SaveShipAlertLevel;
            SaveWarpTargets = GlobalConfigSettings.SaveWarpTargets;
            SaveCrewAllowance = GlobalConfigSettings.SaveCrewAllowance;
            SaveCaptainOrder = GlobalConfigSettings.SaveCaptainOrder;
        }

        public override string Identifier()
        {
            return "SaveExtraShipData";
        }

        public override void LoadData(MemoryStream dataStream, uint VersionID)
        {
            using (BinaryReader reader = new BinaryReader(dataStream))
            {
                CachedDataInstance = new CachedData();
                SavePerFile = reader.ReadBoolean();                           //bool SavePerFile
                SaveAutoTargeting = reader.ReadBoolean();                     //bool SaveAutoTargeting
                if (SaveAutoTargeting)
                {
                    CachedDataInstance.AutoTarget = reader.ReadBoolean();     //bool
                }
                SaveShieldStatus = reader.ReadBoolean();                      //bool SaveShieldStatus
                if (SaveShieldStatus)
                {
                    CachedDataInstance.ShieldFrequency = reader.ReadInt32();  //int
                }
                SaveShieldIntegrity = reader.ReadBoolean();                   //bool SaveShieldIntegrity
                if (SaveShieldIntegrity)
                {
                    CachedDataInstance.ShieldIntegrity = reader.ReadSingle(); //float
                }
                SaveReactorPowerSettings = reader.ReadBoolean();              //bool SaveReactorPowerSettings
                if (SaveReactorPowerSettings)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        CachedDataInstance.ReactorPowerLevels[i] = reader.ReadSingle(); //float *5
                    }
                }
                SaveReactorSafetyToggle = reader.ReadBoolean();               //bool SaveReactorSafetyToggle
                if (SaveReactorSafetyToggle)
                {
                    CachedDataInstance.ReactorCoolingEnabled = reader.ReadBoolean(); //bool
                }
                SaveAuxReactor = reader.ReadBoolean();                        //bool SaveAuxReactor
                if (SaveAuxReactor)
                {
                    CachedDataInstance.AuxReactorConfig = reader.ReadByte();  //byte
                }
                SaveFuelCellLoaded = reader.ReadBoolean();                    //bool SaveFuelCellLoaded
                if (SaveFuelCellLoaded)
                {
                    CachedDataInstance.WarpCapsuleLoaded = reader.ReadBoolean(); //bool
                }
                SaveShipPowerLevers = reader.ReadBoolean();                   //bool SaveShipPowerLevers
                if (SaveShipPowerLevers)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        CachedDataInstance.ShipPowerLevers[i] = reader.ReadBoolean(); //bool *6
                    }
                }
                SaveSystemPowerSettings = reader.ReadBoolean();               //bool SaveSystemPowerSettings
                if (SaveSystemPowerSettings)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        CachedDataInstance.PowerPercent_SysIntConduits[i] = reader.ReadSingle(); //float *16
                    }
                }
                SaveSystemHealthLevels = reader.ReadBoolean();                //bool SaveSystemHealthLevels
                if (SaveSystemHealthLevels)
                {
                    CachedDataInstance.SystemHealth0 = reader.ReadSingle();   //float
                    CachedDataInstance.SystemHealth1 = reader.ReadSingle();   //float
                    CachedDataInstance.SystemHealth2 = reader.ReadSingle();   //float
                    CachedDataInstance.SystemHealth3 = reader.ReadSingle();   //float
                }
                SaveCloakState = reader.ReadBoolean();                        //bool SaveCloakState
                if (SaveCloakState)
                {
                    CachedDataInstance.CloakingSystemActive = reader.ReadBoolean();  //bool
                    CachedDataInstance.CloakingSystemCharging = reader.ReadBoolean();//bool
                    CachedDataInstance.CloakingSystemCharge = reader.ReadSingle();   //float
                }
                SaveNuclearDeviceStatus = reader.ReadBoolean();               //bool SaveNuclearDeviceStatus
                if (SaveNuclearDeviceStatus)
                {
                    CachedDataInstance.NuclearDeviceLaunchStage = reader.ReadInt32();
                    if (CachedDataInstance.NuclearDeviceLaunchStage > 0)
                    {
                        CachedDataInstance.Loadedtype = reader.ReadInt32();
                        CachedDataInstance.Loadedlevel = reader.ReadInt32();
                        CachedDataInstance.SwitchStatus0 = reader.ReadBoolean();
                        CachedDataInstance.SwitchStatus1 = reader.ReadBoolean();
                    }
                }
                SaveMissileLauncherSetup = reader.ReadBoolean();              //bool SaveMissileLauncherSetup
                if (SaveMissileLauncherSetup)
                {
                    Dictionary<uint, int> items = new Dictionary<uint, int>();
                    int length = reader.ReadInt32();                          //int
                    for (int i = 0; i < length; i++)
                    {
                        uint hash = reader.ReadUInt32();                      //uint
                        int target = reader.ReadInt32();                      //int
                        items.Add(hash, target);
                    }
                }
                SaveO2Level = reader.ReadBoolean();                           //bool Save02Level
                if (SaveO2Level)
                {
                    CachedDataInstance.OxygenLevel = reader.ReadSingle();     //float
                }
                SaveBiohazardLevel = reader.ReadBoolean();                    //bool SaveBiohazardLevel
                if (SaveBiohazardLevel)
                {
                    CachedDataInstance.BiohazardLevel = reader.ReadSingle();  //float
                }
                SaveShipAlertLevel = reader.ReadBoolean();                    //bool SaveShipAlertLevel
                if (SaveShipAlertLevel)
                {
                    CachedDataInstance.ShipAlertLevel = reader.ReadInt32();   //int
                }
                SaveCrewAllowance = reader.ReadBoolean();                     //bool SaveCrewAllowance
                if (SaveCrewAllowance)
                {
                    CachedDataInstance.CrewAllowance = reader.ReadInt32();    //int
                }
                SaveWarpCharge = reader.ReadBoolean();                        //bool SaveWarpCharge
                if (SaveWarpCharge)
                {
                    CachedDataInstance.WarpChargeStage = reader.ReadInt32();  //int
                    for (int i = 0; i < 3; i++)
                    {
                        CachedDataInstance.WarpCharge[i] = reader.ReadSingle();//float *3
                    }
                }
                SaveWarpTargets = reader.ReadBoolean();                       //bool SaveWarpTargets
                if (SaveWarpTargets)
                {
                    CachedDataInstance.CourseGoals = new int[reader.ReadInt32()]; //int
                    for (int i = 0; i < CachedDataInstance.CourseGoals.Length; i++)
                    {
                        CachedDataInstance.CourseGoals[i] = reader.ReadInt32();   //int
                    }
                }
                SaveCaptainOrder = reader.ReadBoolean();                      //bool SaveCommandState
                if (SaveCaptainOrder)
                {
                    CachedDataInstance.CaptainOrderID = reader.ReadInt32();   //int
                }
                LoadingData = true;
            }
        }

        public override MemoryStream SaveData()
        {
            PLShipInfo playerShip = PLEncounterManager.Instance.PlayerShip;
            if (!SavePerFile) //Set settings to Global before saving.
            {
                LoadGlobalSettings();
            }
            MemoryStream myStream = new MemoryStream();
            using (BinaryWriter writer = new BinaryWriter(myStream, Encoding.Default, true))
            {
                writer.Write(SavePerFile);                  //bool SavePerFile
                writer.Write(SaveAutoTargeting);            //bool SaveAutoTargeting
                if (SaveAutoTargeting)
                {
                    writer.Write(playerShip.AutoTarget);    //bool AutoTarget
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
                    writer.Write(playerShip.ShipOSIsBooted);               //bool
                    writer.Write(playerShip.StartupSwitchBoard.GetStatus(1)); //bool
                    writer.Write(playerShip.CrewControlEnabled);              //bool
                    writer.Write(playerShip.WarpDriveIsPrimed);              //bool
                    writer.Write(playerShip.StartupSwitchBoard.GetStatus(2)); //bool
                }
                writer.Write(SaveSystemPowerSettings);      //bool SaveSystemPowerSettings
                if (SaveSystemPowerSettings)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        writer.Write(playerShip.PowerPercent_SysIntConduits[i]); //float *16
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
                    writer.Write(playerShip.GetIsCloakingSystemActive());      //bool
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
