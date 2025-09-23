using TheGame.Base.Interfaces;

namespace TheGame.Weapons;

abstract public class Weapon : IWeapon
{
    protected const string _noAmmo = "No ammo";

    protected ushort _ammo;
    protected ushort _maxAmmo;
    protected float _damage;
    protected string _shootSound = string.Empty;

    public abstract string WeaponName { get; }
    public abstract bool IsInfiniteAmmo { get; set; }
    public abstract ushort FireRate { get; }

    public virtual float Shoot()
    {
        if (_ammo > 0)
        {
            if (!IsInfiniteAmmo)
            {
                _ammo -= 1;
            }

            Console.WriteLine(_shootSound);
            return _damage;
        }
        else
        {
            Console.WriteLine(_noAmmo);
            return 0.0f;
        }
    }
}
