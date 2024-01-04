namespace Game_Of_Sticks.Main;

public class RandomAi : IPlaySticks {
    int maxSticks;
    public RandomAi(int maxSticks) {
        Name = Utils.GetRandomName();
        this.maxSticks = maxSticks;
    }

    public string Name { get; }


    public int MakeMove(int numSticks) {
        return Utils.random.Next(1, maxSticks);
    }
}