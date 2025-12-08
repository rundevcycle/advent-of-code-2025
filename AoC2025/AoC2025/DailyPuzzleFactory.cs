using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class DailyPuzzleFactory
    {
        public static DailyPuzzle Create(int day, List<string> inputData)
        {
            string className = $"DailyPuzzle{day:00}";

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type target = assembly.GetTypes()
                .First(t => t.IsClass && t.Name.Contains(className));

            if (target == null) 
            {
                throw new NotImplementedException($"No class with name {className}");
            }

            object? instance = Activator.CreateInstance(target, inputData);
            if (instance == null)
            {
                throw new NullReferenceException($"Unable to create an instance of {className}.");
            }
            return (DailyPuzzle) instance;
        }

    }
}
