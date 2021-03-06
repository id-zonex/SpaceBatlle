using System;
using System.Threading;

namespace SpaceBatlle
{
    struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        public static Vector2 Scale;

        private static int _datafullWigith = 50;
        private static int _datafullHeigith = 20;

        private static char[,] map;

        private static Player _player;

        static void Main(string[] args)
        {  
            Init(args);
        }


        public static bool CheckColision(int x, int y)
        {
            switch (map[x, y])
            {
                case '#':
                    return false;

                default:
                    return true;
            }
        }


        private static void Init(string[] args)
        {
            Scale = new Vector2(_datafullWigith, _datafullHeigith);

            _player = new Player(new Vector2(Scale.x / 2, Scale.y - 5), new Vector2(3, 3));

            Console.CursorVisible = false;
            map = GenerateMap(Scale.x, Scale.y);

            Console.Clear();
            WriteMap();

            while (true)
            {
                Spawner.Spawn();

                _player.Controller();

                Write();
                Thread.Sleep(20);
            }
        }

        private static char[,] GenerateMap(int wigth, int heigth)
        {
            char[,] mapResult = new char[wigth, heigth];

            for (int x = 0; x < mapResult.GetLength(0); x++)
            {
                for (int y = 0; y < mapResult.GetLength(1); y++)
                {
                    if ((x == 0 || y == 0) || (x == wigth - 1 || y == heigth - 1))
                    {
                        mapResult[x, y] = '#';
                    }
                }
            }

            return mapResult;
        }

        private static void Write()
        {
            _player.gun.WriteBullets();
            Spawner.Controle();
        }

        private static void WriteMap()
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == '#')
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(map[x, y]);
                    }
                }
            }
        }

        private static Vector2 GetMapScale(string[] data)
        {
            Vector2 result = new Vector2(_datafullWigith, _datafullHeigith);

            return result;
        }


    }

    //Vector2 result = new Vector2();
    //try
    //{
    //    result.x = data[0] != null ? result.x = int.Parse(data[0]) : _datafullWigith;
    //    result.y = data[1] != null ? result.y = int.Parse(data[1]) : _datafullHeigith;
    //}
    //catch(Exception)
    //{
    //    result.x = _datafullWigith;
    //    result.y = _datafullHeigith;
    //}

    //return result;
}
