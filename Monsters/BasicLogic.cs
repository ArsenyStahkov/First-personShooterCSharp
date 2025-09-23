using TheGame.Items;
using TheGame.Monsters;
using TheGame.Monsters.Zombies;
using TheGame.Player;
using TheGame.SkillFileData;
using TheGame.Weapons;

namespace TheGame
{
    class BasicLogic
    {
        private const int _healthValueX = 30;
        private const int _armorValueX = 40;
        private const int _valueY = 0;
        private const int _valueZero = 0;

        private SkillData _skillData;
        private PlayerClass _player;

        private List<WEAPON>? _WEAPONS = null;
        private List<NPC>? _NPCs = null;
        private List<CHARGE_DISTRIBUTION>? _DISTRS = null;

        public BasicLogic()
        {
            _skillData = new SkillData();
            _WEAPONS = _skillData.GetWeapons(typeof(Weapon));
            _NPCs = _skillData.GetNpcs(typeof(Monster));
            _DISTRS = _skillData.GetChargeDistr(typeof(Item));

            if (_WEAPONS is not null && _WEAPONS.Count > 0)
                _player = new PlayerClass(_WEAPONS);
            else
                _player = new PlayerClass();

            WriteValueOnScreen(_healthValueX, _valueY, _player.Health, ConsoleColor.Green);
            WriteValueOnScreen(_armorValueX, _valueY, _player.Armor, ConsoleColor.DarkBlue);
            Console.WriteLine();
        }

        private void WriteValueOnScreen(int x, int y, short value, ConsoleColor color)
        {
            int currentX = Console.CursorLeft;
            int currentY = Console.CursorTop;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write("  " + value + " ");
            Console.SetCursorPosition(currentX, currentY);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void CreateMonster(Monster monster)
        {
            monster.MonsterAttacked += TakeHealth;
            //monster.Die();
        }

        private void TakeHealth(float damage)
        {
            if (_player.Armor > 0)
            {
                _player.Health = (short)((short)Math.Round(Convert.ToSingle(_player.Health) - damage) / 2);

                if (_player.Health <= 0)
                {
                    WriteValueOnScreen(_healthValueX, _valueY, _valueZero, ConsoleColor.Red);
                    WriteValueOnScreen(_armorValueX, _valueY, _valueZero, ConsoleColor.Blue);
                    _player.Die();

                    return;
                }
                else
                {
                    if (_player.Health <= 60)
                    {
                        WriteValueOnScreen(_healthValueX, _valueY, _player.Health, ConsoleColor.DarkYellow);
                    }
                    else
                    {
                        WriteValueOnScreen(_healthValueX, _valueY, _player.Health, ConsoleColor.Green);
                    }
                }

                _player.Armor = (short)Math.Round(Convert.ToSingle(_player.Armor) - damage);

                if (_player.Armor <= 0)
                {
                    WriteValueOnScreen(_armorValueX, _valueY, _valueZero, ConsoleColor.DarkBlue);
                }
                else
                {
                    WriteValueOnScreen(_armorValueX, _valueY, _player.Armor, ConsoleColor.Blue);
                }
            }
            else
            {
                _player.Health = (short)Math.Round(Convert.ToSingle(_player.Health) - damage);

                if (_player.Health <= 0)
                {
                    WriteValueOnScreen(_healthValueX, _valueY, _valueZero, ConsoleColor.Red);
                    _player.Die();

                    return;
                }
                else
                {
                    if (_player.Health <= 60)
                    {
                        WriteValueOnScreen(_healthValueX, _valueY, _player.Health, ConsoleColor.DarkYellow);
                    }
                    else
                    {
                        WriteValueOnScreen(_healthValueX, _valueY, _player.Health, ConsoleColor.Green);
                    }
                }
            }
        }

        public void StartGame()
        {
            // [0] - fist, [1] - gun, [2] - shotgun
            WEAPON[] WEAPONS = new WEAPON[3];

            foreach (WEAPON weapon in _WEAPONS)
            {
                if (string.Equals(weapon.Name, nameof(Fist), StringComparison.OrdinalIgnoreCase))
                    WEAPONS[0] = weapon;
                if (string.Equals(weapon.Name, nameof(Gun), StringComparison.OrdinalIgnoreCase))
                    WEAPONS[1] = weapon;
                if (string.Equals(weapon.Name, nameof(Shotgun), StringComparison.OrdinalIgnoreCase))
                    WEAPONS[2] = weapon;
            }

            // [0] - zombie, [1] - imp, [2] - demon
            NPC[] NPCs = new NPC[3];

            foreach (NPC npc in _NPCs)
            {
                if (string.Equals(npc.Name, nameof(Zombie), StringComparison.OrdinalIgnoreCase))
                    NPCs[0] = npc;
                if (string.Equals(npc.Name, nameof(Imp), StringComparison.OrdinalIgnoreCase))
                    NPCs[1] = npc;
                if (string.Equals(npc.Name, nameof(Demon), StringComparison.OrdinalIgnoreCase))
                    NPCs[2] = npc;
            }

            // Zombie with Gun
            Task task1;
            if (_NPCs is not null && _WEAPONS.Count > 0)
            {
                if (_WEAPONS is not null && _WEAPONS.Count > 0)
                    task1 = Task.Factory.StartNew(() => CreateMonster(new GunZombie(NPCs[0].Health, WEAPONS[1].Dmg)));
                else
                    task1 = Task.Factory.StartNew(() => CreateMonster(new GunZombie(NPCs[0].Health)));
            }
            else
            {
                task1 = Task.Factory.StartNew(() => CreateMonster(new GunZombie()));
            }

            //// Zombie with Shotgun
            //Task task2;
            //if (_NPCs is not null && _WEAPONS.Count > 0)
            //{
            //    if (_WEAPONS is not null && _WEAPONS.Count > 0)
            //        task2 = Task.Factory.StartNew(() => CreateMonster(new ShotgunZombie(NPCs[0].Health, WEAPONS[2].Dmg)));
            //    else
            //        task2 = Task.Factory.StartNew(() => CreateMonster(new ShotgunZombie(NPCs[0].Health)));
            //}
            //else
            //{
            //    task2 = Task.Factory.StartNew(() => CreateMonster(new ShotgunZombie()));
            //}

            //Imp
            Task task3;
            if (_NPCs is not null)
                task3 = Task.Factory.StartNew(() => CreateMonster(new Imp(NPCs[1].Health, NPCs[1].Dmg)));
            else
                task3 = Task.Factory.StartNew(() => CreateMonster(new Imp()));

            //// Demon
            //Task task4;
            //if (_NPCs is not null)
            //    task4 = Task.Factory.StartNew(() => CreateMonster(new Demon(NPCs[2].Health, NPCs[2].Dmg)));
            //else
            //    task4 = Task.Factory.StartNew(() => CreateMonster(new Demon()));

            //Task.WaitAll(
            //task1,
            ////task2,
            //task3
            ////task4
            //);

            while (true)
                _player.PressKey();
        }
    }
}
