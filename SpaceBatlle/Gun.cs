using System;
using System.Collections.Generic;


namespace SpaceBatlle
{
    class Bullet: Transform
    {
        public BoxColider colider;

        public Gun parent;

        public int BulletSpeed;
        private char _bulletSprite;

        public Bullet(Vector2 position, Gun parent, int BulletSpeed)
        {
            this._bulletSprite = '█';
            this.colider = new BoxColider(0, 0, 1, 1, this);

            this.position = position;

            this.parent = parent;
            this.BulletSpeed = BulletSpeed;
        }

        public Bullet(Vector2 position, Gun parent, int BulletSpeed, char bulletSprite)
        {
            colider = new BoxColider(0, 0, 1, 1, this);

            this.position = position;

            this.parent = parent;
            this.BulletSpeed = BulletSpeed;
            this._bulletSprite = bulletSprite;

        }


        public void MoveAndWrite()
        {
            Vector2 oldPos = position;

            int testYPos = position.y + BulletSpeed;

            DelOldBulletSprite(oldPos);

            if (Program.CheckColision(position.x, testYPos))
            {
                CheckColision();
                position.y = testYPos;

                Console.SetCursorPosition(position.x, position.y);
                Console.Write(_bulletSprite);
            }
            else
            {
                Destroy();
            }
        }

        private void DelOldBulletSprite(Vector2 oldPos)
        {
            Console.SetCursorPosition(oldPos.x, oldPos.y);
            Console.Write(" ");
        }

        private void CheckColision()
        {
            for (int i = 0; i < Spawner.Enemies.Count; i++)
            {
                Enemy enemy = Spawner.Enemies[i];

                 if (colider.Intersect(enemy))
                 {
                    enemy.Destroy();
                    Destroy();
                 }
            }
        }

        public void Destroy()
        {
            DelOldBulletSprite(position);
            parent.Bullets.Remove(this);
        }

    }

    class Gun
    {
        public int Damage;
        public List<Bullet> Bullets = new List<Bullet>();


        public void Shot(object shotPositionObj)
        {
            Vector2 shotPosition = (Vector2)shotPositionObj;

            Bullet bullet = new Bullet(new Vector2(shotPosition.x + 1, shotPosition.y), this, -1);

            Bullets.Add(bullet);
        }

        public void WriteBullets()
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                var b = Bullets[i];
                b.MoveAndWrite();
            }
        }
    }
}
