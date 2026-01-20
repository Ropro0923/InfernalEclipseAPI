using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Events;

namespace InfernalEclipseAPI.Core.Systems.BossRush.DialogueSystems
{
    public static class CustomBossRushDialogue
    {
        public const string tierFiveDialogues = "InfernalEclipseAPII:tierFiveDialogues";

        private static bool _active;
        private static int _index;
        private static int _delay;

        private struct Line
        {
            public string Key;
            public int Delay;
            public Func<bool> Skip;
            public Line(string key, int delay, Func<bool> skip = null)
            {
                Key = key;
                Delay = delay;
                Skip = skip;
            }
        }

        private static readonly Dictionary<string, Line[]> _events = new()
        {
            {
                tierFiveDialogues,
                new[]
                {
                    new Line("Mods.InfernalEclipseAPI.Events.BossRushTierFiveEndText_1", LumUtils.SecondsToFrames(2.40f) - 30),
                    new Line("Mods.InfernalEclipseAPI.Events.BossRushTierFiveEndText_2", LumUtils.SecondsToFrames(5.45f) - 30),
                    new Line("Mods.InfernalEclipseAPI.Events.BossRushTierFiveEndText_3", LumUtils.SecondsToFrames(5.03f) - 30)
                }
            }
        };

        public static void Start(string eventId)
        {
            if (!_events.TryGetValue(eventId, out _))
                return;

            _active = true;
            _index = 0;
            _delay = 4;
        }

        public static bool Active => _active;

        public static bool Tick()
        {
            if (!_active)
                return false;

            if (!_events.TryGetValue(tierFiveDialogues, out var lines) || lines.Length == 0)
            {
                _active = false;
                return false;
            }

            if (_index >= lines.Length)
            {
                _delay = 0;
                _active = false;
                return false;
            }

            if (_delay > 0)
            {
                _delay--;
            }
            else
            {
                // Find next unskipped line
                while (_index < lines.Length && lines[_index].Skip is not null && lines[_index].Skip!.Invoke())
                    _index++;

                if (_index >= lines.Length)
                {
                    _active = false;
                    return false;
                }

                var line = lines[_index];
                // Use Calamity's display helper + Xeroc color
                CalamityUtils.DisplayLocalizedText(line.Key, BossRushEvent.XerocTextColor);

                _delay = line.Delay;
                _index++;
            }

            // Stall boss spawn countdown while reading.
            if (BossRushEvent.BossRushSpawnCountdown < 180)
                BossRushEvent.BossRushSpawnCountdown = _delay + 180;

            return true;
        }
    }
}
