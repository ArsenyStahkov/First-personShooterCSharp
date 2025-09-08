using TheGame.Monsters;
using TheGame.Monsters.Zombies;
using TheGame.Player;

namespace TheGame
{
    class MainGame
    {
        private const int _healthValueX = 30;
        private const int _armorValueX = 40;
        private const int _valueY = 0;
        private const int _valueZero = 0;

        private PlayerClass _player;

        public MainGame()
        {
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
            Task task1 = Task.Factory.StartNew(() => CreateMonster(new GunZombie()));
            //Task task2 = Task.Factory.StartNew(() => CreateMonster(new ShotgunZombie()));
            Task task3 = Task.Factory.StartNew(() => CreateMonster(new Imp()));
            //Task task4 = Task.Factory.StartNew(() => CreateMonster(new Demon()));

            Task.WaitAll(
                task1,
                //task2,
                task3
                //task4
            );

            while (true)
                _player.PressKey();
        }
    }
}
