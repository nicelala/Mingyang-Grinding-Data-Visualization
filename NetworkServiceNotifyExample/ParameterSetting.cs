using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkServiceNotifyExample
{
    public partial class ParameterSetting : Form
    {
        // 定义事件参数类，用于保存阈值
        public class ThresholdEventArgs : EventArgs
        {
            public string DeviceID { get; set; }
            public double Threshold1 { get; set; }
            public double Threshold2 { get; set; }
            public double Threshold3 { get; set; }
            public double Threshold4 { get; set; }
            public int RMSPm { get; set; }
            public int SmoothPm { get; set; }

            public double PeakUpper { get; set; }
            public double PeakLower { get; set; }
            public double PeakTimeUpper { get; set; }
            public double PeakTimeLower { get; set; }
            public double CycleUpper { get; set; }
            public double CycleLower { get; set; }
            public double IntegralUpper { get; set; }
            public double IntegralLower { get; set; }

        }

        // 定义事件，用于在参数输入后通知Form1
        public event EventHandler<ThresholdEventArgs> InputThresholds;
        private ThresholdEventArgs thresholds = new ThresholdEventArgs();

        public ParameterSetting()
        {
            InitializeComponent();
        }

        private void Btn_DeviceID_Click(object sender, EventArgs e)
        {
            if (tb_DeviceID.Text.Length <= 0)
            {
                MessageBox.Show("設備ID尚未填寫!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            thresholds.DeviceID = tb_DeviceID.Text;
            InputThresholds?.Invoke(this, thresholds);

        }

        private void Btn_InputThreshold1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_Threshold1.Text, out double threshold1))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.Threshold1 = threshold1;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_InputThreshold2_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_Threshold2.Text, out double threshold2))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.Threshold2 = threshold2;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_InputThreshold3_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_Threshold3.Text, out double threshold3))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.Threshold3 = threshold3;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_InputThreshold4_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_Threshold4.Text, out double threshold4))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.Threshold4 = threshold4;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_PeakUpper_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_PeakUpper.Text, out double peakUpper))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.PeakUpper = peakUpper;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_PeakLower_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_PeakLower.Text, out double peakLower))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.PeakLower = peakLower;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_PeakTimeUpper_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_PeakTimeUpper.Text, out double peakTimeUpper))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.PeakTimeUpper = peakTimeUpper;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_PeakTimeLower_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_PeakTimeLower.Text, out double peakTimeLower))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.PeakTimeLower = peakTimeLower;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_CycleUpper_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_CycleUpper.Text, out double cycleUpper))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.CycleUpper = cycleUpper;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_CycleLower_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_CycleLower.Text, out double cycleLower))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.CycleLower = cycleLower;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_IntegralUpper_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_IntegralUpper.Text, out double integralUpper))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.IntegralUpper = integralUpper;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_IntegralLower_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_IntegralLower.Text, out double integralLower))
            {
                MessageBox.Show("閥值格式無效");
                return;
            }

            thresholds.IntegralLower = integralLower;
            InputThresholds?.Invoke(this, thresholds);
        }

        // 每次点击按钮，都更新对应的参数，并触发事件
        private void Btn_InputRmsPm_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_RMSPara.Text, out int rmsPm))
            {
                MessageBox.Show("RMS參數格式無效");
                return;
            }

            thresholds.RMSPm = rmsPm;
            InputThresholds?.Invoke(this, thresholds);
        }

        private void Btn_InputSmoothPm_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_SmoothPara.Text, out int smoothPm))
            {
                MessageBox.Show("Smooth參數格式無效");
                return;
            }

            thresholds.SmoothPm = smoothPm;

            InputThresholds?.Invoke(this, thresholds);
            this.Close();

        }
    }
}
