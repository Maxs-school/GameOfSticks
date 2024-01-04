namespace Game_Of_Sticks.Main;



/// <summary>
///     Implements an AI that can progressively get smarter based on a simple reinforcement probability algorithm
/// </summary>
public class AI : IPlaySticks, ITestSticks {
    private readonly Neuron[] neurons;

    /// <summary>
    ///     Initialize a blank AI with enough cups for however large game you want to play
    /// </summary>
    /// <param name="maxNumSticks">The maximum number of sticks</param>
    /// <param name="maxSticksToTake">The maximum number of sticks</param>
    public AI(int maxNumSticks, int maxSticksToTake) {
        neurons = new Neuron[maxNumSticks];
        for (var i = 0; i < maxNumSticks; i++) neurons[i] = new Neuron(maxSticksToTake);
        Name = Utils.GetRandomName();
    }

    /// <summary>
    ///     Create a new AI based on a set of neurons, this shouldn't be needed outside of the copy method
    /// </summary>
    /// <param name="neuronStates">The array of Neurons for this new AI</param>
    /// <param name="name">The name of the AI</param>
    private AI(Neuron[] neuronStates, string name) {
        neurons = neuronStates;
        Name = name;
    }

    public string Name { get; }

    /// <summary>
    ///     Queries the AI's state to get the number of sticks to play at a point
    /// </summary>
    /// <param name="numSticks">Number of sticks remaining</param>
    /// <returns></returns>
    public int MakeMove(int numSticks) {
        return neurons[numSticks - 1].Query(numSticks);

    }

    /// <summary>
    ///     Reinforces or punishes every cup that got used during the previous round depending if it won or lost
    /// </summary>
    /// <param name="won"></param>
    public void TrainStep(bool won) {
        foreach (var neuron in neurons) neuron.TrainStep(won);
    }

    public int[] CupContents(int sticksRemaining) {
        return neurons[sticksRemaining - 1].weights.ToArray();
    }

    /// <summary>
    ///     Makes a deep copy of the AI except with a new name
    /// </summary>
    /// <returns>A new AI with a different name</returns>
    public AI Mitosis() {
        var newNeurons = new Neuron[neurons.Length];
        for (var i = 0; i < neurons.Length; i++) newNeurons[i] = neurons[i].Copy();

        return new AI(newNeurons, Utils.GetRandomName());
    }



    public void PrintWeights() {
        Console.Write("Ai weights: [ ");
        foreach (var neuron in neurons) Console.Write($"({neuron})");
        Console.WriteLine(" ]");
    }
}

public class Neuron {
    private int taken;


    /// <summary>
    ///     Returns a blank neuron with default weights
    /// </summary>
    public Neuron(int maxNumToTake) {
        weights = new List<int>();
        for (var i = 0; i < maxNumToTake; i++) weights.Add(1);

        taken = -1;
    }

    /// <summary>
    ///     Initializes a new neuron with some set of weights
    /// </summary>
    /// <param name="weights"></param>
    private Neuron(List<int> weights) {
        this.weights = weights;
        taken = -1;
    }

    public List<int> weights { get; }

    /// <summary>
    ///     Queries the neuron for a number of sticks to take
    /// </summary>
    /// <returns>The number of sticks the neuron "wants" to take</returns>
    public int Query(int numSticks) {
        var totalWeights = weights.Sum();
        var randomChoice = Utils.random.Next(1, totalWeights+1);

        int i = 0;
        while (true) {
            randomChoice -= weights[i];
            if (randomChoice <= 0) {
                this.taken = Math.Min(numSticks, i+1);
                return this.taken;
            }

            i++;
        }
    }

    /// <summary>
    ///     Reinforces or punishes the neuron depending on if it won or lost
    /// </summary>
    public void TrainStep(bool won) {
        if (taken == -1) return;


        if (won) {
            weights[taken - 1] += 1;
        }
        else if (!(weights[taken-1]==1)) {
            weights[taken - 1] -= 1;
        }

        taken = -1;

    }

    public override string ToString() {
        string thingy = "[";
        foreach (var i in this.weights) {
            thingy += $"{i}, ";
        }

        thingy += "]";

        return thingy;
    }

    /// <summary>
    ///     Makes a deep copy of the neuron. Does not copy over the `taken` and `used` properties
    /// </summary>
    /// <returns>A copy of this neuron with the same weight</returns>
    public Neuron Copy() {
        var newWeight = new List<int>(weights);
        return new Neuron(newWeight);
    }
}