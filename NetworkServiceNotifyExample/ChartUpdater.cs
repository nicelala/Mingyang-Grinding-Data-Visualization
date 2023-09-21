using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace NetworkServiceNotifyExample
{
    internal class ChartUpdater
    {
        private const int maxPoints = 5000;  // max number of points to display in chart

        public void UpdateChart(Chart chart, List<double> data)
        {
            if (chart.InvokeRequired)
            {
                chart.Invoke(new Action(() => UpdateChart(chart, data)));
            }
            else
            {
                for (int i = 0; i < data.Count; i++)
                {
                    int newXValue = chart.Series["Voltage"].Points.Count;
                    chart.Series["Voltage"].Points.AddXY(newXValue, data[i]);

                    // If the number of points exceeds maxPoints, clear all points and start from zero
                    if (chart.Series["Voltage"].Points.Count > maxPoints)
                    {
                        chart.Series["Voltage"].Points.Clear();
                        chart.Series["Voltage"].Points.AddXY(0, data[i]);
                    }

                    // Adjust X axis minimum and maximum values
                    double minXValue = chart.Series["Voltage"].Points[0].XValue;
                    double maxXValue = chart.Series["Voltage"].Points[chart.Series["Voltage"].Points.Count - 1].XValue;
                    chart.ChartAreas[0].AxisX.Minimum = minXValue;
                    chart.ChartAreas[0].AxisX.Maximum = maxPoints;

                    chart.ChartAreas[0].AxisY.Maximum = 20; // Adjust this value based on your needs
                    chart.Series["Voltage"].ChartType = SeriesChartType.Line;

                    chart.Invalidate(); // Redraw the chart
                }
            }
        }


        public void SetupChartSeries(Chart chart, string seriesName, SeriesChartType chartType, int borderWidth, Color color)
        {
            // 如果系列已經存在，則先移除它
            if (chart.Series.Any(s => s.Name == seriesName))
            {
                chart.Series.Remove(chart.Series[seriesName]);
            }

            var series = new Series(seriesName);
            series.ChartType = chartType;
            series.BorderWidth = borderWidth;
            series.Color = color;

            chart.Series.Add(series);
        }

        private Dictionary<string, int> xValueCounters = new Dictionary<string, int>();

        public void AddDataPoint(Chart chart, string seriesName, double yValue)
        {
            var series = chart.Series[seriesName];

            // Check if the series has a counter, if not initialize it
            if (!xValueCounters.ContainsKey(seriesName))
            {
                xValueCounters[seriesName] = 0;
            }

            // Increase the counter for the series and use it as xValue
            xValueCounters[seriesName]++;
            double xValue = xValueCounters[seriesName];

            // Add the new data point
            series.Points.AddXY(xValue, yValue);

            // If the total number of data points in the chart exceeds the limit...
            const int maxDataPoints = 100;  // Set your limit here
            if (series.Points.Count > maxDataPoints)
            {
                // ... remove the first data point
                series.Points.RemoveAt(0);
            }

            // Adjust X axis scale
            chart.ChartAreas[0].AxisX.Minimum = series.Points[0].XValue;
            chart.ChartAreas[0].AxisX.Maximum = xValue;

            // Redraw the chart
            chart.Invalidate();
        }

        private Dictionary<Chart, List<StripLine>> chartStripLines = new Dictionary<Chart, List<StripLine>>();

        public void AddThresholdLines(Chart chart, double upperLimit, double lowerLimit)
        {
            // 移除该图表的现有上下限线
            if (chartStripLines.ContainsKey(chart))
            {
                foreach (var stripLine in chartStripLines[chart])
                {
                    chart.ChartAreas[0].AxisY.StripLines.Remove(stripLine);
                }
            }

            // 添加新的上限线
            var upperLine = new StripLine();
            upperLine.BorderColor = Color.Red;
            upperLine.BorderWidth = 2;
            upperLine.IntervalOffset = upperLimit;

            // 添加新的下限线
            var lowerLine = new StripLine();
            lowerLine.BorderColor = Color.Green;
            lowerLine.BorderWidth = 2;
            lowerLine.IntervalOffset = lowerLimit;

            // 把新的上下限线添加到图表中
            chart.ChartAreas[0].AxisY.StripLines.Add(upperLine);
            chart.ChartAreas[0].AxisY.StripLines.Add(lowerLine);

            // 存储该图表的新上下限线
            chartStripLines[chart] = new List<StripLine> { upperLine, lowerLine };
        }


    }
}
