namespace Perceptron
{

    class Program
    {
        public static int Activate(double sum)
        {    
            if (sum > 0) 
                return 1;
            return 0;
        }
        public static void Train(double[,] inputs, int[] outputs, double[] weights, double speed, int EpochCount)
        {
            int numSamples = inputs.GetLength(0);
            int numInputs = inputs.GetLength(1);
            for (int Epoch = 0; Epoch < EpochCount; Epoch++) 
            {
                for (int i = 0; i < numSamples; i++)
                {
                    double sum = 0;

                    for (int j = 0; j < numInputs; j++)
                    {
                        sum += inputs[i,j] * weights[j];
                    }
                    int res = Activate(sum);

                    for(int j = 0; j < numInputs; j++)   
                    {
                        weights[j] += speed * (outputs[i] - res) * inputs[i,j];
                    }
                }
            }
        }

        static void TestPerceptron(double[,] inputs, int[] outputs, double[] weights)
        {
            int numInputs = inputs.GetLength(1);
            int numSamples = inputs.GetLength(0);

            Console.WriteLine("........");

            for (int i = 0; i < numSamples; i++)
            {
                double weightedSum = 0;
                // Вычисляем взвешенную сумму входов
                for (int j = 0; j < numInputs; j++)
                {
                    weightedSum += inputs[i, j] * weights[j];
                }
                int res = Activate(weightedSum);
                // Выводим результат
                Console.WriteLine($"Вход: [{inputs[i, 0]}, {inputs[i, 1]}], Нужный выход: {res}, Актуальный выход: {outputs[i]}");
            }
        }

        static void Main(string[] args)
        {
            double[,] inputs = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
            int[] outputs = { 0, 0, 0, 1 };
            
            double[] weights = { 0, 0 };
            
            double speed = 0.5; 
            int EpochCount = 100;

            Train(inputs,outputs,weights,speed,EpochCount);

            TestPerceptron(inputs,outputs,weights);
        }
    }
}
