using TheGame.Weapons;
using System.Diagnostics;

namespace TheGame.Player;

public class PlayerClass : IPlayer
{
    private const string _playerIsDead = "YOU ARE DEAD";

    private List<Weapon> _weapons;
    private Weapon _activeWeapon;
    public short Health { get; set; } = 100;
    public short Armor { get; set; } = 0;
    public float Damage { get; set; } = 0.0f;

    public PlayerClass()
    {
        _weapons = new List<Weapon>() { new Fist(), new Gun() };
        _activeWeapon = _weapons[1];
    }

    public void PressKey()
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.D1:
                ChangeActiveWeapon(0);
                break;

            case ConsoleKey.D2:
                ChangeActiveWeapon(1);
                break;

            case ConsoleKey.D3 when _weapons.Count > 2:
                ChangeActiveWeapon(2);
                break;

            case ConsoleKey.Enter:
                Attack();
                break;
        }
    }

    public void Attack()
    {
        if (_activeWeapon.Ammo > 0)
            Damage = _activeWeapon.Shoot();
        else
            ChangeActiveWeapon(0);

        Damage = 0.0f;
    }

    private void ChangeActiveWeapon(int weaponNum)
    {
        if (_activeWeapon != _weapons[weaponNum])
        {
            _activeWeapon = _weapons[weaponNum];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_activeWeapon.WeaponName);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public virtual void Die()
    {
        Console.WriteLine(_playerIsDead);
        Process.GetCurrentProcess().Kill();
    }
}
