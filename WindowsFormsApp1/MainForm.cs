using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.IO;

namespace MIAnalyzer
{
    public partial class MainForm : Form
    {
        Engine engine;
        Trial tr1=null;
        GraphParams gp1;
        Trial tr2=null;
        GraphParams gp2;
        BindingList<Trial> trials = new BindingList<Trial>();
        class GraphParams
        {
            public class BoolProperty
            {
                public static explicit operator bool(BoolProperty i)
                {
                   return i.IsChecked;
                }
                bool _isChecked;
                public BoolProperty(string Name, bool b=false)
                {
                    this.Name=Name;
                    _isChecked = b;
                }
                public string Name { get; set; }
                public bool IsChecked
                {
                    get { return _isChecked; }
                    set { _isChecked = value; }
                }
            }
            public Color colorACCX;
            public Color colorACCY;
            public Color colorACCZ;
            public Color colorWX;
            public Color colorWY;
            public Color colorWZ;
            public BoolProperty bDrawACCX= new BoolProperty("ACCX", true);
            public BoolProperty bDrawACCY = new BoolProperty("ACCY");
            public BoolProperty bDrawACCZ = new BoolProperty("ACCZ");
            public BoolProperty bDrawWX = new BoolProperty("WX");
            public BoolProperty bDrawWY = new BoolProperty("WY");
            public BoolProperty bDrawWZ = new BoolProperty("WZ");
            public GraphParams()
            {

            }
            public List<BoolProperty> GetBools()
            {
                var res = new List<BoolProperty>();
                res.Add(bDrawACCX);
                res.Add(bDrawACCY);
                res.Add(bDrawACCZ);
                res.Add(bDrawWX);
                res.Add(bDrawWY);
                res.Add(bDrawWZ);
                return res;
            }
        }
        void CreateGraphParams()
        {
            gp1 = new GraphParams();
            gp1.colorACCX = Color.Red;
            gp1.colorACCY = Color.OrangeRed;
            gp1.colorACCZ = Color.Orange;
            gp1.colorWX = Color.Yellow;
            gp1.colorWY = Color.Gold;
            gp1.colorWZ = Color.Brown;
            gp2 = new GraphParams();
            gp2.colorACCX = Color.LightGreen;
            gp2.colorACCY = Color.Green;
            gp2.colorACCZ = Color.Aqua;
            gp2.colorWX = Color.LightBlue;
            gp2.colorWY = Color.Blue;
            gp2.colorWZ = Color.DarkBlue;
        }
        void CreateEngine()
        {
            engine = new Engine();
        }
        

        void InitGraphPanel(Panel p, GraphParams gp)
        {
            var lBools = gp.GetBools();
            var cbl = new List<CheckBox>();
            foreach(var i in p.Controls)
            {
                if(i.GetType()==typeof(CheckBox))
                {
                    cbl.Add((CheckBox)i);
                }
            }
            cbl.Sort(((i,j)=>i.TabIndex.CompareTo(j.TabIndex)));
            var graphTypeCheckBoxPairs = lBools.Zip(cbl, (i, j) => Tuple.Create(i, j));
            foreach(var t in graphTypeCheckBoxPairs)
            {
                t.Item2.Text = t.Item1.Name;
                //t.Item2.Checked = t.Item1.IsChecked;
                t.Item2.DataBindings.Add("Checked", t.Item1,"IsChecked");
                t.Item2.CheckedChanged += myCheckBoxCheckedChanged;
            }
        }

        private void myCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            ((CheckBox)sender).DataBindings[0].WriteValue();
            RedrawGraphs();
        }

        public MainForm()
        {
            InitializeComponent();
            listBoxTrials1.DataSource = trials;
            CreateGraphParams();
            InitGraphPanel(panelGraphControl1, gp1);
            InitGraphPanel(panelGraphControl2, gp2);
            CreateEngine();
            RedrawGraphs();
        }
        private void updateListOfTrials()
        {
            var trialsFromEngine = engine.GetTrials();
            this.trials.Clear();
            foreach(var trial in trialsFromEngine)
            {
                this.trials.Add(trial);
            }
        }

