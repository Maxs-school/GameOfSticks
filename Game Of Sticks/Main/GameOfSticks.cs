namespace Game_Of_Sticks.Main;

internal static partial class GameOfSticks {
    private static readonly int maxSticksToTake = 69;
    private static readonly int totalIterationCount = 1000000;
    private static readonly int generationCounter = 100;
    private static readonly int maxNumSticks = 2000;

    public static void Main() {
        bool playing = true;

        Utils.GameType gameType = Utils.GetGameType();

        IPlaySticks p1 = new RandomAi(maxSticksToTake);
        IPlaySticks p2 = new RandomAi(maxSticksToTake);
        bool trained = false;
        do {
            switch (gameType) {
                case Utils.GameType.PlayerVsAi: {
                    p1 = new Player();
                    if (!trained) {
                        Console.WriteLine("Training AI please wait");
                        p2 = new Trainer(generationCounter, totalIterationCount, maxNumSticks, maxSticksToTake).Train();
                        ((AI)p2).PrintWeights();
                        trained = true;
                    }

                    break;
                }
                case Utils.GameType.Quit: {
                    Environment.Exit(0);
                    break;
                }
                default: {
                    p1 = new Player();
                    p2 = new Player();
                    break;
                }
            }

            Game game = new Game(p1, p2, 20);
            game.PlayGame(false);

            playing = Utils.GetTrueFalse("Do you want to play again?");
        } while (playing);

    }
}