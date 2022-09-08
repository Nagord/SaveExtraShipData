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

        public override void Draw()
        {
            Toggle(SaveExtraShipData.SavePerFileDefault, "Save Per File Default");
        }

        
    }
}
