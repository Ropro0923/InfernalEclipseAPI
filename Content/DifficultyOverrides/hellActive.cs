using InfernumSaveSystem = InfernumMode.Core.GlobalInstances.Systems.WorldSaveSystem;

namespace InfernalEclipseAPI.Content.DifficultyOverrides
{
    internal class hellActive
    {
        public static bool InfernumActive
        {
            get => InfernumSaveSystem.InfernumModeEnabled;
        }
    }
}
