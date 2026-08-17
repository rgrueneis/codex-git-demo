using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TextManager;

public partial class MainWindow : Window
{
  public ObservableCollection<string> Items { get; } = [];

  public MainWindow()
  {
    InitializeComponent();
    DataContext = this;
    TextEntry.Focus();
  }

  private void AddButton_Click(object? _, RoutedEventArgs e)
  {
    _ = e;
    AddText();
  }

  private void TextEntry_KeyDown(object? _, KeyEventArgs e)
  {
    if (e.Key == Key.Enter) AddText();
  }

  private void DeleteButton_Click(object? _, RoutedEventArgs e)
  {
    _ = e;
    if (TextList.SelectedItem is string selectedText) Items.Remove(selectedText);
  }

  private void UpdateButton_Click(object? _, RoutedEventArgs e)
  {
    _ = e;
    if (TextList.SelectedIndex < 0) return;

    string text = TextEntry.Text.Trim();
    if (string.IsNullOrEmpty(text)) return;

    Items[TextList.SelectedIndex] = text;
    TextEntry.Clear();
    TextEntry.Focus();
  }

  private void TextList_SelectionChanged(object? _, System.Windows.Controls.SelectionChangedEventArgs e)
  {
    _ = e;
    if (TextList.SelectedItem is string selectedText) TextEntry.Text = selectedText;
  }

  private void AddText()
  {
    string text = TextEntry.Text.Trim();
    if (string.IsNullOrEmpty(text)) return;

    Items.Add(text);
    TextEntry.Clear();
    TextEntry.Focus();
  }
}
