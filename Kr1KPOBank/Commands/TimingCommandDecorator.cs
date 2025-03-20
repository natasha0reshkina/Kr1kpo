using System;
using System.Diagnostics;

namespace Kr1kpo.Commands
{
    public class TimingCommandDecorator : ICommand
    {
        private readonly ICommand _command;

        public TimingCommandDecorator(ICommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            var stopwatch = Stopwatch.StartNew();
            _command.Execute();
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}