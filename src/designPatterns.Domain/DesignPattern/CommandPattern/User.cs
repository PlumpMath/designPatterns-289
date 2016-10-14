using System;
using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.CommandPattern
{
    public class User
    {
        private readonly Calculator _calculator = new Calculator();
        private readonly List<Command> _commands = new List<Command>();
        private int _current;

        public string Redo(int levels)
        {
            var response =
                string.Format("\n---- Redo {0} levels ", levels);
            for (var i = 0; i < levels; i++)
            {
                if (_current >= _commands.Count - 1) continue;
                var command = _commands[_current++];
                response += " - " + command.Execute();
            }
            return response;
        }

        public string Undo(int levels)
        {
            var response =
                string.Format("\n---- Undo {0} levels ", levels);
            for (var i = 0; i < levels; i++)
            {
                if (_current <= 0) continue;
                var command = _commands[--_current];
                response += " - " + command.UnExecute();
            }
            return response;
        }

        public string Compute(char @operator, int operand)
        {
            Command command = new CalculatorCommand( _calculator, @operator, operand);
            var response = command.Execute();

            _commands.Add(command);
            _current++;

            return response;
        }
    }
}
