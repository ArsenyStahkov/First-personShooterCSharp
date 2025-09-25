using TheGame.Base.Interfaces;
using TheGame.Weapons;

namespace TheGame.Monsters.Zombies;

public sealed class ShotgunZombie : Zombie, IMonster
{
    private const int _fixedDelay = 1000;
    private const string _zombieIsDead = "Zombie with Shotgun is dead";

    public ShotgunZombie()
    {
        _zombieWeapon = new Shotgun() { IsInfiniteAmmo = true };
        _delayBeforeAttack = _fixedDelay + _zombieWeapon.FireRate;
    }

    public ShotgunZombie(ushort health)
    {
        _health = health > 0 ? health : _fixedHealth;
        _zombieWeapon = new Shotgun() { IsInfiniteAmmo = true };
        _delayBeforeAttack = _fixedDelay + _zombieWeapon.FireRate;
    }

    public ShotgunZombie(ushort health, float damage)
    {
        _health = health > 0 ? health : _fixedHealth;
        _zombieWeapon = new Shotgun(damage) { IsInfiniteAmmo = true };
        _delayBeforeAttack = _fixedDelay + _zombieWeapon.FireRate;
    }

    public override void Die()
    {
        _timer.Stop();
        _timer.Dispose();
        Console.WriteLine(_zombieIsDead);
    }
}
