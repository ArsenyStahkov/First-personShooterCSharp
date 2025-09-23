using TheGame.Base.Interfaces;

namespace TheGame.SkillFileData;

public struct NPC : ISkillFileData
{
    public string Name { get; set; }
    public ushort Health { get; set; }
    public float Dmg { get; set; }
}
