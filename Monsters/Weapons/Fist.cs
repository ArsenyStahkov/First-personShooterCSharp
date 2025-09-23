using TheGame.Base.Interfaces;

namespace TheGame.Weapons;

public class Fist : Weapon, IWeapon
{
    private const string _punch = "'Punch!'";

    public override string WeaponName => nameof(Fist);
    public override bool IsInfiniteAmmo { get; set; } = true;
    public override ushort FireRate => 600;

    public Fist()
    {
        _ammo = 1;
        _maxAmmo = 1;
        _damage = 3.0f;
        _shootSound = _punch;
    }

    public Fist(float damage)
    {
        _ammo = 1;
        _maxAmmo = 1;
        _damage = damage;
        _shootSound = _punch;
    }

    public override float Shoot()
    {
        Console.WriteLine(_shootSound);
        return _damage;
    }
}
