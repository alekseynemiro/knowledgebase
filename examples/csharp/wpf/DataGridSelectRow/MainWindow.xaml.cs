using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DataGridSelectRow
{

  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Initialized(object sender, EventArgs e)
    {
      // add random data
      var questions = new List<Question>();

      questions.Add(new Question {
        Title = "How to select row in DataGrid by right mouse button click?",
        DateCreate = new DateTime(2016, 11, 7, 8, 18, 00),
        AuthorName = "vlad"
      });

      questions.Add(new Question {
        Title = "How to add a handler for mouse clicks?",
        DateCreate = new DateTime(2016, 11, 7, 20, 28, 00),
        AuthorName = "ivan"
      });

      questions.Add(new Question {
        Title = "How to learn to walk through walls?",
        DateCreate = new DateTime(2016, 11, 7, 20, 31, 00),
        AuthorName = "pupkin"
      });

      questions.Add(new Question
      {
        Title = "How to make an artificial intelligence?",
        DateCreate = new DateTime(2016, 11, 7, 20, 33, 00),
        AuthorName = "aleksey"
      });

      questions.Add(new Question
      {
        Title = "How to go to Mars in a box from under the refrigerator?",
        DateCreate = new DateTime(2016, 11, 7, 20, 35, 00),
        AuthorName = "max"
      });

      questions.Add(new Question
      {
        Title = "How to to rewrite Windows from scratch?",
        DateCreate = new DateTime(2016, 11, 7, 20, 42, 00),
        AuthorName = "chb"
      });

      questions.Add(new Question
      {
        Title = "How to make a somersault while writing code?",
        DateCreate = new DateTime(2016, 11, 7, 20, 42, 00),
        AuthorName = "artem"
      });

      dataGrid.ItemsSource = questions;
    }

    private void dataGrid_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.RightButton == MouseButtonState.Pressed)
      {
        var row = DataGridRow.GetRowContainingElement(e.OriginalSource as FrameworkElement);

        if (row != null)
        {
          // dataGrid.SelectedIndex = row.GetIndex();
          dataGrid.SelectedItem = row;
        }
      }
    }
  }

}