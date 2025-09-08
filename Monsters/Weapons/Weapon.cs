namespace TheGame.Weapons;

abstract public class Weapon : IWeapon
{
    protected const string _noAmmo = "No ammo";
    protected float _damage;
    protected string _shootSound;

    public abstract string WeaponName { get; }
    public abstract ushort Ammo { get; set; }
    public abstract ushort MaxAmmo { get; }
    public abstract bool IsInfiniteAmmo { get; set; }
    public abstract ushort FireRate { get; }

    public virtual float Shoot()
    {
        if (Ammo > 0)
        {
            if (!IsInfiniteAmmo)
            {
                Ammo -= 1;
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
