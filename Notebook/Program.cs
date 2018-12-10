using System;

namespace Notebook
{
	class Program
	{
		static void Main(string[] args)
		{
			var notebook = new NodeTrie();

			Console.WriteLine($"Enter 's' for start search");
			while (true)
			{
				var input = Console.ReadLine();
				if (input.Equals("s", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}

				if (notebook.AddChild(input))
				{
					Console.WriteLine($"Add {input}");
				}
				else
				{
					Console.WriteLine($"Alread exists {input}");
				}
				
			}

			Console.WriteLine($"Enter 'e' for start search");
			while (true)
			{
				var input = Console.ReadLine();
				if (input.Equals("e", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}

				var count = notebook.Search(input);
				Console.WriteLine($"{input} -> {count}");
			}
		}
	}
}
