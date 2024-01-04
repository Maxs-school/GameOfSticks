namespace Game_Of_Sticks.Main;

public interface IPlaySticks {
    public string Name { get; }
    int MakeMove(int numSticks);
}