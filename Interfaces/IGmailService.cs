using System;
using Google.Apis.Gmail.v1;

namespace MailHinge_API.Interfaces
{
	public interface IGmailService
	{
		public Task<GmailService> GetGmailServiceClient();
	}
}

