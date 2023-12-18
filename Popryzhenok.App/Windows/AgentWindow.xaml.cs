using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Popryzhenok.App.Models;

namespace Popryzhenok.App.Windows
{
    /// <summary>
    /// Логика взаимодействия для AgentWindow.xaml
    /// </summary>
    public partial class AgentWindow : Window
    {
        private Agent Agent { get; set; }

        private AgentListWindow PreviousWindow { get; set; }

        public AgentWindow(AgentListWindow previousWindow, Agent agent = null)
        {
            InitializeComponent();

            Agent = agent;
            PreviousWindow = previousWindow;

            var flirtList = new List<string>
            {
                "ЗАО",
                "МКК",
                "МФО",
                "ОАО",
                "ООО",
                "ПАО"
            };

            SelectType.ItemsSource = flirtList.ToList();

            if (Agent != null)
            {
                FillData();
            }
        }

        private void FillData()
        {
            NameBox.Text = Agent.Name;
            SelectType.SelectedItem = Agent.Type;
            PriorityBox.Text = Agent.Priority.ToString();
            AddressBox.Text = Agent.Address.ToString();
            DirectorBox.Text = Agent.DirectorFullName;
            MailBox.Text = Agent.Email;
            INNBox.Text = Agent.Inn;
            PhoneBox.Text = Agent.Phone;
            KPPBox.Text = Agent.Pkk;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new ApplicationDbContext())
            {
                if (Agent == null)
                {
                    var agent = new Agent
                    {
                        Name = NameBox.Text,
                        Type = SelectType.SelectedItem.ToString(),
                        Priority = Convert.ToInt32(PriorityBox.Text),
                        ImagePath = null,
                        Address = AddressBox.Text,
                        DirectorFullName = DirectorBox.Text,
                        Email = MailBox.Text,
                        Inn = INNBox.Text,
                        Phone = PhoneBox.Text,
                        Pkk = KPPBox.Text
                    };
                    context.Agents.Add(agent);
                    context.SaveChanges();
                }
                else
                {
                    var updatedUser = context.Agents.FirstOrDefault(a => a.Id == Agent.Id);
                    updatedUser.Name = NameBox.Text;
                    updatedUser.Type = SelectType.SelectedItem.ToString();
                    updatedUser.Priority = Convert.ToInt32(PriorityBox.Text);
                    updatedUser.Address = AddressBox.Text;
                    updatedUser.DirectorFullName = DirectorBox.Text;
                    updatedUser.Email = MailBox.Text;
                    updatedUser.Inn = INNBox.Text;
                    updatedUser.Phone = PhoneBox.Text;
                    updatedUser.Pkk = KPPBox.Text;
                    updatedUser.ImagePath = null;
                    context.SaveChanges();
                }
            }

            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Agent == null)
            {
                Hide();
            }
            else
            {
                using (var context = new ApplicationDbContext())
                {
                    var deletedUser = context.Agents.FirstOrDefault(a => a.Id == Agent.Id);
                    context.Agents.Remove(deletedUser);
                    context.SaveChanges();

                    PreviousWindow.ListAgents.ItemsSource = context.Agents.ToList().Skip(0).Take(10);
                    Hide();
                }
            }
        }
    }
}
