using System;

namespace DataGridSum
{

  class MoneyEntry
  {

    public string AccountID { get; set; }

    public string Summary { get; set; }
    
    public decimal Debet { get; set; }

    public decimal Credit { get; set; }

    public DateTime Date { get; set; }

  }

}