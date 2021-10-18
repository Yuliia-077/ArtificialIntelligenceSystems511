using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork1
{
  
    public class ModelingLogicalFunction
    {
        public int X1 { get; set; } //1 вхід нейрона
        public int X2 { get; set; } //2 вхід нейрона
        public LogicalFunction LogFunc { get; set; } //логічна функція

        public ModelingLogicalFunction(int x1, LogicalFunction logicalFunction) 
        {
            X1 = x1;
            X2 = 0;
            LogFunc = logicalFunction;
        }

        public ModelingLogicalFunction(int x1, int x2, LogicalFunction logicalFunction)
        {
            X1 = x1;
            X2 = x2;
            LogFunc = logicalFunction;
        }
        //відповідно до логічної функції передаються певні вагові коефіцієнти і порогове значення
        public List<int> Modeling() 
        {
            List<int> y = new List<int>();
            if(LogFunc == LogicalFunction.AND)
                y.Add(CountY(1, 1, 1.5));
            else if (LogFunc == LogicalFunction.OR)
                y.Add(CountY(1, 1, 0.5));
            else if(LogFunc == LogicalFunction.NOT)
                y.Add(CountY(-1.5, null, -1));
            else if(LogFunc == LogicalFunction.XOR)
            {
                y.Add(CountY(1, -1, 0.5));
                y.Add(CountY(-1, 1, 0.5));
            }
            return y;
        }
        //отримання виходу нейрона
        private int CountY(double w1, double? w2, double z)
        {
            double sum = X1 * w1;
            if (w2 != null)
                sum += X2 * (int)w2;

            if (sum < z)
                return 0;
            return 1;
        }
    }
}
