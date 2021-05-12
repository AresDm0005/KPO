using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ThreadWar
{
    class Program
    {
        #region externals
        
        // Для объявления конца игры
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;

            public COORD(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool ReadConsoleOutputCharacter(IntPtr hConsoleOutput, [Out] StringBuilder lpCharacter,
            uint nLength, COORD dwReadCoord, out uint lpNumberOfCharsRead);
        #endregion

        public const int STD_OUTPUT_HANDLE = -11;

        // Объекты синхронизации
        private static Thread mainThread;                           // Основной поток генерации врагов
        private static Mutex screenlock;                            // Изменением экрана занимается только один поток
        private static Semaphore bulletSemaphore;                   // Можно выстрелить только N раз подряд
        private static EventWaitHandle startEvent;                  // Игра начинается с нажатием клавиши "влево" или "вправо"
        private static IntPtr OutputConsoleHandle;                  // Дескриптор выхода консоли
        private static object gameover = new object();              // Критическая секция

        private static int height = 30;
        private static int width = 100;

        private static int _oX, _oY;

        private static bool end = false;
        private static long hit = 0;
        private static long miss = 0;
        private static char[] badChar = { '-', '\\', '|', '/' };

        private static Random rand = new Random();

        public static int Random(int n0, int n1)
        {
            if (n0 == 0 && n1 == 1)
                return rand.Next(2);

            int r = rand.Next(n0, n1);
            return r;
        }

        public static void WriteAt(int x, int y, char c)
        {
            screenlock.WaitOne();
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            screenlock.ReleaseMutex();
        }

        public static char GetAt(int x, int y)
        {
            StringBuilder chr = new StringBuilder(1);
            uint res;
            COORD coord = new COORD { X = (short)x, Y = (short)y };

            screenlock.WaitOne();
            ReadConsoleOutputCharacter(OutputConsoleHandle, chr, 1, coord, out res);
            screenlock.ReleaseMutex();

            return chr.ToString()[0];
        }

        public static void Score()
        {
            string text = $"Война потоков - Врагов подбито: {hit}, Врагов пропущено: {miss}";
            Console.Title = text;

            if (miss >= 10)
            {
                lock(gameover)
                {
                    mainThread.Abort();
                    end = true;
                    MessageBox(IntPtr.Zero, $"Игра окончена!\n Врагов подбито: {hit}, Врагов пропущено: {miss}", "Война потоков", 0);
                }
            }
        }

        public static void BadGuy()
        {
            int y = Random(1, 10);
            int x = y % 2 == 1 ? 0 : width;
            int dir = x == 0 ? 1 : -1;
            bool hitme = false;

            while (!end && 
                ((dir == 1 && x != width) || (dir == -1 && x != 0)))
            {   
                WriteAt(x, y, badChar[x % 4]);

                for(int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    if (GetAt(x, y) == '*')
                    {
                        hitme = true;
                        Console.Beep();
                        break;
                    }
                }
                WriteAt(x, y, ' ');

                if (hitme)
                {
                    Interlocked.Increment(ref hit);
                    Score();
                    return;
                }

                x += dir;
            }

            if (!end)
            {
                Interlocked.Increment(ref miss);
                Score();
            }
        }

        public static void BadGuys()
        {
            startEvent.WaitOne(15000);

            while (!end)
            {
                if (Random(0, 100) < (hit + miss) / 25 + 20) 
                {
                    Thread newEnemy = new Thread(BadGuy);
                    newEnemy.Start();
                }
                Thread.Sleep(800);
            }
        }

        public static void Bullet()
        {
            bulletSemaphore.WaitOne();

            int x = _oX, y = _oY;

            if (GetAt(x, y) == '*')
                return;

            while (--y > -1 && !end)
            {
                WriteAt(x, y, '*');
                Thread.Sleep(160);
                WriteAt(x, y, ' ');                
            }

            bulletSemaphore.Release();
        }

        static void Main(string[] args)
        {
            screenlock = new Mutex();
            bulletSemaphore = new Semaphore(4, 4);
            startEvent = new EventWaitHandle(false, EventResetMode.ManualReset);
            OutputConsoleHandle = GetStdHandle(STD_OUTPUT_HANDLE);

            Console.SetWindowSize(width + 1, height + 1);
            Console.CursorVisible = false;
            Console.BufferHeight = height + 1;
            Console.BufferWidth = width + 1;

            end = false;
            miss = 0;
            hit = 0;

            int x = width / 2;
            int y = height;

            mainThread = new Thread(BadGuys);
            mainThread.Start();

            Score();

            while (!end)
            {
                WriteAt(x, y, '|');                
                switch (Console.ReadKey(true).Key)
                {
                    case (ConsoleKey.Spacebar):
                        startEvent.Set();
                        _oX = x;
                        _oY = y - 1;
                        Thread newBull = new Thread(Bullet);
                        newBull.Start();
                        break;

                    case (ConsoleKey.LeftArrow):
                        if (x - 1 >= 2) 
                        {
                            startEvent.Set();
                            WriteAt(x, y, ' ');
                            x--;
                        }
                        break;
                    case (ConsoleKey.RightArrow):
                        if (x + 1 <= width - 2)
                        {
                            startEvent.Set();
                            WriteAt(x, y, ' ');
                            x++;
                        }
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
