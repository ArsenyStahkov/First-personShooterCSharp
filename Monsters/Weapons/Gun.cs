namespace TheGame.Weapons;

class Gun : Weapon, IWeapon
{
    private const string _shot = "Bang!";

    public override string WeaponName => nameof(Gun);
    public override ushort Ammo { get; set; } = 50;
    public override ushort MaxAmmo => 200;
    public override bool IsInfiniteAmmo { get; set; } = false;
    public override ushort FireRate => 400;

    public Gun()
    {
        _damage = 3.0f;
        _shootSound = _shot;
    }
}
