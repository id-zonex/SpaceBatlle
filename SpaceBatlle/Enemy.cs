using System;
using System.Collections.Generic;


namespace SpaceBatlle
{

    class Enemy : Character
    { 
        public BoxColider colider;

        private int speed;

        private Vector2 oldPos;

        public Enemy(int speed, Vector2 position, Vector2 scale) : base(position, scale)
        {
            colider = new BoxColider(0, 0, 3, 3, this);
            this.speed = speed;

            Sprite = new char[,]
            {
                { '■', 'I', 'I' },
                { ' ', '█', '@' },
                { '■', 'I', 'I' },
            };

        }


        public override void Controller()
        {
            if (new Random().Next(100) > 90)
            {
                oldPos = position;

                DelOldCharacter(oldPos);

                Move(new Vector2(0, speed));
                Write();
            }
           
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

            if (position.y == 18)
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
