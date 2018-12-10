using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Notebook
{
	public class NodeTrie
	{
		private readonly Dictionary<char, NodeTrie> childs;

		protected int Count { get; set; }
		protected bool Word { get; set; }

		public NodeTrie()
		{
			childs = new Dictionary<char, NodeTrie>();
			Count = 0;
			Word = false;
		}

		public bool AddChild(string str)
		{
			var ch = str[0];

			if (!childs.TryGetValue(ch, out var child))
			{
				child = new NodeTrie();
				childs.Add(ch, child);
				if (str.Length == 1)
				{
					++child.Count;
					child.Word = true;
					return true;
				}
			}
			else if (str.Length == 1)
			{
				if (!child.Word)
				{
					++child.Count;
					child.Word = true;
					return true;
				}
				return false;
			}

			if (child.AddChild(str.Substring(1, str.Length - 1)))
			{
				++child.Count;
				return true;
			}

			return false;
		}

		public int Search(string str)
		{
			var ch = str[0];

			if (!childs.TryGetValue(ch, out var child))
			{
				return 0;
			}

			return str.Length == 1 ? child.Count : child.Search(str.Substring(1, str.Length - 1));
		}
	}
}