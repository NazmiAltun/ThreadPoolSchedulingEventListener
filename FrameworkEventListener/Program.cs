﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkEventListener
{
    class Program
    {
        private const int TaskCount = 3;

        static async Task Main(string[] args)
        {
            using var threadPoolSchedulingEventListener = new ThreadPoolSchedulingEventListener(Console.WriteLine);

            for (var i = 0; i < TaskCount; i++)
            {
                await Task.Run(() => { });
            }

            Console.WriteLine("Completed");
            Console.ReadKey();
        }
    }
}
