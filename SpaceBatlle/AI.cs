using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBatlle
{
    public interface ISpawnable
    {
        void Spawn();
        void ControleAllEnemies();
    }

    class AIControlerBase : ISpawnable
    {
        public List<Enemy> Enemies = new List<Enemy>();

        public List<Vector2> SpawnPoints = new List<Vector2>() 
        { 
            new Vector2(5, 5), new Vector2(10, 5), new Vector2(15, 5), new Vector2(20, 5), new Vector2(25, 5),
            new Vector2(5, 10), new Vector2(10, 10), new Vector2(15, 10), new Vector2(20, 10), new Vector2(25, 10),
            new Vector2(5, 15), new Vector2(10, 15), new Vector2(15, 15), new Vector2(20, 15), new Vector2(25, 15),
        };                

        public int count = 0;

        private int _enemyCount =  15; 

        public void Spawn()
        {
            for (int count = 0; count < _enemyCount; count++)
            {

                Enemy enemy = new Enemy(1, SpawnPoints[count], new Vector2(3, 3));
                Enemies.Add(enemy);
            }

        }

        public void ControleAllEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemy enemy = Enemies[i];

                if ((int)DateTime.Now.Subtract(new DateTime(2020, 1, 1)).TotalSeconds - enemy.StartTime > 3)
                {
                    enemy.Controller();
                }
            }
        }
    }
}
