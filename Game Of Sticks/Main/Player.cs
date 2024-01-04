namespace Game_Of_Sticks.Main;

public class Player : IPlaySticks {
    public Player() {
        Name = Utils.GetStringSafe("What name do you want to use? ");
    }

    public string Name { get; }

    public int MakeMove(int numSticks) {
        return Utils.AskUntilInRange(1, 3, "How many do you want to take (1-3)? ");
    }
}