        private void listBoxTrials1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DrawDataPointGraph(List<DataPoint> list, Color color, PlotModel model)
        {
            var lineSeries = new LineSeries()
            {
                Color = OxyColor.FromArgb(color.A,
                color.R,
                color.G,
                color.B)
            };
            lineSeries.Points.AddRange(list);
            model.Series.Add(lineSeries);
        }
        private void DrawTrial(GraphParams graphParams, Trial trial, PlotModel pm)
        {
            if(trial!=null)
            {
                if((bool)graphParams.bDrawACCX)
                {
                    DrawDataPointGraph(trial.ACCX.Select(i => new DataPoint(i.Item1, i.Item2)).ToList(), graphParams.colorACCX, pm);
                }
                if ((bool)graphParams.bDrawACCY)
                {
                    DrawDataPointGraph(trial.ACCY.Select(i => new DataPoint(i.Item1, i.Item2)).ToList(), graphParams.colorACCY, pm);
                }
                if ((bool)graphParams.bDrawACCZ)
                {
                    DrawDataPointGraph(trial.ACCZ.Select(i => new DataPoint(i.Item1, i.Item2)).ToList(), graphParams.colorACCZ, pm);
                }
                if ((bool)graphParams.bDrawWX)
                {
                    DrawDataPointGraph(trial.WX.Select(i => new DataPoint(i.Item1, i.Item2)).ToList(), graphParams.colorWX, pm);
                }
                if ((bool)graphParams.bDrawWY)
                {
                    DrawDataPointGraph(trial.WY.Select(i => new DataPoint(i.Item1, i.Item2)).ToList(), graphParams.colorWY, pm);
                }
                if ((bool)graphParams.bDrawWZ)
                {
                    DrawDataPointGraph(trial.WZ.Select(i => new DataPoint(i.Item1, i.Item2)).ToList(), graphParams.colorWZ, pm);
                }
            }
        }
        private void RedrawGraphs()
        {
            var pm = new PlotModel()
            {
                Title = "Motion Graphs",
                Subtitle = "Plot Window",
                PlotType = PlotType.XY,
                Background = OxyColors.White
            };
            DrawTrial(gp1, tr1, pm);

            DrawTrial(gp2, tr2, pm);

            plotMain.Model = pm;
        }
        private void panelGraphControl1_DragDrop(object sender, DragEventArgs e)
        {
                tr1 = (Trial)e.Data.GetData(typeof(Trial));
                RedrawGraphs();
        }

        private void panelGraphControl2_DragDrop(object sender, DragEventArgs e)
        {
                tr2 = (Trial)e.Data.GetData(typeof(Trial));
            RedrawGraphs();
        }

        private void listBoxTrials1_MouseDown(object sender, MouseEventArgs e)
        {
            if(listBoxTrials1.SelectedItem!=null)
            {
                listBoxTrials1.DoDragDrop(listBoxTrials1.SelectedItem, DragDropEffects.Copy | DragDropEffects.Move);

            }
        }

        private void panelGraphControl1_DragOver(object sender, DragEventArgs e)
        {
            ;
        }

        private void panelGraphControl1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            ;
        }

        private void panelGraphControl1_DragEnter(object sender, DragEventArgs e)
        {
            
            if(true)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void panelGraphControl2_DragEnter(object sender, DragEventArgs e)
        {

            if (true)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void scanSavedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //engine.ScanSavedDataFolder(@"C:\Users\Максим\Downloads\Saved_Data-example");
            //updateListOfTrials();
            //return;
            if (scanSavedDataToolStripMenuItem.DropDown.IsDropDown)
                scanSavedDataToolStripMenuItem.DropDown.Close();
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                engine.ScanSavedDataFolder(fbd.SelectedPath);
                updateListOfTrials();
            }
        }

        private void exportTrialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cdg = new HowMuchCounts(engine);
            int counts = -1;
            if (cdg.ShowDialog() == DialogResult.OK)
            {
                var tb = cdg.Controls.Find("textBoxInput", true);
                if(tb[0].Text.ToArray().All(i=>"0123456789".Contains(i)))
                {
                    try
                    {
                        counts = Convert.ToInt32(tb[0].Text);
                    }
                    catch
                    {
                        counts = -1;
                    }
                }
            }
            else
                return;
            var fsd = new SaveFileDialog();
            fsd.Title = "Save Motion Data from all trials into csv file";
            fsd.Filter = "Csv Files(*.csv)|*.csv|Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            fsd.OverwritePrompt = true;
            fsd.AddExtension = true;
            if (fsd.ShowDialog() == DialogResult.OK)
            {
                var getSequences = ((CheckBox)cdg.Controls.Find("checkBoxGetSequences", true)[0]).Checked;
                var emptySeq = true;//((CheckBox)cdg.Controls.Find("checkBoxEmptySeq", true)[0]).Checked;
                var bAddExtraMD = !getSequences && ((CheckBox)cdg.Controls.Find("checkBoxExtraMD", true)[0]).Checked;
                var dExtraCounts = (double)((NumericUpDown)cdg.Controls.Find("numericUpDownExtraCounts", true)[0]).Value;
                var dFreq = (double)((NumericUpDown)cdg.Controls.Find("numericUpDownFreq", true)[0]).Value;
                var intMaxTrials = (int)((NumericUpDown)cdg.Controls.Find("numericUpDownMaxTrials", true)[0]).Value;
                var strDataToWrite = engine.GetTrialsCSV(counts, getSequences, counts<=0, emptySeq, bAddExtraMD, dExtraCounts*1000/dFreq, intMaxTrials);
                using (var fs = new FileStream(fsd.FileName, FileMode.Create))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                            sw.WriteLine(strDataToWrite[0]);
                    }
                }

                fsd.Title = "Save Users from all trials into csv file";
                if (fsd.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = new FileStream(fsd.FileName, FileMode.Create))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(strDataToWrite[1]);
                        }
                    }
                }
            }
        }

        private void addExtraMD1SecToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (scanSavedDataToolStripMenuItem.DropDown.IsDropDown)
                scanSavedDataToolStripMenuItem.DropDown.Close();

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxTrials1.Update();
            engine.ClearTrialsAndSequences();
        }
    }
}
