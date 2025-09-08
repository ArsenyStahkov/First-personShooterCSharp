namespace TheGame.Weapons;

class Shotgun : Weapon, IWeapon
{
    private const string _shot = "Ba-Bang! (reload)";

    public override string WeaponName => nameof(Shotgun);
    public override ushort Ammo { get; set; } = 10;
    public override ushort MaxAmmo => 50;
    public override bool IsInfiniteAmmo { get; set; } = false;
    public override ushort FireRate => 900;

    public Shotgun()
    {
        _damage = 12.0f;
        _shootSound = _shot;
    }
}
