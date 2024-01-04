namespace Game_Of_Sticks.Main;

public enum PlayerTurn {
    P1,
    P2
}

public class Game {
    private IPlaySticks currentPlayer;
    private readonly int maxSticks;

    private PlayerTurn playerTurn;

    // turnNumber %2 = 1 if It's p1's turn
    private int turnNumber;

    public Game(IPlaySticks p1, IPlaySticks p2, int maxSticks) {
        this.p1 = p1;
        this.p2 = p2;
        this.maxSticks = maxSticks;
        currentPlayer = p1;
    }

    private IPlaySticks p1 { get; }
    private IPlaySticks p2 { get; }

    public PlayerTurn PlayGame(bool silent) {
        turnNumber += Utils.random.Next(0, 1);
        var currentNumberOfSticks = maxSticks;

        do {
            AdvanceTurnCounter();


            if (!silent) {
                Console.WriteLine($"[Game] {currentPlayer.Name}'s turn");

                Utils.PrintSticksBar(maxSticks, currentNumberOfSticks);
                Console.WriteLine($"[Game] There are {currentNumberOfSticks} on the field");
            }

            var numberTaken = currentPlayer.MakeMove(currentNumberOfSticks);
            if (!silent) Console.WriteLine($"[Game] {currentPlayer.Name} took {numberTaken}");

            currentNumberOfSticks -= numberTaken;

            if (!silent) Console.WriteLine();
        } while (currentNumberOfSticks > 0);

        if (!silent) Console.WriteLine($"[Game] {currentPlayer.Name} has lost");


        AdvanceTurnCounter(); // Without advancing the turn counter the loser would be returned
        return playerTurn;
    }

    private void AdvanceTurnCounter() {
        turnNumber += 1;
        if (turnNumber % 2 == 1) {
            playerTurn = PlayerTurn.P1;
            currentPlayer = p1;
        }
        else {
            playerTurn = PlayerTurn.P2;
            currentPlayer = p2;
        }
    }
}