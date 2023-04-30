using System;
using Microsoft.Graph;

namespace MailHinge_API.Interfaces
{
	public interface IOutlookService
	{
		public GraphServiceClient GetGraphServiceClient();
	

	}
}

