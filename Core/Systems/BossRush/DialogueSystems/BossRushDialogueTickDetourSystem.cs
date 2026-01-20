using System.Reflection;
using MonoMod.RuntimeDetour;

namespace InfernalEclipseAPI.Core.Systems.BossRush.DialogueSystems
{
    public sealed class BossRushDialogueTickDetourSystem : ModSystem
    {
        private static Hook? _tickHook;

        public override void Load()
        {
            var calamityAsm = ModLoader.GetMod("CalamityMod").Code;
            var brdsType = calamityAsm.GetType("CalamityMod.Systems.BossRushDialogueSystem");
            var tick = brdsType?.GetMethod("Tick", BindingFlags.Static | BindingFlags.NonPublic);
            if (tick is null)
                return;

            _tickHook = new Hook(tick, Tick_Detour);
        }

        public override void Unload()
        {
            _tickHook?.Dispose();
            _tickHook = null;
        }

        private delegate void Orig_Tick();

        private static void Tick_Detour(Orig_Tick orig)
        {
            // Run Calamity's normal dialogue system first.
            orig();

            // Now run our brand-new event, if active.
            // This will stall spawn countdown on its own while active.
            if (CustomBossRushDialogue.Active)
                CustomBossRushDialogue.Tick();
        }
    }
}
