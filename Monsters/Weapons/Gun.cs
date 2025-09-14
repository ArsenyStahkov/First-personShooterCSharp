namespace TheGame.Weapons;

public class Gun : Weapon, IWeapon
{
    private const string _shot = "Bang!";

    public override string WeaponName => nameof(Gun);
    public override bool IsInfiniteAmmo { get; set; } = false;
    public override ushort FireRate => 400;

    public Gun()
    {
        _ammo = 50;
        _maxAmmo = 200;
        _damage = 3.0f;
        _shootSound = _shot;
    }

    public Gun(ushort maxAmmo, float damage)
    {
        _ammo = 50;
        _maxAmmo = maxAmmo >= _ammo ? maxAmmo : _ammo;
        _damage = damage;
        _shootSound = _shot;
    }
}
