using PulsarModLoader;

namespace SaveExtraShipData
{
    public static class GlobalConfigSettings
    {
        public static SaveValue<bool> SavePerFileDefault = new SaveValue<bool>("SavePerFileDefault", false);
        public static SaveValue<bool> SaveO2Level = new SaveValue<bool>("SaveO2Level", false);
        public static SaveValue<bool> SaveBiohazardLevel = new SaveValue<bool>("SaveBiohazardLevel", false);
        public static SaveValue<bool> SaveWarpCharge = new SaveValue<bool>("SaveWarpCharge", false);
        public static SaveValue<bool> SaveAutoTargeting = new SaveValue<bool>("SaveAutoTargeting", false);
        public static SaveValue<bool> SaveShieldStatus = new SaveValue<bool>("SaveShieldStatus", false);
        public static SaveValue<bool> SaveShieldIntegrity = new SaveValue<bool>("SaveShieldIntegrity", false);
        public static SaveValue<bool> SaveReactorPowerSettings = new SaveValue<bool>("SaveReactorPowerSettings", false);
        public static SaveValue<bool> SaveReactorOCStatus = new SaveValue<bool>("SaveReactorOCStatus", false);
        public static SaveValue<bool> SaveAuxReactor = new SaveValue<bool>("SaveAuxReactor", false);
        public static SaveValue<bool> SaveFuelCellLoaded = new SaveValue<bool>("SaveFuelCellLoaded", false);
        public static SaveValue<bool> SaveSystemPowerSettings = new SaveValue<bool>("SaveSystemPowerSettings", false);
        public static SaveValue<bool> SaveSystemHealthLevels = new SaveValue<bool>("SaveSystemHealthLevels", false);
        public static SaveValue<bool> SaveCloakState = new SaveValue<bool>("SaveCloakState", false);
        public static SaveValue<bool> SaveNuclearDeviceStatus = new SaveValue<bool>("SaveNuclearDeviceStatus", false);
        public static SaveValue<bool> SaveMissileLauncherSetup = new SaveValue<bool>("SaveMissileLauncherSetup", false);
        public static SaveValue<bool> SaveShipPowerLevers = new SaveValue<bool>("SaveShipPowerLevers", false);
        public static SaveValue<bool> SaveReactorSafetyToggle = new SaveValue<bool>("SaveReactorSafetyToggle", false);
        public static SaveValue<bool> SaveShipAlertLevel = new SaveValue<bool>("SaveShipAlertLevel", false);
        public static SaveValue<bool> SaveWarpTargets = new SaveValue<bool>("SaveWarpTargets", false);
        public static SaveValue<bool> SaveCrewAllowance = new SaveValue<bool>("SaveCrewAllowance", false);
        public static SaveValue<bool> SaveCaptainOrder = new SaveValue<bool>("SaveCaptainOrder", false);
    }
}
