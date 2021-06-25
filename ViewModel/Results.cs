using System.Collections.Generic;
using RPNLogic;

namespace ViewModel
{
    public class Results
    {
        public Dictionary<int,double> AllResults { get; private set; }
        private int step { get; set; }
        private int currentStep { get; set; }
        private int endStep { get; set; }
        private string data { get; set; }
        public Results(int step, int currentStep, int endStep, string data)
        {
            AllResults = new Dictionary<int, double>();
            this.step = step;
            this.currentStep = currentStep;
            this.endStep = endStep;
            this.data = data;
            MakeSteps();
        }

        private void MakeSteps()
        {
            while(currentStep<=endStep)
            {
                var value = new Calculator(currentStep, new Transfer(data).GetRPN()).Calculate();
                AllResults.Add(currentStep, value);
                currentStep += step;
            }
        }
    }
}
