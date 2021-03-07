using System;
using System.Collections.Generic;


namespace SpaceBatlle
{
    static class Spawner
    {
        public static List<Enemy> Enemies = new List<Enemy>();

        private static Vector2 _minSpawnPoint = new Vector2(3, 5);
        private static Vector2 _maxSpawnPoint = new Vector2(47, 5);

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

        public static void WriteAllEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemy enemy = Enemies[i];

                enemy.Controller();
                enemy.Write();
            }
        }

        private static Vector2 SelectRandomPos()
        {
            var Xpos = new Random().Next(_minSpawnPoint.x, _maxSpawnPoint.x);
            var Ypos = new Random().Next(_minSpawnPoint.y, _maxSpawnPoint.y);

            return new Vector2(Xpos, Ypos);
        }

    }
}
