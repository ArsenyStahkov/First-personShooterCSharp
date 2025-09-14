using TheGame.Monsters;
using TheGame.Monsters.Zombies;

namespace TheGame.SkillFileData;

public class SkillData
{
    private const string _fileName = "skill.cfg";
    private const string _npcs = "NPCs";
    private const string _weapons = "WEAPONS";
    private const string _chargeDistribution = "HEALTH/ARMOR CHARGE DISTRIBUTION";

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

    //public List<NPC>? GetNpcs()
    //{
    //    if (_fileLines.Length < 2)
    //        return null;

    //    int npcsIndex = 0;

    //    for (int i = 0; i < _fileLines.Length; i++)
    //    {
    //        if (_fileLines[i].Contains(_npcs, StringComparison.OrdinalIgnoreCase))
    //        {
    //            npcsIndex = i;
    //            break;
    //        }
    //    }

    //    if (npcsIndex == 0)
    //        return null;

    //    for (int i = npcsIndex + 1; i < _fileLines.Length; i++)
    //    {
    //        if (_fileLines[i].Contains("//"))
    //        {
    //            if (_fileLines[i].Contains(nameof(Zombie), StringComparison.OrdinalIgnoreCase)
    //                || _fileLines[i].Contains(nameof(Imp), StringComparison.OrdinalIgnoreCase)
    //                || _fileLines[i].Contains(nameof(Demon), StringComparison.OrdinalIgnoreCase)
    //                )
    //            {

    //            }
    //        }
    //    }

    //    //List<NPC> NPCs = new List<NPC>();

    //    //return NPCs;
    //}
}
