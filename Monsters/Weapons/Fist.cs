using TheGame.Base.Interfaces;

namespace TheGame.Weapons;

public class Fist : Weapon, IWeapon
{
    private const ushort _fixedAmmo = 1;
    private const ushort _fixedMaxAmmo = 1;
    private const float _fixedDamage = 3.0f;
    private const string _punch = "'Punch!'";

    public override string WeaponName => nameof(Fist);
    public override bool IsInfiniteAmmo { get; set; } = true;
    public override ushort FireRate => 600;

    public Fist()
    {
        _ammo = _fixedAmmo;
        _maxAmmo = _fixedMaxAmmo;
        _damage = _fixedDamage;
        _shootSound = _punch;
    }

    public Fist(float damage)
    {
        _ammo = _fixedAmmo;
        _maxAmmo = _fixedMaxAmmo;
        _damage = damage > 0 ? damage : _fixedDamage;
        _shootSound = _punch;
    }

    public override float Shoot()
    {
        Console.WriteLine(_shootSound);
        return _damage;
    }
}
