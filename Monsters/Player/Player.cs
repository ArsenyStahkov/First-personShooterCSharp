using System.Diagnostics;
using TheGame.Base.Interfaces;
using TheGame.Weapons;

namespace TheGame.Player;

public class PlayerClass : IPlayer
{
    private const string _playerIsDead = "YOU ARE DEAD";

    private List<Weapon> _weapons;
    private Weapon _activeWeapon;

    public short Health { get; set; }
    public short Armor { get; set; }
    public float Damage { get; set; }

    public PlayerClass()
    {
        _weapons = new List<Weapon>() { new Fist(), new Gun() };
        _activeWeapon = _weapons[1];
        Health = 100;
        Armor = 0;
        Damage = 0.0f;
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
        Damage = _activeWeapon.Shoot();

        if (Damage <= 0.0f)
            ChangeActiveWeapon(0);
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
