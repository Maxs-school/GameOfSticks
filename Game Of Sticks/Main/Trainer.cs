namespace Game_Of_Sticks.Main;

public class Trainer {
    private AI ai1;
    private AI ai2;

    private readonly Game gameRunner;
    private int GenerationCounter = 0;

    private int IterationCounter;
    private readonly int maxNumSticks;
    private int maxSticksToTake;
    private int poolsize;
    private readonly int stepsPerGen;
    private readonly int totalGenerationCount;
    private int totalIterationCount;

    /// <summary>
    ///     Instantiate a Trainer
    /// </summary>
    /// <param name="generationCount">The number of generations to run through</param>
    /// <param name="totalIterationCount">The total number of steps to run through</param>
    /// <param name="maxNumSticks">How many sticks to play with</param>
    public Trainer(int generationCount, int totalIterationCount, int maxNumSticks, int maxSticksToTake) {
        totalGenerationCount = generationCount;
        this.totalIterationCount = totalIterationCount;
        this.maxNumSticks = maxNumSticks;
        this.maxSticksToTake = maxSticksToTake;

        stepsPerGen = totalIterationCount / generationCount;

        ai1 = new AI(maxNumSticks, maxSticksToTake);
        ai2 = new AI(maxNumSticks, maxSticksToTake);

        gameRunner = new Game(ai1, ai2, this.maxNumSticks);
    }

    /// <summary>
    ///     Trains an ai through multiple generations
    /// </summary>
    /// <returns>A trained AI</returns>
    public AI Train() {
        PlayerTurn winner;
        int p1Wins = 0;
        int p2Wins = 0;
        for (var gen = 0; gen < totalGenerationCount; gen++) {
            for (var i = 0; i < stepsPerGen; i++) {
                IterationCounter += 1;
                winner = gameRunner.PlayGame(true);
                p1Wins += PlayerTurn.P1 == winner ? 1 : 0;
                p2Wins += PlayerTurn.P2 == winner ? 1 : 0;
                ai1.TrainStep(winner == PlayerTurn.P1);
                ai2.TrainStep(winner == PlayerTurn.P2);

            }

            float total = p1Wins + p2Wins;
            Console.WriteLine($"{ai1.Name} won {(p1Wins/total)*100}%");
            Console.WriteLine($"{ai2.Name} won {(p2Wins/total)*100}%");

            Console.WriteLine($"Generation {gen} finished");
            CloneBetterAi();

        }

        return ai1;
    }

    /// <summary>
    ///     Runs a small of 7 1v1 between the AI's
    ///     The winner gets `mitosis` called and is
    ///     then put against the winner for the next
    ///     set
    /// </summary>
    private void CloneBetterAi() {
        var ai1Wins = 0;
        var ai2Wins = 0;

        var winner = PlayerTurn.P1;
        for (var i = 0; i < 7; i++) {
            winner = gameRunner.PlayGame(true);
            if (winner == PlayerTurn.P1)
                ai1Wins += 1;
            else
                ai2Wins += 1;

            if (ai1Wins >= 3) {
                Console.WriteLine($"(1) {ai1.Name} won");
                ai2 = ai1.Mitosis();
                return;
            }

            if (ai2Wins >= 3) {
                Console.WriteLine($"(2) {ai2.Name} won");
                ai1 = ai2.Mitosis();
                return;
            }
        }
    }
}