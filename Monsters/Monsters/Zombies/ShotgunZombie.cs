using TheGame.Weapons;

namespace TheGame.Monsters.Zombies;

public sealed class ShotgunZombie : Zombie, IMonster
{
    private const string _zombieIsDead = "Zombie with Shotgun is dead";
    public ShotgunZombie()
    {
        _zombieWeapon = new Shotgun() { IsInfiniteAmmo = true };
        _delayBeforeAttack = 1000 + _zombieWeapon.FireRate;
    }

    public override void Die()
    {
        _timer.Stop();
        _timer.Dispose();
        Console.WriteLine(_zombieIsDead);
    }
}
