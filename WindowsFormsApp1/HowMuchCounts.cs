using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIAnalyzer
{
    public partial class HowMuchCounts : Form
    {
        public Engine engine = null;
        public HowMuchCounts(Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
            ToggleExtraMDEnabling(checkBoxExtraMD.Checked);
            UpdateMaxCount();
        }
        void ToggleExtraMDEnabling(bool State)
        {
            numericUpDownExtraCounts.Enabled = State;
            numericUpDownFreq.Enabled = State;
            numericUpDownMaxTrials.Enabled = State;
        }
        private void checkBoxExtraMD_CheckedChanged(object sender, EventArgs e)
        {
            ToggleExtraMDEnabling(checkBoxExtraMD.Checked);
            UpdateMaxCount();
        }

        private void checkBoxGetSequences_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxGetSequences.Checked)
            {
                checkBoxExtraMD.Enabled = false;
                ToggleExtraMDEnabling(false);
                textBoxMaxCounts.Enabled = false;
            }
            else
            {
                checkBoxExtraMD.Enabled = true;
                ToggleExtraMDEnabling(checkBoxExtraMD.Checked);
                textBoxMaxCounts.Enabled = true;
            }
        }
        private void UpdateMaxCount()
        {
            var dExtraCounts = (double)numericUpDownExtraCounts.Value;
            var dExtraFreq = (double)numericUpDownFreq.Value;
            var dMsExtraMD = (checkBoxExtraMD.Checked)?dExtraCounts * 1000 / dExtraFreq:0;
            var Trials = engine.GetTrials();
            if(!checkBoxGetSequences.Checked&&(Trials.Count>0))
            {
                var MaxCount = Trials.Select(i => i.ExtendTrial(dMsExtraMD)).Select(i => i.intMotionEndRowNum - i.intMotionStartRowNum + 1).Max();
                textBoxMaxCounts.Text = Convert.ToString(MaxCount);
            }
        }
        private void numericUpDownExtraCounts_ValueChanged(object sender, EventArgs e)
        {
            UpdateMaxCount();
        }

        private void numericUpDownFreq_ValueChanged(object sender, EventArgs e)
        {
            UpdateMaxCount();
        }
    }
}
