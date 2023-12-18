using Popryzhenok.App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;

namespace Popryzhenok.App.Windows
{
    /// <summary>
    /// Логика взаимодействия для AgentListWindow.xaml
    /// </summary>
    public partial class AgentListWindow : Window
    {
        public int Page { get; set; }

        public int TotalPageCount { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public List<Agent> Result { get; set; }

        public AgentListWindow()
        {
            InitializeComponent();
            Page = Convert.ToInt32(PageNumber.Content.ToString());
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

            using (var context = new ApplicationDbContext())
            {
                double count = context.Agents.Count();
                ListAgents.ItemsSource = context.Agents.ToList().Skip(Page - 1).Take(10);
                TotalPageCount = (int)Math.Round(count / 10.0);
            }
        }

        private void SearchTextbox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ExecuteFilter();
        }

        private void UpdateListAgents(List<Agent> list)
        {
            ListAgents.ItemsSource = list.Skip(Page - 1).Take(10);
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExecuteFilter();
        }

        private void FilterComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExecuteFilter();
        }

        public void ExecuteFilter()
        {
            if(SortComboBox != null && FilterComboBox != null)
            {
                var sortText = SortComboBox.SelectedItem as string;
                var filterText = FilterComboBox.SelectedItem as string;

                Result = new List<Agent>();

                using (var context = new ApplicationDbContext())
                {
                    Agents = context.Agents;
                    Result = Agents.ToList();

                    if (sortText != null)
                    {
                        switch (sortText)
                        {
                            case "Наименование по возрастанию":
                                Result = Result.OrderBy(x => x.Name).ToList();
                                break;
                            case "Наименование по убыванию":
                                Result = Result.OrderByDescending(x => x.Name).ToList();
                                break;
                            case "Приоритет по возрастанию":
                                Result = Result.OrderBy(x => x.Priority).ToList();
                                break;
                            case "Приоритет по убыванию":
                                Result = Result.OrderByDescending(x => x.Priority).ToList();
                                break;
                        }
                    }

                    if (filterText != null)
                    {
                        switch (filterText)
                        {
                            case "ЗАО":
                                Result = Result.Where(x => x.Type == filterText).ToList();
                                break;
                            case "МКК":
                                Result = Result.Where(x => x.Type == filterText).ToList();
                                break;
                            case "МФО":
                                Result = Result.Where(x => x.Type == filterText).ToList();
                                break;
                            case "ОАО":
                                Result = Result.Where(x => x.Type == filterText).ToList();
                                break;
                            case "ООО":
                                Result = Result.Where(x => x.Type == filterText).ToList();
                                break;
                            case "ПАО":
                                Result = Result.Where(x => x.Type == filterText).ToList();
                                break;
                        }
                    }

                    if (SearchTextbox.Text != null)
                    {
                        var text = SearchTextbox.Text;

                        if (text != "Введите для поиска")
                        {

                            Result = Result.Where(x => x.Name.Contains(text)).ToList();
                        }
                    }
                }

                UpdateListAgents(Result);
            }}

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            if (Page > TotalPageCount)
            {
                MessageBox.Show("Дохуя листаешь");
                return;
            }
            Page++;

            PageNumber.Content = Page;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                ListAgents.ItemsSource = context.Agents.ToList().Skip(Page - 1).Take(10);
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            if (Page <= 1)
            {
                MessageBox.Show("Ошибка");
            }
            Page--;

            PageNumber.Content = Page;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                ListAgents.ItemsSource = context.Agents.ToList().Skip(Page - 1).Take(10);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AgentWindow(this);
            window.Show();
        }

        private void ListAgentsGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var agent = (sender as Grid)?.DataContext as Agent;

            var window = new AgentWindow(this, agent);
            window.Show();
        }
    }
}
