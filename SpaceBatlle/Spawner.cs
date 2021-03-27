using System;
using System.Collections.Generic;


namespace SpaceBatlle
{
    static class Spawner
    {
        public delegate void EndDelegate();

        public static List<Enemy> Enemies = new List<Enemy>();

        public static AIControlerBase CurrentSpawner;

        private static Vector2 _minSpawnPoint = new Vector2(3, 5);
        private static Vector2 _maxSpawnPoint = new Vector2(Program.Scale.x - 5, 5);

        private static readonly int _spawnersCount = 2;

        private static List<AIControlerBase> _spawnables = new List<AIControlerBase>(_spawnersCount);

        private static AIControlerBase[] _possibleOptionsScripts = new AIControlerBase[] { new AIControlerBase(), };

        private static int  _currentSpawnerIndex = 0;


        public static void Spawn()
        {
            _spawnables = FillInTheList();
        }

        public static void Controle()
        {
            CurrentSpawner = _spawnables[_currentSpawnerIndex];

            if(CurrentSpawner.IsSpawned)
            {
                CurrentSpawner.ControleAllEnemies();
            }
            else
            {
                CurrentSpawner.Spawn();
                TryAddNewListener();
            }
          
        }

        private static Vector2 SelectRandomPos()
        {
            var Xpos = new Random().Next(_minSpawnPoint.x, _maxSpawnPoint.x);
            var Ypos = new Random().Next(_minSpawnPoint.y, _maxSpawnPoint.y);

            return new Vector2(Xpos, Ypos);
        }

        private static List<AIControlerBase> FillInTheList()
        {
            for (int i = 0; i < 10; i++)
            {
                _spawnables.Add(_possibleOptionsScripts[new Random().Next(_possibleOptionsScripts.Length)]);
            }

            return _spawnables;
        }

        private static void TryAddNewListener()
        {
            if(!(_currentSpawnerIndex++ >= _spawnersCount))
            {
                CurrentSpawner.EndEvent += new EndDelegate(_spawnables[_currentSpawnerIndex++].Spawn);
            }
            else
            {
                Environment.Exit(0);
            }
        }

    }
}
