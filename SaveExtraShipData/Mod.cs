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

        public override string HarmonyIdentifier()
        {
            return $"{Author}.{Name}";
        }
    }
}
