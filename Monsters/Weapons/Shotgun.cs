using TheGame.Base.Interfaces;

namespace TheGame.Weapons;

public class Shotgun : Weapon, IWeapon
{
    private const string _shot = "Ba-Bang! (reload)";

    public override string WeaponName => nameof(Shotgun);
    public override bool IsInfiniteAmmo { get; set; } = false;
    public override ushort FireRate => 900;

    public Shotgun()
    {
        _ammo = 10;
        _maxAmmo = 50;
        _damage = 12.0f;
        _shootSound = _shot;
    }

    public Shotgun(ushort maxAmmo, float damage)
    {
        _ammo = 10;
        _maxAmmo = maxAmmo >= _ammo ? maxAmmo : _ammo;
        _damage = 12.0f;
        _shootSound = _shot;
    }
}
