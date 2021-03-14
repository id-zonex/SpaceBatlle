using System;
using System.Collections.Generic;


namespace SpaceBatlle
{
    static class Spawner
    {
        public static List<Enemy> Enemies = new List<Enemy>();

        private static Vector2 _minSpawnPoint = new Vector2(3, 5);
        private static Vector2 _maxSpawnPoint = new Vector2(Program.Scale.x - 5, 5);

        private static List<ISpawnable> _spawnables = new List<ISpawnable>(10);

        private static ISpawnable[] PossibleOptionsScripts = new ISpawnable[] { new AIControlerBase(), };

        private static int count = 0;

        public static void Spawn()
        {
            if(count < 10)
            {
                Vector2 randPos = SelectRandomPos();

                Enemy enemy = new Enemy(1, randPos, new Vector2(3, 3));
                Enemies.Add(enemy);
                count++;
            }

        }

        public static void ControleAllEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemy enemy = Enemies[i];

                if ((int)DateTime.Now.Subtract(new DateTime(2020, 1, 1)).TotalSeconds - enemy.StartTime > new Random().Next(2, 4))
                {
                    enemy.Controller();
                }
            }
        }

        private static Vector2 SelectRandomPos()
        {
            var Xpos = new Random().Next(_minSpawnPoint.x, _maxSpawnPoint.x);
            var Ypos = new Random().Next(_minSpawnPoint.y, _maxSpawnPoint.y);

            return new Vector2(Xpos, Ypos);
        }

        private static List<ISpawnable> FillInTheList()
        {
            for (int i = 0; i < _spawnables.Count; i++)
            {
                _spawnables[i] = PossibleOptionsScripts[new Random().Next(PossibleOptionsScripts.Length)];
            }

            return _spawnables;
        }

    }
}
