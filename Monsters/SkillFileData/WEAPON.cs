using TheGame.Base.Interfaces;

namespace TheGame.SkillFileData;

public struct WEAPON : ISkillFileData
{
    public string Name { get; set; }
    public ushort Max { get; set; }
    public float Dmg { get; set; }
}
