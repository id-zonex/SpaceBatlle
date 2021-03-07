using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SpaceBatlle
{

    class Character: Transform
    {

        public char[,] Sprite = new char[,]
{
            { '■', '■', '■' },
            { '■', '■', '■' },
            { '■', '■', '■' },
        };

        public Character(Vector2 position, Vector2 scale)
        {
            this.position = position;
            this.scale = scale;
        }

        public virtual void Move(Vector2 nextPos)
        {
            int testPosX = position.x + nextPos.x;
            int testPosY = position.y + nextPos.y;

            if (Program.CheckColision(testPosX, testPosY) && Program.CheckColision(testPosX + 2, testPosY))
            {
                position.x = testPosX;
                position.y = testPosY;
            }
        }

        public virtual void Controller()
        {

        }

        public virtual void Write()
        {
            for (int y = 0; y < Sprite.GetLength(1); y++)
            {
                for (int x = 0; x < Sprite.GetLength(0); x++)
                {
                    Console.SetCursorPosition(x + position.x, y + position.y);
                    Console.Write(Sprite[x, y]);
                }
            }
        }

        public void DelOldCharacter(Vector2 oldPos)
        {
            for (int y = 0; y < Sprite.GetLength(1); y++)
            {
                for (int x = 0; x < Sprite.GetLength(0); x++)
                {
                    Console.SetCursorPosition(x + oldPos.x, y + oldPos.y);
                    Console.Write(" ");
                }
            }
        }
    }

   
    class Player : Character
    {
        public List<Bullet> Bullets = new List<Bullet>();
        public Gun gun = new Gun();


        public Player(Vector2 position, Vector2 scale) : base(position, scale)
        {
            Sprite = new char[,]
            {
                { 'I', 'I', '■' },
                { '@', '█', ' ' },
                { 'I', 'I', '■' },
            };
        }

        public void MoveAndWrite(Vector2 nextPos)
        {
            Vector2 oldPos = position;

            base.Move(nextPos);
            DelOldCharacter(oldPos);
            Write();

        }

        public override void Controller()
        {
            if(Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        MoveAndWrite(new Vector2(-1, 0));
                        break;
                    case ConsoleKey.D:
                        MoveAndWrite(new Vector2(1, 0));
                        break;
                    case ConsoleKey.Spacebar:
                        gun.Shot(position);
                        break;
                }
            }
        }

        public override void Write()
        {

            base.Write();

            gun.WriteBullets();

        }
    }
}
