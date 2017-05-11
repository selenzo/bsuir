using System;
using System.Linq;
using System.Windows.Forms;
using Saimm2.RandomMethods;

namespace Saimm2
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
			delMathLabel.Text = "\u03C3";
			mLabel.Text = "M";
			dLabel.Text = "D";
			methodsList.SelectedIndex = 0;
			mTb.Text = uint.MaxValue.ToString();
		}

		private void ShowAdditionalParam(string[] labels, int count)
		{
			if (count == 0) additionalParamsBox.Hide(); else additionalParamsBox.Show();
			var controls = additionalParamsBox.Controls.OfType<Control>().ToList();
			controls.ForEach(c => c.Hide());

			for (int i = 1; i <= count; i++)
			{
				var label = controls.First(c => c.Name == string.Format("additionalParam{0}_label", i));
				label.Text = labels[i - 1];
				label.Show();

				var tb = controls.First(c => c.Name == string.Format("additionalParam{0}_Tb", i));
				tb.Text = "";
				tb.Show();
			}
		}

		private IDistribution GetMethod(int n)
		{
			var x0 = int.Parse(xTb.Text);
			var a = int.Parse(aTb.Text);
			var c = int.Parse(cTb.Text);
			var m = uint.Parse(mTb.Text);

			switch (methodsList.SelectedIndex)
			{
				case 0: return new LemerDistribution(x0, a, c, m, n);
				case 1: return new UniformDistribution(x0, a, c, m, n, additionalParam1_Tb.Text.GetDouble(), additionalParam2_Tb.Text.GetDouble());
				case 2: return new SimpsonDistribution(x0, a, c, m, n, additionalParam1_Tb.Text.GetDouble(), additionalParam2_Tb.Text.GetDouble());
				case 3: return new ExponentialDistribution(x0, a, c, m, n, additionalParam1_Tb.Text.GetDouble());
				case 4: return new GammaDistribution(x0, a, c, m, n, additionalParam1_Tb.Text.GetDouble(), additionalParam2_Tb.Text.GetDouble());
				case 5: return new GauseDistribution(x0, a, c, m, n, additionalParam1_Tb.Text.GetDouble(), additionalParam2_Tb.Text.GetDouble());
				case 6: return new TtriangularDistribution(x0, a, c, m, n, additionalParam1_Tb.Text.GetDouble(), additionalParam2_Tb.Text.GetDouble());
				default: return new LemerDistribution(x0, a, c, m, n);
			}
		}

		private void computeBtn_Click(object sender, EventArgs e)
		{
			var N = int.Parse(NTb.Text);

			var method = GetMethod(N);
			var table = method.Generate();

			valL.DataSource = table;

			var result = method.Compute();

			MathTb.Text = result.M.ToString();
			dTb.Text = result.D.ToString();
			deltMathTb.Text = result.S.ToString();

			var n = 10;
			var a = Math.Floor(table.Min());
			var b = Math.Ceiling(table.Max());
			var h = (b - a) / n;

			a -= h;
			b += h;

			chart.Series[0].Points.Clear();

			for (double i = a; i < b; i += h)
			{
				chart.Series[0].Points.AddXY(i, table.Count(d => d >= i && d <= i + h) / (double)N);
			}

			int k = 0;

			for (int i = 0; i < table.Count / 2; i++)
			{
				if (table.Skip(i * 2).Take(2).Sum(el => Math.Pow(el, 2)) < 1)
					k++;
			}

			pTb.Text = (2.0 * k / N).ToString();

			aperiodTb.Text = result.Aperiod.ToString();
			periodTb.Text = result.Period.ToString();
		}

		private void methodsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (methodsList.SelectedIndex)
			{
				case 0:
					ShowAdditionalParam(new[] { "" }, 0);
					break;

				case 1:
					ShowAdditionalParam(new[] { "a:", "b:" }, 2);
					break;

				case 2:
					ShowAdditionalParam(new[] { "a:", "b:" }, 2);
					break;

				case 3:
					ShowAdditionalParam(new[] { "\u03BB" }, 1);
					break;

				case 4:
					ShowAdditionalParam(new[] { "\u03BB", "\u03B7" }, 2);
					break;

				case 5:
					ShowAdditionalParam(new[] { "m", "\u03C3" }, 2);
					break;

				case 6:
					ShowAdditionalParam(new[] { "a:", "b:" }, 2);
					break;
			}
		}
	}
}
