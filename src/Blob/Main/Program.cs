using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blob
{
    class Program
    {
        private readonly Random _random = new Random();

        private static Renderer s_renderer;
        private static AnimationManager s_animationManager;

        private static bool s_run;

        static void Main(string[] args)
        {
            if(!(args == null || args.Length <= 0) && (args[0].Equals("-info")))
            {
                Info();
            }
            else
            {
                new Program();
            }
        }

        Program()
        {
            Startup();
            Run();
        }

        private void Startup()
        {
            s_renderer = new Renderer();
            s_animationManager = new AnimationManager();

            Console.CursorVisible = false;
            Console.Title = "Blob";

            s_run = true;

            Console.CancelKeyPress += Stop;
        }

        private void Run()
        {
            s_renderer.Start();

            //Default Animation
            Task randomEyeMovement = Task.Run(() => RandomEyeMovementAsync());
            Task randomAntenaMovement = Task.Run(() => AntenaMovementAsync());

            while (s_run)
            {
                s_animationManager.MiddleBlobMouth();
                Thread.Sleep(_random.Next(1, 9) * (_random.Next(1, 4) * 1000));
                switch(_random.Next(1, 3))
                {
                    case 1:
                        HappyMode();
                        break;
                    case 2:
                        MhMode();
                        break;
                }

                if (Console.KeyAvailable)
                {

                }
                
            }
        }

        private void HappyMode()
        {
            int counter = 0;
            s_animationManager.HappyBlobMouth();
            while (counter < 100)
            {
                s_animationManager.BlobAntenaUp();
                Task delayOne = Task.Delay(150);
                delayOne.Wait();
                s_animationManager.BlobAntenaDown();
                Task delayTwo = Task.Delay(150);
                delayTwo.Wait();
                counter++;
            }
        }

        private void MhMode()
        {
            int counter = 0;
            s_animationManager.SmallBlobMouth();
            while (counter < 50)
            {
                s_animationManager.BlobEyesToLeft();
                Task delayOne = Task.Delay(250);
                delayOne.Wait();
                s_animationManager.BlobEyesToRight();
                Task delayTwo = Task.Delay(250);
                delayTwo.Wait();
                counter++;
            }
        }

        private void RandomEyeMovementAsync()
        {
            while (s_run)
            {
                s_animationManager.BlobEyesToLeft();
                Task delayOne = Task.Delay(_random.Next(1, 9) * (_random.Next(1, 9) * 100));
                delayOne.Wait();
                s_animationManager.BlobEyesToRight();
                Task delayTwo = Task.Delay(_random.Next(1, 9) * (_random.Next(1, 9) * 100));
                delayTwo.Wait();
            }
        }

        private void AntenaMovementAsync()
        {
            while (s_run)
            {
                s_animationManager.BlobAntenaUp();
                Task delayOne = Task.Delay(_random.Next(1, 9) * (_random.Next(1, 9) * 100));
                delayOne.Wait();
                s_animationManager.BlobAntenaDown();
                Task delayTwo =  Task.Delay(_random.Next(1, 9) * (_random.Next(1, 9) * 100));
                delayTwo.Wait();
            }
        }
    
        private static void Stop(object sender, EventArgs e)
        {
            s_run = false;
            s_renderer.Stop();
            Environment.Exit(0);
        }
    
        private static void Info()
        {
            Console.WriteLine("\nBlob the friendly terminal slime\n" +
                                "Created by: Basicx-StrgV\n" +
                                "GitHub: https://github.com/basicx-StrgV \n");
        }
    }
}
