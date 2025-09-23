using TheGame.Base.Interfaces;

namespace TheGame.Weapons;

public class Shotgun : Weapon, IWeapon
{
    private const ushort _fixedAmmo = 10;
    private const ushort _fixedMaxAmmo = 50;
    private const float _fixedDamage = 12.0f;
    private const string _shot = "Ba-Bang! (reload)";

    public override string WeaponName => nameof(Shotgun);
    public override bool IsInfiniteAmmo { get; set; } = false;
    public override ushort FireRate => 900;

    public Shotgun()
    {
        _ammo = _fixedAmmo;
        _maxAmmo = _fixedMaxAmmo;
        _damage = _fixedDamage;
        _shootSound = _shot;
    }

    public Shotgun(float damage)
    {
        _ammo = _fixedAmmo;
        _damage = damage > 0 ? damage : _fixedDamage;
        _shootSound = _shot;
    }

    public Shotgun(ushort maxAmmo, float damage)
    {
        _ammo = _fixedAmmo;
        _maxAmmo = maxAmmo >= _ammo ? maxAmmo : _ammo;
        _damage = damage > 0 ? damage : _fixedDamage;
        _shootSound = _shot;
    }
}
