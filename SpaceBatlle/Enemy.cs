using System;
using System.Collections.Generic;


namespace SpaceBatlle
{

    class Enemy : Character
    { 
        public BoxColider colider;

        public int StartTime;

        public Vector2 SpawnPoint;

        private int _speed;

        private Vector2 _oldPos;


        public Enemy(int speed, Vector2 position, Vector2 scale) : base(position, scale)
        {
            StartTime = (int)DateTime.Now.Subtract(new DateTime(2021, 1, 1)).TotalSeconds;

            colider = new BoxColider(0, 0, 3, 3, this);
            this._speed = speed;

            Sprite = new char[,]
            {
                { '■', 'I', 'I' },
                { ' ', '█', '@' },
                { '■', 'I', 'I' },
            };

        }



        public override void Controller()
        {
            _oldPos = position;

            DelOldCharacter(_oldPos);

            Move(new Vector2(0, _speed));
            Write();

            StartTime = (int)DateTime.Now.Subtract(new DateTime(2020, 1, 1)).TotalSeconds;

        }

        public override void Move(Vector2 nextPos)
        {
            int testPosX = position.x + nextPos.x;
            int testPosY = position.y + nextPos.y;

            if (Program.CheckColision(testPosX, testPosY) && Program.CheckColision(testPosX + 2, testPosY))
            {
                position.x = testPosX;
                position.y = testPosY;
            }

            if (position.y > Program.Scale.y)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            DelOldCharacter(position);
            Spawner.Enemies.Remove(this);
        }

    }
}
