using Game_Of_Sticks.Main;

namespace GameOfSticksTest;

[TestClass]
public class SmallerUnits {
    [TestMethod]
    public void TestQuery() {
        const int queriesPerCount = 100;
        const int maxCount = 10;
        HashSet<int> values = new HashSet<int>();

        for (int i = 3; i < maxCount; i++) {
            Neuron neuron = new Neuron(i);
            for (int j = 0; j < i*queriesPerCount; j++) {
                values.Add(neuron.Query(i));
            }
            Assert.IsTrue(values.Count==i);
            values = new HashSet<int>();
        }
    }

    [TestMethod]
    public void testReinforce() {
        const int iterationCount=100;
        const int maxCount = 10;

        Neuron neuron;
        for (int i = 3; i < maxCount; i++) {
            for (int _ = 0; _ < iterationCount; _++) {
                neuron = new Neuron(i);
                int value = neuron.Query(maxCount);
                neuron.TrainStep(true);
                Assert.IsTrue(neuron.weights[value-1]==2, "Neuron weights weren't reinforced properly");

                neuron = new Neuron(i);
                neuron.Query(maxCount);
                neuron.TrainStep(false);

                int[] allOnes = new int[i];
                for (int k = 0; k < i; k++) {
                    allOnes[k] = 1;
                }

                Assert.IsTrue(Enumerable.SequenceEqual( neuron.weights.ToArray(),allOnes), "Neuron weights weren't decremented properly");
            }
        }
    }
}