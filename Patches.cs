using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using PeterHan.PLib.Options;

namespace MaxRadboltGen
{
    [HarmonyPatch(typeof(HighEnergyParticleSpawner), "LauncherUpdate")]
    public class ParticleSpawner_LauncherUpdate_Patch
    {
        private static MaxRadboltGenOptions _options;
        private static float GetMultiplier()
        {
            if (_options == null)
            {
                _options = POptions.ReadSettings<MaxRadboltGenOptions>() ?? new MaxRadboltGenOptions();
                Debug.Log($"[MaxRadboltGen] Loaded config: MaxRadboltGen = {_options.MaxRadboltGen}");
            }
            return _options.MaxRadboltGen;
        }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            float multiplier = GetMultiplier();
            for (int i = 0; i < codes.Count; i++)
            {
                var ci = codes[i];
                if (ci.opcode == OpCodes.Ldc_R4 && ci.operand is float f && Mathf.Approximately(f, 0.1f))
                {
                    Debug.Log($"[MaxRadboltGen] Changed {f} to {multiplier}, and line i is {i}");
                    codes[i].operand = multiplier;
                    break;
                }
            }
            return codes.AsEnumerable();
        }
    }
}
