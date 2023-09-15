using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkServiceNotifyExample
{
    internal class FileHandler
    {

        private int currentLineCount = 0;

        public void SaveRmsValuesToCsv(List<double> rmsValues, string directoryPath, DateTime dateTime)
        {
            currentLineCount = 0; // 重置 currentLineCount
            // Create a directory if it doesn't exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Retry logic for file access
            int maxRetryAttempts = 5;
            int retryDelayMilliseconds = 100;
            int retryCount = 0;

            // Check the number of lines and create a new file if needed
            int maxLineCount = 10000;

            while (currentLineCount < rmsValues.Count)
            {
                string fileName = dateTime.ToString("yyyyMMddHHmmss") + ".csv";
                string filePath = Path.Combine(directoryPath, fileName);

                bool fileExists = File.Exists(filePath);

                if (!fileExists)
                {
                    // If the file doesn't exist, add a header
                    using (StreamWriter headerWriter = new StreamWriter(filePath, append: false))
                    {
                        headerWriter.WriteLine("RMS Value");
                    }
                }

                // Write RMS values to the CSV file with retry logic
                while (retryCount < maxRetryAttempts)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath, append: true))
                        {
                            for (int i = currentLineCount; i < Math.Min(currentLineCount + maxLineCount, rmsValues.Count); i++)
                            {
                                writer.WriteLine(rmsValues[i].ToString());
                            }
                        }

                        break; // Exit the retry loop on successful write
                    }
                    catch (IOException)
                    {
                        // File is being used by another process, wait and retry
                        Thread.Sleep(retryDelayMilliseconds);
                        retryCount++;
                    }
                }

                currentLineCount += maxLineCount; // Update the current line count
                dateTime = DateTime.Now; // Update the timestamp for the next file
            }
        }

        public static void AppendToCSV(string fileName, string deviceId, double maxRmsValue, double timeDifferenceSeconds, double cycleTimeSeconds, double waveformIntegral, string wheelStatus, string warningMessage)
        {
            string csvFilePath = GetCSVFilePath();
            string csvContent = $"{DateTime.Now},{deviceId},{maxRmsValue:F2},{timeDifferenceSeconds:F2},{cycleTimeSeconds:F2},{waveformIntegral:F2},{wheelStatus},{warningMessage}";

            if (!File.Exists(csvFilePath))
            {
                string header = "日期,設備ID,峰值,峰值時間,週期時間,波型積分,狀態,提醒通知";
                using (StreamWriter headerWriter = new StreamWriter(csvFilePath, false, Encoding.UTF8)) // 指定 UTF-8 編碼
                {
                    headerWriter.WriteLine(header);
                }
            }

            using (StreamWriter writer = new StreamWriter(csvFilePath, true, Encoding.UTF8)) // 指定 UTF-8 編碼
            {
                writer.WriteLine(csvContent);
            }
        }

        private static string GetCSVFilePath()
        {
            //string directorPath = "D:\\hao\\C#\\[Release]EDMPicoDeviceApplication-2000A-4ch\\Record_DATA";
            string directorPath = "C:\\test\\[Release]EDMPicoDeviceApplication-2000A-4ch\\Record_DATA";

            if (!Directory.Exists(directorPath))
            {
                Directory.CreateDirectory(directorPath);
            }

            string date = DateTime.Now.ToString("yyyyMMdd"); // 使用日期作為檔案名稱的一部分
            string fileName = $"{date}.csv"; // 加入 .csv 副檔名
            return Path.Combine(directorPath, fileName);
        }

    }
}
