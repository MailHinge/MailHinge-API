using System;
using Google.Apis.Gmail.v1;

namespace MailHinge_API.Interfaces
{
	public interface IGMailService
	{
		public Task<GmailService> GetGmailServiceClient();
	}
}

