using System;
using System.Collections.Generic;


namespace SpaceBatlle
{

    class AIControlerBase
    {
        public bool IsEnd = false;
        public bool IsSpawned = false;

        public event Spawner.EndDelegate EndEvent;

        public List<Enemy> Enemies = new List<Enemy>();

        public List<Vector2> SpawnPoints = new List<Vector2>() 
        { 
            new Vector2(5, 3), new Vector2(10, 3), new Vector2(15, 3), new Vector2(20, 3), new Vector2(25, 3),
            new Vector2(5, 7), new Vector2(10, 7), new Vector2(15, 7), new Vector2(20, 7), new Vector2(25, 7),
            new Vector2(5, 11), new Vector2(10, 11), new Vector2(15, 11), new Vector2(20, 11), new Vector2(25, 11),
        };                

        public int count = 0;

        private int _enemyCount =  15; 


        public void Spawn()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                Enemy enemy = new Enemy(1, SpawnPoints[i], new Vector2(3, 3));
                Enemies.Add(enemy);
            }

            IsSpawned = true;

        }

        public void ControleAllEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemy enemy = Enemies[i];

                if ((int)DateTime.Now.Subtract(new DateTime(2020, 1, 1)).TotalSeconds - enemy.StartTime > 2)
                {
                    enemy.Controller();
                }
            }

            if (Enemies.Count <= 0)
            {
                IsEnd = true;
                if (EndEvent != null)
                {
                    EndEvent.Invoke();
                }
                EndEvent -= Spawn;
               
            }
        }
    }
}
