using System.Diagnostics;
using TheGame.Base.Interfaces;
using TheGame.SkillFileData;
using TheGame.Weapons;

namespace TheGame.Player;

public class PlayerClass : IPlayer
{
    private const string _playerIsDead = "YOU ARE DEAD";
    private const short _fixedHealth = 100;
    private const short _fixedArmor = 0;
    private const float _fixedDamage = 0.0f;

    private List<Weapon> _weapons;
    private Weapon _activeWeapon;

    public short Health { get; set; }
    public short Armor { get; set; }
    public float Damage { get; set; }

    public PlayerClass()
    {
        _weapons = new List<Weapon>() { new Fist(), new Gun() };
        _activeWeapon = _weapons[1];
        Health = _fixedHealth;
        Armor = _fixedArmor;
        Damage = _fixedDamage;
    }

    public PlayerClass(List<WEAPON> weapons)
    {
        WEAPON fist = new WEAPON();
        WEAPON gun = new WEAPON();

        foreach (WEAPON weapon in weapons)
        {
            if (string.Equals(weapon.Name, nameof(fist), StringComparison.OrdinalIgnoreCase))
                fist = weapon;
            if (string.Equals(weapon.Name, nameof(gun), StringComparison.OrdinalIgnoreCase))
                gun = weapon;
        }

        _weapons = new List<Weapon>() { new Fist(fist.Dmg), new Gun(gun.Max, gun.Dmg) };

        _activeWeapon = _weapons[1];
        Health = _fixedHealth;
        Armor = _fixedArmor;
        Damage = _fixedDamage;
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
