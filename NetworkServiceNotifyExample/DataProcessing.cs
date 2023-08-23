using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkServiceNotifyExample
{
    internal class DataProcessing
    {
        public double CalculateRms(List<double> data)
        {
            double squareSum = data.Sum(x => x / 100 * x / 100);
            return Math.Sqrt(squareSum / data.Count);
        }

        public static List<double> MovingAverage(List<double> data, int period)
        {
            List<double> ret = new List<double>();
            double sum = 0;

            for (int i = 0; i < period; i++)
            {
                sum += data[i];
            }

            ret.Add(sum / period);

            for (int i = period; i < data.Count; i++)
            {
                sum = sum - data[i - period] + data[i];
                ret.Add(sum / period);
            }

            return ret;
        }

        public List<double> CalculateMovingAverages(List<double> data, int windowSize)
        {
            List<double> smoothedData = new List<double>();
            int halfWindowSize = windowSize / 2;

            for (int i = 0; i < data.Count; i++)
            {
                double sum = 0;
                int count = 0;

                for (int j = i - halfWindowSize; j <= i + halfWindowSize; j++)
                {
                    if (j >= 0 && j < data.Count)
                    {
                        sum += data[j];
                        count++;
                    }
                }

                double average = sum / count;
                smoothedData.Add(average);
            }

            return smoothedData;
        }




    }
}
