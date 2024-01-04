
namespace TestingSticks
{
	/// <summary>
	/// Empty AI, with code to demonstrate implementation of ITestSticks interface
	/// </summary>
	class AI : ITestSticks
	{
		public int[] CupContents(int sticksRemaining)
		{
			// Should actually return AI's chip counts for the given # of sticks remaining

			// I never learn.
			return new int[] { 1, 1, 1 };
		}

		public void GameOver(bool won)
		{
			// Should actually call whatever method(s) AI uses to learn in response to winning/losing

			// Really, I never learn.
			return;
		}

		public int GetSticks(int sticksRemaining)
		{
			// Should actually call whatever method AI has for communicating
			// its move for the given number of sticks remaining

			// Always taking 1 sounds like a good strategy to me! I never learn.
			return 1;
		}
	}
}
