using KMod;
using HarmonyLib;
using PeterHan.PLib.Core;  // 包含 PUtil、LocString、PLocalization
using PeterHan.PLib.Options;// 如需注册 Mod 设置界面
using PeterHan.PLib.UI;
using System.Collections.Generic;
using PeterHan.PLib.Database;


namespace MaxRadboltGen
{
    public class ModuleSupport : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);
            PUtil.InitLibrary();
            // 3. 扫描并注册 LocString 中的键
            LocString.CreateLocStringKeys(typeof(Strings));                         

            // 4. 注册所有本地化文本
            new PLocalization().Register();                                         

            // 5. （可选）注册 Mod 设置面板
            new POptions().RegisterOptions(this, typeof(MaxRadboltGenOptions));    

            // 6. 调试输出
            Debug.Log("MaxRadboltGen Mod with PLocalization loaded!");
        }
    }
}
