using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Popryzhenok.App.Windows
{
    /// <summary>
    /// Логика взаимодействия для AgentListWindow.xaml
    /// </summary>
    public partial class AgentListWindow : Window
    {
        public AgentListWindow()
        {
            InitializeComponent();

            var sortList = new List<string>()
            {
                "Наимнование по возрастанию",
                "Наимнование по убываню",
                "Размер скидки по возрастанию",
                "Размер скидки по убыванию",
                "Приоритет по возрастанию",
                "Приоритет по убыванию"
            };

            SortComboBox.ItemsSource = sortList;

            var flirtList = new List<string>()
            {
                "ЗАО",
                "МКК",
                "МФО",
                "ОАО",
                "ООО",
                "ПАО"
            };

            FilterComboBox.ItemsSource = flirtList;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                ListAgents.ItemsSource = context.Agents.ToList();
            }
        }

        private void SearchTextbox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = SearchTextbox.Text;

            if (text != "Введите для поиска")
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    ListAgents.ItemsSource = context.Agents.Where(x => x.Name.Contains(text)).ToList();
                }
            }
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var text = SortComboBox.SelectedItem as string;
            if (text != "Сортировка")
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    switch (text)
                    {
                        case "Наимнование по возрастанию":
                            ListAgents.ItemsSource = context.Agents.OrderBy(x => x.Name).ToList();
                            break;
                        case "Наимнование по убываню":
                            ListAgents.ItemsSource = context.Agents.OrderByDescending(x => x.Name).ToList();
                            break;
                        case "Приоритет по возрастанию":
                            ListAgents.ItemsSource = context.Agents.OrderBy(x => x.Priority).ToList();
                            break;
                        case "Приоритет по убыванию":
                            ListAgents.ItemsSource = context.Agents.OrderByDescending(x => x.Priority).ToList();
                            break;
                    }
                }
            }
        }

        private void FilterComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var text = FilterComboBox.SelectedItem as string;
            if (text != "Фильтрация")
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    switch (text)
                    {
                        case "ЗАО":
                            ListAgents.ItemsSource = context.Agents.Where(x => x.Type == text).ToList();
                            break;
                        case "МКК":
                            ListAgents.ItemsSource = context.Agents.Where(x => x.Type == text).ToList();
                            break;
                        case "МФО":
                            ListAgents.ItemsSource = context.Agents.Where(x => x.Type == text).ToList();
                            break;
                        case "ОАО":
                            ListAgents.ItemsSource = context.Agents.Where(x => x.Type == text).ToList();
                            break;
                        case "ООО":
                            ListAgents.ItemsSource = context.Agents.Where(x => x.Type == text).ToList();
                            break;
                        case "ПАО":
                            ListAgents.ItemsSource = context.Agents.Where(x => x.Type == text).ToList();
                            break;
                    }
                }
            }
        }
    }
}
