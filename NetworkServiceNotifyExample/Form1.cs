using NetworkServiceNotifyUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NetworkServiceNotifyExample
{
    public partial class Form1 : Form
    {
        private NetworkService _NetworkService = null;
        private ushort HostSetting_ServicePort = 38000;
        private DataProcessing _dataProcessing = new DataProcessing();
        private FileHandler _fileHandler = new FileHandler();
        private ChartUpdater _chartUpdater = new ChartUpdater();

        private string rootPath = @"C:\test\[Release]EDMPicoDeviceApplication-2000A-4ch";
        private Process externalProcess;
        private ModbusServerManager modbusManager;


        public Form1()
        {
            InitializeComponent();
            modbusManager = new ModbusServerManager();

            string rootPath = @"C:\test\[Release]EDMPicoDeviceApplication-2000A-4ch";

            SetupFolderWatcher(rootPath);

            this.Load += Form1_Load;  // 訂閱 Form1_Load 事件處理函數
            //string rootPath = @"D:\hao\C#\[Release]EDMPicoDeviceApplication-2000A-4ch";

            // _NetworkService = new NetworkService("127.0.0.1", HostSetting_ServicePort);
            // _NetworkService.Start();

            //string programPath = @"D:\hao\C#\[Release]EDMPicoDeviceApplication-2000A-4ch\EDMPicoDeviceApplication.exe";
            string programPath = @"C:\test\[Release]EDMPicoDeviceApplication-2000A-4ch\EDMPicoDeviceApplication.exe";
            string workingDirectory = Path.GetDirectoryName(programPath);

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = programPath,
                WorkingDirectory = workingDirectory
            };

            try
            {
                externalProcess = Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not start the program. Error: " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Setup chart series in the Form1_Load event handler
            _chartUpdater.SetupChartSeries(chartCurrentWave, "RMS", SeriesChartType.Point, 3, Color.Blue);
            _chartUpdater.SetupChartSeries(chartPeakRecord, "MaxRmsValue", SeriesChartType.Point, 3, Color.Red);
            _chartUpdater.SetupChartSeries(chartPTimeRecord, "TimeDifferenceSeconds", SeriesChartType.Point, 3, Color.Green);
            _chartUpdater.SetupChartSeries(chartCTimeRecord, "CycleTimeSeconds", SeriesChartType.Point, 3, Color.Purple);
            _chartUpdater.SetupChartSeries(chartIntegralRecord, "WaveformIntegral", SeriesChartType.Point, 3, Color.Yellow);

            chartCurrentWave.Series.Clear();
            var series = new Series("Current Wave");
            series.ChartType = SeriesChartType.Line; // 這裡使用線性圖，您可以根據需要修改
            chartCurrentWave.Series.Add(series);
            this.FormClosed += Form1_FormClosed;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Check if the process is still running
            if (externalProcess != null && !externalProcess.HasExited)
            {
                try
                {
                    externalProcess.Kill();
                    externalProcess.WaitForExit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error terminating the external program: " + ex.Message);
                }
            }

            // Here, you can also stop other services or perform cleanup if needed
            _NetworkService.Stop();
        }

        private string device_ID = "H001";
        private double threshold_1 = 25;
        private double threshold_2 = 26;
        private double threshold_3 = 27;
        private double threshold_4 = 28;
        private double peakUpper = 26;
        private double peakLower = 24;
        private double peakTimeUpper = 0.4;
        private double peakTimeLower = 0.2;
        private double cycleUpper = 16;
        private double cycleLower = 14;
        private double integralUpper = 38000;
        private double integralLower = 35000;

        private StringBuilder warningMessages = new StringBuilder();

        private int rmsPm = 50;
        private int smoothPm = 10;
        private bool parametersSet = false; // 增加一個參數設定完成的標誌

        private void SetupFolderWatcher(string path)
        {
            var folderWatcher = new FileSystemWatcher(path)
            {
                NotifyFilter = NotifyFilters.DirectoryName // 只監視子目錄名稱的變更
            };

            folderWatcher.Created += (s, e) =>
            {
                // 檢查新的子目錄是否以 "Data" 開頭。
                if (Path.GetFileName(e.FullPath).StartsWith("Data") && (e.ChangeType == WatcherChangeTypes.Created))
                {
                    //MessageBox.Show("Detected new directory with 'Data' prefix: " + e.FullPath);
                    SetupFileWatcher(e.FullPath);
                }
            };

            folderWatcher.EnableRaisingEvents = true;
        }

        private void SetupFileWatcher(string path)
        {
            var fileWatcher = new FileSystemWatcher(path);
            fileWatcher.Filter = "*.csv";

            // 使用一個 Dictionary 來跟踪已經通知過的文件
            var notifiedFiles = new Dictionary<string, DateTime>();

            fileWatcher.Changed += async (s, e) =>
            {
                if (notifiedFiles.ContainsKey(e.FullPath))
                {
                    // 如果文件在過去的一段時間內已經被通知過，則忽略
                    if ((DateTime.Now - notifiedFiles[e.FullPath]).TotalSeconds < 10)
                        return;

                    notifiedFiles[e.FullPath] = DateTime.Now;
                }
                else
                {
                    notifiedFiles.Add(e.FullPath, DateTime.Now);
                }

                // 重試機制
                const int maxRetries = 5;
                int retryCount = 0;
                bool success = false;

                while (retryCount < maxRetries && !success)
                {
                    try
                    {
                        await Task.Delay(1000);  // 延遲一些時間以確保文件已完成寫入
                        LoadCsvToChart(e.FullPath);
                        success = true;
                    }
                    catch (IOException)
                    {
                        retryCount++;
                        await Task.Delay(2000 * retryCount);  // 隨著重試次數增加，延遲的時間也增加
                    }
                }

                if (!success)
                {
                    // 可以在此處處理最終讀取失敗的情況，例如通過日誌或提示用戶
                }
            };

            fileWatcher.EnableRaisingEvents = true;
        }

        private void 設定初始參數ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParameterSetting parameterSetting = new ParameterSetting();
            parameterSetting.InputThresholds += ParameterSetting_InputThresholds;
            parameterSetting.ShowDialog();
            // 在 ShowDialog 方法後立即關閉視窗
            parameterSetting.Close();
        }

        private void ParameterSetting_InputThresholds(object sender, ParameterSetting.ThresholdEventArgs e)
        {
            // 設定參數
            device_ID = e.DeviceID;
            threshold_1 = e.Threshold1;
            threshold_2 = e.Threshold2;
            threshold_3 = e.Threshold3;
            threshold_4 = e.Threshold4;
            // rmsPm = e.RMSPm;
            // smoothPm = e.SmoothPm;
            peakUpper = e.PeakUpper;
            peakLower = e.PeakLower;
            peakTimeUpper = e.PeakTimeUpper;
            peakTimeLower = e.PeakTimeLower;
            cycleUpper = e.CycleUpper;
            cycleLower = e.CycleLower;
            integralUpper = e.IntegralUpper;
            integralLower = e.IntegralLower;

            parametersSet = true; // 標誌設置為 true
        }

        //private async Task ProcessExistingFilesAsync(string directory)
        //{
        //    foreach (var file in Directory.GetFiles(directory, "*.csv"))
        //    {
        //        //label5.Text = file; // 更新標籤以顯示當前的文件目錄
        //        LoadCsvToChart(file);
        //        // 這邊可能需要做一些事情，例如刷新圖表等等

        //        await Task.Delay(2000); // 等待2秒，讓使用者有足夠的時間看到圖表的更新
        //    }
        //}


        // 新增的區域變數
        private int countOverTwo = 0;
        private List<string> currentIntervalData = new List<string>();
        private List<string> currentIntervalVolt = new List<string>();

        private List<List<string>> allIntervalData = new List<List<string>>();

        private async void LoadCsvToChart(string csvPath)
        {
            using (var stream = new FileStream(csvPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(stream))
            {
                sr.ReadLine();  // Read and discard header line

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    if (TryGetProcessedValue(line, out double yVal))
                    {
                        ProcessValue(yVal);
                        
                    }
                    //使用Modbus協定傳送到Client端
                    modbusManager.UpdateModbusRegisters(dateNow, device_ID, maxMovingAverage, intervalToMax, CycleTimeseconds, totalArea, WheelStatus.ToString(), warningMessages.ToString());
                    warningMessages.Clear();  // 如果使用同一个StringBuilder实例
                }
            }

            

        }

        private double CalculateIntervalToMaxValue(List<string> data)
        {
            List<double> doubleData = new List<double>();
            foreach (var s in data)
            {
                if (double.TryParse(s, out double result))
                {
                    doubleData.Add(result);
                }
            }

            double maxValue = doubleData.Max();
            int index = doubleData.IndexOf(maxValue);

            return index / 5000.0; // Convert index to seconds
        }

        private double CalculateRMS(List<string> data)
        {
            List<double> doubleData = data.Select(s => double.Parse(s)).ToList();
            double sumOfSquares = doubleData.Sum(d => d / 100 * d / 100);
            return Math.Sqrt(sumOfSquares / doubleData.Count);
        }

        private double GetMaxValue(List<string> data)
        {
            return data.Select(s => double.Parse(s)).Max();
        }

        private int yValCounter = 0;
        private bool TryGetProcessedValue(string line, out double yVal)
        {
            yVal = 0;
            string[] parts = line.Split(',');

            if (parts.Length > 1 && double.TryParse(parts[0], out yVal))
            {
                yVal /= 1000; // 将 yVal 除以 1000

                // 如果 yVal > 2，捕捉相應的 parts[1] 資料
                if (yVal > 2)
                {
                    currentIntervalData.Add(parts[1]);

                    yValCounter++;

                    if (yValCounter > 50) 
                    {
                        currentIntervalVolt.Add(yVal.ToString());
                        yValCounter = 0;
                    }
                }
                return true;
            }
            return false;
        }

        private bool isInOverTwoInterval = false;
        private double CycleTimeseconds = -1;
        private double intervalToMax = -1;
        private string dateNow;
        private string WheelStatus = "";

        private async Task ProcessValue(double yVal) // 注意 "async" 和 "Task"
        {
            if (yVal > 2)
            {
                countOverTwo++;  // 增加数量
                isInOverTwoInterval = true;
            }
            else if (yVal < 0.5 && isInOverTwoInterval)
            {
                if (countOverTwo > 70000) // 在此检查countOverTwo，而不是之前
                {
                    // 结束 yVal > 2 的区间
                    isInOverTwoInterval = false;

                    // 将当前区间的数据加入到 allIntervalData，然后清空 currentIntervalData
                    allIntervalData.Add(new List<string>(currentIntervalData));

                    intervalToMax = CalculateIntervalToMaxValue(currentIntervalData);
                    int totalCount = 0;
                    foreach (var interval in allIntervalData)
                    {
                        totalCount += interval.Count;
                    }
                    CycleTimeseconds = totalCount / 5000.0;

                    UpdateChartWithSegmentedRMSData();
                    this.Invoke(new Action(() => {

                        // Update labels
                        LB_detail.Text = countOverTwo.ToString();
                        LBPeakTime.Text = $"{intervalToMax:F2} seconds";
                        LBCycleTime.Text = $"{CycleTimeseconds:F2} seconds";

                        string[] statusNames = { "1", "2", "3", "4" };
                        double[] thresholds = { threshold_1, threshold_2, threshold_3, threshold_4 };
                        int statusIndex = 0;

                        while (statusIndex < thresholds.Length && maxMovingAverage >= thresholds[statusIndex])
                        {
                            statusIndex++;
                        }

                        // 添加检查以防止越界
                        if (statusIndex >= statusNames.Length)
                        {
                            statusIndex = statusNames.Length - 1;
                        }

                        if (statusIndex == 0)
                        {
                            WheelStatus = "-";
                        }
                        else
                        {
                            WheelStatus = statusNames[statusIndex - 1];
                        }
                        LBWheelStatus.Text = WheelStatus;

                        // Now add these values to the charts
                        //int newChartXValue = chartPeakRecord.Series["MaxRmsValue"].Points.Count;  // replace "SeriesName" with the name of your series

                        _chartUpdater.AddDataPoint(chartPeakRecord, "MaxRmsValue", maxMovingAverage);
                        _chartUpdater.AddDataPoint(chartPTimeRecord, "TimeDifferenceSeconds", intervalToMax);
                        _chartUpdater.AddDataPoint(chartCTimeRecord, "CycleTimeSeconds", CycleTimeseconds);
                        _chartUpdater.AddDataPoint(chartIntegralRecord, "WaveformIntegral", totalArea);

                        _chartUpdater.AddThresholdLines(chartPeakRecord, peakUpper, peakLower);
                        _chartUpdater.AddThresholdLines(chartPTimeRecord, peakTimeUpper, peakTimeLower);
                        _chartUpdater.AddThresholdLines(chartCTimeRecord, cycleUpper, cycleLower);
                        _chartUpdater.AddThresholdLines(chartIntegralRecord, integralUpper, integralLower);

                        // Set maximum X value to 10
                        chartPeakRecord.ChartAreas[0].AxisX.Maximum = 100;
                        chartPTimeRecord.ChartAreas[0].AxisX.Maximum = 100;
                        chartCTimeRecord.ChartAreas[0].AxisX.Maximum = 100;
                        chartIntegralRecord.ChartAreas[0].AxisX.Maximum = 100;

                        CheckAndAppendMessage(warningMessages, maxMovingAverage, peakUpper,
                            "A");

                        CheckAndAppendMessage(warningMessages, intervalToMax, peakTimeUpper,
                            "B");

                        CheckAndAppendMessage(warningMessages, CycleTimeseconds, cycleUpper,
                            "C");

                        CheckAndAppendMessage(warningMessages, totalArea, integralUpper,
                            "D");


                        // 最後，檢查是否有任何消息被添加
                        if (warningMessages.Length == 0)
                        {
                            warningMessages.Append("0");
                        }
                    }));


                    // Save RMS values to CSV file
                    //string directoryPath = "D:\\hao\\C#\\[Release]EDMPicoDeviceApplication-2000A-4ch\\RMS_DATA";
                    string directoryPath = "C:\\test\\[Release]EDMPicoDeviceApplication-2000A-4ch\\RMS_DATA";
                    DateTime dateTime = DateTime.Now;
                    _fileHandler.SaveRmsValuesToCsv(movingAverageValues, directoryPath, dateTime);
                    dateNow = dateTime.ToString("yyyyMMddHHmmss"); // 取得當前日期
                    FileHandler.AppendToCSV(dateNow, device_ID, maxMovingAverage, intervalToMax, CycleTimeseconds, totalArea, LBWheelStatus.Text, warningMessages.ToString());

                    
                }

                currentIntervalData.Clear();
                currentIntervalVolt.Clear();
                countOverTwo = 0;
                allIntervalData.Clear();
            }
        }

        private void CheckAndAppendMessage(StringBuilder sb, double value, double upperLimit, string warningMessage)
        {
            if (value > upperLimit)
            {
                sb.Append(warningMessage);
            }
            //else if (value < lowerLimit)
            //{
            //    sb.Append(noteMessage);
            //}
        }

        private List<double> CalculateSegmentedRMS(List<string> data, int segmentSize)
        {
            List<double> rmsValues = new List<double>();
            for (int i = 0; i < data.Count; i += segmentSize)
            {
                var group = data.Skip(i).Take(segmentSize).ToList();
                double rms = CalculateRMS(group);
                rmsValues.Add(rms);
            }
            return rmsValues;
        }


        private void EnsureSeriesExistence(string seriesName)
        {
            if (!chartCurrentWave.Series.Any(s => s.Name == seriesName))
            {
                chartCurrentWave.Series.Add(seriesName);
            }
        }

        private double maxMovingAverage = -1;
        private List<double> movingAverageValues = new List<double>();
        private double totalArea = -1;
        private void UpdateChartWithSegmentedRMSData()
        {
            if (chartCurrentWave.InvokeRequired)
            {
                chartCurrentWave.Invoke(new Action(UpdateChartWithSegmentedRMSData));
                return;
            }

            EnsureSeriesExistence("Peak Line");
            EnsureSeriesExistence("Voltage Series");  // 确保新的系列存在

            List<double> allRmsValues = new List<double>(); // 新建一個 List 來存儲所有 RMS 值

            foreach (var interval in allIntervalData)
            {
                List<double> segmentedRMS = CalculateSegmentedRMS(interval, rmsPm);
                allRmsValues.AddRange(segmentedRMS);  // 將當前分段的 RMS 值加入到所有 RMS 值的 List 中
            }

            // 對 RMS 值進行移動平均
            movingAverageValues = DataProcessing.MovingAverage(allRmsValues, smoothPm);

            // 找到最大的移動平均 RMS 值並顯示
            maxMovingAverage = movingAverageValues.Max();
            LBPeakValue.Text = maxMovingAverage.ToString("F2"); // 格式化為保留兩位小數


            // 设定整个movingAverageValues列表的范围
            int startIndex = 0;
            int endIndex = movingAverageValues.Count - 1;

            double intervalTime = CycleTimeseconds / movingAverageValues.Count;
            var seriesPeakLine = chartCurrentWave.Series["Peak Line"];
            seriesPeakLine.Points.Clear();

            var seriesVoltage = chartCurrentWave.Series["Voltage Series"];
            seriesVoltage.Points.Clear();
            double voltageIntervalTime = CycleTimeseconds / currentIntervalVolt.Count;


            for (int i = 0; i < movingAverageValues.Count; i++)
            {
                seriesPeakLine.Points.AddXY(i * intervalTime, movingAverageValues[i]);
            }

            for (int i = 0; i < currentIntervalVolt.Count; i++)
            {
                if (double.TryParse(currentIntervalVolt[i], out double voltage))
                {
                    seriesVoltage.Points.AddXY(i * voltageIntervalTime, voltage);
                }
            }

            // 设置X轴标签格式为整数
            chartCurrentWave.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0}";

            // 设置X轴标签的角度为0，使其横向显示
            chartCurrentWave.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

            // 设置X轴的标题
            chartCurrentWave.ChartAreas[0].AxisX.Title = "时间（秒）";

            // 根据需要调整X轴的间隔
            chartCurrentWave.ChartAreas[0].AxisX.Interval = 1;

            // 设置 Voltage Series 的属性
            seriesVoltage.ChartType = SeriesChartType.Line;  // 例如：设置为线形图
            seriesVoltage.BorderWidth = 2;
            seriesVoltage.Color = Color.Red; // 设置颜色为红色


            // 在 Peak Line 系列中設置連續線段樣式
            seriesPeakLine.ChartType = SeriesChartType.Line;
            seriesPeakLine.BorderWidth = 2;
            seriesPeakLine.Color = Color.Blue;

            // 移除長條圖系列
            var seriesToRemove = chartCurrentWave.Series
                .Where(s => s.ChartType == SeriesChartType.Column)
                .ToList();
            foreach (var series in seriesToRemove)
            {
                chartCurrentWave.Series.Remove(series);
            }

            totalArea = CalculateWaveformArea(movingAverageValues, startIndex, endIndex);

            LBPeakIntegral.Text = totalArea.ToString("F2"); // 顯示波型面積值
        }


        public static double CalculateWaveformArea(List<double> movingAverageValues, int startIndex, int endIndex)
        {
            double totalArea = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                double yValue = movingAverageValues[i];
                double xValue = i + 1;

                if (i > startIndex)
                {
                    double xPrev = xValue - 1;
                    double yPrev = movingAverageValues[i - 1];
                    totalArea += ((yValue + yPrev) / 2) * (xValue - xPrev);
                }

                if (i < endIndex)
                {
                    double xNext = xValue + 1;
                    double yNext = movingAverageValues[i + 1];
                    totalArea += ((yValue + yNext) / 2) * (xNext - xValue);
                }
            }

            return totalArea;
        }
    }
}
