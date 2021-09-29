using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tayfur.Blog.Entity.Concrete
{
	public class Error
	{
        public Guid Id { get; set; }
        public string StatusCode { get; set; }

		public string StatusDescription { get; set; }

		public string Message { get; set; }
		[Column(TypeName = "datetime2")]
		public DateTime DateTime { get; set; }
	}
}