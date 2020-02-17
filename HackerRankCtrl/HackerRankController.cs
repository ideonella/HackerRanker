using System;

namespace HackerRankCtrl
{
	public class HackerRankController
	{
		public virtual string ChallengeTitle { get; set; }
		public virtual void CompleteChallenge()
		{
			Console.WriteLine("This is a non-answer. Override method CompelteChallenge().");
		}
	}
}
