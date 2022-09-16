using PulsarModLoader;

namespace SaveExtraShipData
{
    public static class GlobalConfigSettings
    {
        public static SaveValue<bool> SavePerFileDefault = new SaveValue<bool>("SavePerFileDefault", true);
        public static SaveValue<bool> SaveO2Level = new SaveValue<bool>("SaveO2Level", true);
        public static SaveValue<bool> SaveBiohazardLevel = new SaveValue<bool>("SaveBiohazardLevel", true);
        public static SaveValue<bool> SaveWarpCharge = new SaveValue<bool>("SaveWarpCharge", true);
        public static SaveValue<bool> SaveAutoTargeting = new SaveValue<bool>("SaveAutoTargeting", true);
        public static SaveValue<bool> SaveShieldStatus = new SaveValue<bool>("SaveShieldStatus", true);
        public static SaveValue<bool> SaveShieldIntegrity = new SaveValue<bool>("SaveShieldIntegrity", true);
        public static SaveValue<bool> SaveReactorPowerSettings = new SaveValue<bool>("SaveReactorPowerSettings", true);
        public static SaveValue<bool> SaveReactorOCStatus = new SaveValue<bool>("SaveReactorOCStatus", true);
        public static SaveValue<bool> SaveAuxReactor = new SaveValue<bool>("SaveAuxReactor", true);
        public static SaveValue<bool> SaveFuelCellLoaded = new SaveValue<bool>("SaveFuelCellLoaded", true);
        public static SaveValue<bool> SaveSystemPowerSettings = new SaveValue<bool>("SaveSystemPowerSettings", true);
        public static SaveValue<bool> SaveSystemHealthLevels = new SaveValue<bool>("SaveSystemHealthLevels", true);
        public static SaveValue<bool> SaveCloakState = new SaveValue<bool>("SaveCloakState", true);
        public static SaveValue<bool> SaveNuclearDeviceStatus = new SaveValue<bool>("SaveNuclearDeviceStatus", true);
        public static SaveValue<bool> SaveMissileLauncherSetup = new SaveValue<bool>("SaveMissileLauncherSetup", true);
        public static SaveValue<bool> SaveShipPowerLevers = new SaveValue<bool>("SaveShipPowerLevers", true);
        public static SaveValue<bool> SaveReactorSafetyToggle = new SaveValue<bool>("SaveReactorSafetyToggle", true);
        public static SaveValue<bool> SaveShipAlertLevel = new SaveValue<bool>("SaveShipAlertLevel", true);
        public static SaveValue<bool> SaveWarpTargets = new SaveValue<bool>("SaveWarpTargets", true);
        public static SaveValue<bool> SaveCrewAllowance = new SaveValue<bool>("SaveCrewAllowance", true);
        public static SaveValue<bool> SaveCaptainOrder = new SaveValue<bool>("SaveCaptainOrder", true);
    }
}
