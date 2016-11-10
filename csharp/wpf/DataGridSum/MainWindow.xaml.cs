using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DataGridSum
{

  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      InitializeComponent();
    }
    
    private void Window_Initialized(object sender, EventArgs e)
    {
      // random data
      var rnd = new Random(DateTime.Now.Millisecond);
      var summary = new string[] { "Staff salary", "Taxes", "Buckwheat", "Fuel", "New Year celebration", "Software", "Anything" };
      var entries = new List<MoneyEntry>();
      
      for (int i = 0; i < 1000000; i++)
      {
        entries.Add(new MoneyEntry
        {
          AccountID = String.Format("{0}-{1}", Guid.NewGuid().ToString("n").Substring(0, 2).ToUpper(), rnd.Next(100, 999)),
          Date = DateTime.Now.AddDays(-rnd.Next(1, 1000)),
          Credit = rnd.Next(100, 999999),
          Debet = rnd.Next(100, 999999),
          Summary = summary[rnd.Next(0, summary.Length)]
        });
      }

      dataGrid.ItemsSource = entries;
    }

    private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
      var debit = dataGrid.SelectedItems.OfType<MoneyEntry>().Sum(entry => entry.Debet);
      var credit = dataGrid.SelectedItems.OfType<MoneyEntry>().Sum(entry => entry.Credit);
      this.Title = String.Format("Debit: {0:###,###,###} ₽; Credit: {1:###,###,###} ₽", debit, credit);
    }

  }

}