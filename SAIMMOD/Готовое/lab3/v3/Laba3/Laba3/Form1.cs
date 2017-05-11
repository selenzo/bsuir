using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        private Immitation immitation;
        private LehmerRandom random;
        private Graph graph;
        private IDictionary<State, int> states;

        public Form1()
        {
            InitializeComponent();

            graph = new Graph();
            random = new LehmerRandom(UInt64.Parse("1664525"), UInt64.Parse("4294967296"), UInt64.Parse("1013904223"));
            immitation = new Immitation(graph, random, new State("0000"));
            states = new Dictionary<State, int>();

            OutputLastState();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            immitation.reset();
            OutputLastState();

            int count = Int32.Parse("1000");
            for (int i = 0; i < count; i++)
            {
                immitation.iteration();
                OutputLastState();
            }
        }

        private void OutputLastState()
        {
            double tmp = 0;
            if (dataGridView1.Rows.Count > immitation.IterationsCount)
            {
                dataGridView1.Rows.Clear();
                states.Clear();
            }
            double rand = immitation.LastRandom;
            State state = immitation.CurrentState;
            IReadOnlyDictionary<State, double> transitions = graph.getTransitions(state);
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);
            if (rand > 0 && rand <= 1)
            {
                row.Cells[0].Value = rand;
            }

            row.Cells[1].Value = state;
            foreach (KeyValuePair<State, double> pair in transitions)
            {
                tmp += pair.Value;
                row.Cells[2].Value += pair.Key + " = " + pair.Value + " (" + tmp + "); ";
            }
            dataGridView1.Rows.Add(row);

            // Сохраняем состояние и количество его наступлений
            if (!states.ContainsKey(state))
            {
                states.Add(state, 0);
            }
            states[state]++;

            // Вычисляем вероятность отказа
            double P1 = 1 - (calcP(new State("0000")) + calcP(new State("0001")));
            double P2 = 0.36;
            double A = P1 * P2;
            double Q = A / 0.5;
            double Potk = 1 - Q;
            textBox1.Text = Potk.ToString("0.####");

        }

        private double calcP(State state)
        {
            int count = 0;
            if (states.ContainsKey(state))
            {
                count = states[state];
            }
            return (double) count / (immitation.IterationsCount + 1);
        }
    }
}
