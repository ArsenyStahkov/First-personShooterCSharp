using System.Reflection;
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
    private const string _max = "max";

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

    public int GetIndex(string dataName, int requiredLinesCount)
    {
        if (_fileLines.Length < requiredLinesCount)
            return 0;

        int initIndex = 0;

        for (int i = 0; i < _fileLines.Length; i++)
        {
            if (_fileLines[i].Contains(dataName, StringComparison.OrdinalIgnoreCase))
            {
                initIndex = i;
                break;
            }
        }

        if (initIndex == 0)
            return 0;

        return ++initIndex;
    }

    public List<NPC>? GetNpcs(Type type)
    {
        int initIndex = GetIndex(_npcs, 3);

        if (initIndex == 0)
            return null;

        List<NPC> NPCs = new List<NPC>();

        for (int i = initIndex; i < _fileLines.Length; i++)
        {
            if (!_fileLines[i].Contains("//"))
                continue;

            List<string>? typeNames = Assembly.GetAssembly(type).GetTypes()
                .Where(ourtype => ourtype.IsSubclassOf(type))
                .Select(type => type.Name)
                .ToList();

            bool isMatchByName = false;

            foreach (string typeName in typeNames)
            {
                if (_fileLines[i].Contains(typeName, StringComparison.OrdinalIgnoreCase))
                {
                    isMatchByName = true;
                    break;
                }
            }

            if (isMatchByName)
            {
                NPC npc = new NPC();

                for (int k = ++i; k < _fileLines.Length; k++)
                {
                    if (_fileLines[k].Contains("//"))
                        break;

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

                        isMatchByName = false;

                        foreach (string typeName in typeNames)
                        {
                            if (string.Equals(typeName, skill[1], StringComparison.OrdinalIgnoreCase))
                            {
                                isMatchByName = true;
                                break;
                            }
                        }

                        if (!isMatchByName)
                            continue;

                        npc.Name = skill[1].ToLower();
                        string value = skill[3].Replace("\"", string.Empty);

                        ushort health;
                        if (string.Equals(skill[2], _health, StringComparison.OrdinalIgnoreCase) && UInt16.TryParse(value, out health))
                        {
                            npc.Health = health;
                            continue;
                        }

                        float dmg;
                        if (string.Equals(skill[2], _dmg, StringComparison.OrdinalIgnoreCase) && Single.TryParse(value, out dmg))
                            npc.Dmg = dmg > 0 ? dmg : 0;
                    }
                }

                NPCs.Add(npc);
            }
            else if (_fileLines[i].Contains("=") && i != initIndex)
            {
                break;
            }
        }

        return NPCs;
    }

    public List<WEAPON>? GetWeapons(Type type)
    {
        int initIndex = GetIndex(_weapons, 3);

        if (initIndex == 0)
            return null;

        List<WEAPON> WEAPONS = new List<WEAPON>();

        for (int i = initIndex; i < _fileLines.Length; i++)
        {
            if (!_fileLines[i].Contains("//"))
                continue;

            List<string>? typeNames = Assembly.GetAssembly(type).GetTypes()
                .Where(ourtype => ourtype.IsSubclassOf(type))
                .Select(type => type.Name)
                .ToList();

            bool isMatchByName = false;

            foreach (string typeName in typeNames)
            {
                if (_fileLines[i].Contains(typeName, StringComparison.OrdinalIgnoreCase))
                {
                    isMatchByName = true;
                    break;
                }
            }

            if (isMatchByName)
            {
                WEAPON weapon = new WEAPON();

                for (int k = ++i; k < _fileLines.Length; k++)
                {
                    if (_fileLines[k].Contains("//"))
                        break;

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

                        isMatchByName = false;

                        foreach (string typeName in typeNames)
                        {
                            if (string.Equals(typeName, skill[1], StringComparison.OrdinalIgnoreCase))
                            {
                                isMatchByName = true;
                                break;
                            }
                        }

                        if (!isMatchByName)
                            continue;

                        weapon.Name = skill[1].ToLower();
                        string value = skill[3].Replace("\"", string.Empty);

                        ushort max;
                        if (string.Equals(skill[2], _max, StringComparison.OrdinalIgnoreCase) && UInt16.TryParse(value, out max))
                        {
                            weapon.Max = max;
                            continue;
                        }

                        float dmg;
                        if (string.Equals(skill[2], _dmg, StringComparison.OrdinalIgnoreCase) && Single.TryParse(value, out dmg))
                            weapon.Dmg = dmg > 0 ? dmg : 0;
                    }
                }

                WEAPONS.Add(weapon);
            }
            else if (_fileLines[i].Contains("=") && i != initIndex)
            {
                break;
            }
        }

        return WEAPONS;
    }

    public List<CHARGE_DISTRIBUTION>? GetChargeDistr(Type type)
    {
        int initIndex = GetIndex(_chargeDistribution, 2);

        if (initIndex == 0)
            return null;

        List<CHARGE_DISTRIBUTION> DISTRS = new List<CHARGE_DISTRIBUTION>();

        for (int i = initIndex; i < _fileLines.Length; i++)
        {
            if (!_fileLines[i].Contains("//"))
                continue;

            if (_fileLines[i].Contains("=") && i != initIndex)
                break;

            for (int k = ++i; k < _fileLines.Length; k++)
            {
                i = k;

                if (_fileLines[k].Contains("//"))
                    break;

                List<string>? typeNames = Assembly.GetAssembly(type).GetTypes()
                    .Where(ourtype => ourtype.IsSubclassOf(type))
                    .Select(type => type.Name)
                    .ToList();

                if (string.IsNullOrEmpty(_fileLines[k]))
                {
                    continue;
                }
                else
                {
                    _fileLines[k] = Regex.Replace(_fileLines[k], @"\s+", "_");
                    string[] skill = _fileLines[k].Split('_');

                    if (skill.Length != _wordsCount - 1)
                        continue;

                    bool isMatchByName = false;

                    foreach (string typeName in typeNames)
                    {
                        if (string.Equals(skill[1], typeName, StringComparison.OrdinalIgnoreCase))
                        {
                            isMatchByName = true;
                            break;
                        }
                    }

                    if (!isMatchByName)
                        continue;

                    CHARGE_DISTRIBUTION distr = new CHARGE_DISTRIBUTION();

                    distr.Name = skill[1].ToLower();
                    string value = skill[2].Replace("\"", string.Empty);

                    ushort quantity;
                    if (UInt16.TryParse(value, out quantity))
                        distr.Quantity = quantity;

                    DISTRS.Add(distr);
                }
            }
        }

        return DISTRS;
    }
}
