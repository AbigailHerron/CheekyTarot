using System;
using System.Windows;
using System.IO;
using System.Text.Json;

namespace CheekyTarot
{
    class TarotCard
    {
        public string Name { get; set; }
        public string Upright { get; set; }
        public string Reversed { get; set; }
        public string ImagePath { get; set; }
    }


    public partial class MainWindow : Window
    {
        Random rand = new Random();
        TarotCard[] cards;


        public MainWindow()
        {
            InitializeComponent();
            LoadCards();
        }

        private void LoadCards()
        {
            string json = File.ReadAllText("cards.json");
            cards = JsonSerializer.Deserialize<TarotCard[]>(json);
        }

        private void DrawCard_Click(object sender, RoutedEventArgs e)
        {
            int index = rand.Next(cards.Length);
            bool isReversed = rand.Next(2) == 0;

            var card = cards[index];

            if (isReversed)
            {
                CardText.Text = card.Name + " (Reversed)";
                MeaningText.Text = card.Reversed;
            }
            else
            {
                CardText.Text = card.Name;
                MeaningText.Text = card.Upright;
            }
        }
    }
}