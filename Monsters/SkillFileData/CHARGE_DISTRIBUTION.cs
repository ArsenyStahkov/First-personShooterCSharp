using TheGame.Base.Interfaces;

namespace TheGame.SkillFileData;

public struct CHARGE_DISTRIBUTION : ISkillFileData
{
    public string Name { get; set; }
    public ushort Quantity { get; set; }
}
