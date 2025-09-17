using TheGame.Monsters;
using TheGame.Monsters.Zombies;
using System.Text.RegularExpressions;

namespace TheGame.SkillFileData;

public class SkillData
{
    private const string _fileName = "skill.cfg";
    private const string _npcs = "NPCs";
    private const string _weapons = "WEAPONS";
    private const string _chargeDistribution = "HEALTH/ARMOR CHARGE DISTRIBUTION";

    private const string _health = "health";
    private const string _dmg = "dmg";

    private const int _wordsCount = 4;

    private string[] _fileLines;

    public SkillData()
    {
        string currentDir = Directory.GetCurrentDirectory();

        try
        {
            string path = Path.GetFullPath(Path.Combine(currentDir, @"..\..\..")) + "\\";
            _fileLines = File.ReadAllLines(path + _fileName);
        }
        catch
        {
        }
    }

    public List<NPC>? GetNpcs()
    {
        if (_fileLines.Length < 2)
            return null;

        int npcsIndex = 0;

        for (int i = 0; i < _fileLines.Length; i++)
        {
            if (_fileLines[i].Contains(_npcs, StringComparison.OrdinalIgnoreCase))
            {
                npcsIndex = i;
                break;
            }
        }

        if (npcsIndex == 0)
            return null;

        List<NPC> NPCs = new List<NPC>();
        int initIndex = npcsIndex + 1;

        for (int i = initIndex; i < _fileLines.Length; i++)
        {
            if (!_fileLines[i].Contains("//"))
                continue;

            bool isNpc = _fileLines[i].Contains(nameof(Zombie), StringComparison.OrdinalIgnoreCase)
                      || _fileLines[i].Contains(nameof(Imp), StringComparison.OrdinalIgnoreCase)
                      || _fileLines[i].Contains(nameof(Demon), StringComparison.OrdinalIgnoreCase);

            if (isNpc)
            {
                NPC npc = new NPC();

                for (int k = i + 1; !_fileLines[k].Contains("//"); k++)
                {
                    i = k;

                    if (string.IsNullOrEmpty(_fileLines[k]))
                    {
                        continue;
                    }
                    else
                    {
                        _fileLines[k] = Regex.Replace(_fileLines[k], @"\s+", "_");
                        string[] skill = _fileLines[k].Split('_');

                        if (skill.Length != _wordsCount)
                            continue;

                        npc.Name = skill[1].ToLower();
                        string value = skill[3].Replace("\"", string.Empty);

                        ushort health;
                        if (skill[2].ToLower() == _health && UInt16.TryParse(value, out health))
                        {
                            npc.Health = health;
                            continue;
                        }

                        float dmg;
                        if (skill[2].ToLower() == _dmg && Single.TryParse(value, out dmg))
                            npc.Dmg = dmg > 0 ? dmg : 0;
                    }
                }

                if (!string.IsNullOrEmpty(npc.Name))
                    NPCs.Add(npc);
            }
            else if (_fileLines[i].Contains("=") && i != initIndex)
            {
                break;
            }
        }

        return NPCs;
    }
}
