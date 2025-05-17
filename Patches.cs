using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;

namespace MaxRadboltGen
{
    [HarmonyPatch(typeof(HighEnergyParticleSpawner), "LauncherUpdate")]
    public class ParticleSpawner_LauncherUpdate_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (int i = 0; i < codes.Count; i++)
            {
                var ci = codes[i];
                if (ci.opcode == OpCodes.Ldc_R4 && ci.operand is float f && Mathf.Approximately(f, 0.1f))
                {
                    Debug.Log($"[MaxRadboltGen] Changed {f} to 0.5f, and line i is {i}");
                    codes[i].operand = 0.5f;
                    break;
                }
            }
            return codes.AsEnumerable();
        }
    }
}
