using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShardLibrary.Models
{
	public class Book
	{
		public string Isbn { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int PublishYear { get; set; }
	}
}
