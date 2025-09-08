namespace TheGame.Weapons;

class Fist : Weapon, IWeapon
{
    private const string _punch = "'Punch!'";

    public override string WeaponName => nameof(Fist);
    public override ushort Ammo { get; set; } = 1;
    public override ushort MaxAmmo => 1;
    public override bool IsInfiniteAmmo { get; set; } = true;
    public override ushort FireRate => 600;

    public Fist()
    {
        _damage = 3.0f;
        _shootSound = _punch;
    }

    public override float Shoot()
    {
        Console.WriteLine(_shootSound);
        return _damage;
    }
}
