namespace TheGame.Weapons
{
    interface IWeapon
    {
        abstract string WeaponName { get; }
        abstract ushort Ammo { get; set; }
        abstract ushort MaxAmmo { get; }
        abstract bool IsInfiniteAmmo { get; set; }
        abstract ushort FireRate { get; }
        abstract float Shoot();
    }
}
