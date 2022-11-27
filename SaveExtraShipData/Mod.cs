using PulsarModLoader;

namespace SaveExtraShipData
{
    public class Mod : PulsarMod
    {
        public Mod()
        {
            if (!SaveExtraShipData.SavePerFile)
            {
                SaveExtraShipData.LoadGlobalSettings();
            }
        }

        public override string Version => "1.0.0";

        public override string Author => "Dragon";

        public override string Name => "SaveExtraShipData";

        public override string LongDescription => "Some pieces of data aren't saved, so this mod saves them. Each option is customizable.\r\n\r\nSaves: \r\nO2 Level, Warp Charge, Auto Targeting, Shield Status; Modulate/Static, Shield Integrity, Engineer station power levels, Aux Reactor Config, System Power levels, System Damage Levels, Cloak, Nuclear device status, Missile Launcher Setup (targeted system, current missile selection), Ship Power (Main Power, System Interface, Manual screen override, Shields), Safety Toggle, Ship Alert Level, Warp Targets, Crew Allowance, Captain Order, Coolant Status, Blind Jump Lock, Ammo Box fill, Distress Signal, Ship Position";

        public override string HarmonyIdentifier()
        {
            return $"{Author}.{Name}";
        }
    }
}
