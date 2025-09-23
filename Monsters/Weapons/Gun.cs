using TheGame.Base.Interfaces;

namespace TheGame.Weapons;

public class Gun : Weapon, IWeapon
{
    private const ushort _fixedAmmo = 50;
    private const ushort _fixedMaxAmmo = 200;
    private const float _fixedDamage = 3.0f;
    private const string _shot = "Bang!";

    public override string WeaponName => nameof(Gun);
    public override bool IsInfiniteAmmo { get; set; } = false;
    public override ushort FireRate => 400;

    public Gun()
    {
        _ammo = _fixedAmmo;
        _maxAmmo = _fixedMaxAmmo;
        _damage = _fixedDamage;
        _shootSound = _shot;
    }

    public Gun(float damage)
    {
        _ammo = _fixedAmmo;
        _damage = damage > 0 ? damage : _fixedDamage;
        _shootSound = _shot;
    }

    public Gun(ushort maxAmmo, float damage)
    {
        _ammo = _fixedAmmo;
        _maxAmmo = maxAmmo >= _ammo ? maxAmmo : _ammo;
        _damage = damage > 0 ? damage : _fixedDamage;
        _shootSound = _shot;
    }
}
