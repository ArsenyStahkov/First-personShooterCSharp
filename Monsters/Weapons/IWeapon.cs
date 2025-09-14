namespace TheGame.Weapons
{
    interface IWeapon
    {
        abstract string WeaponName { get; }
        abstract bool IsInfiniteAmmo { get; set; }
        abstract ushort FireRate { get; }
        abstract float Shoot();
    }
}
