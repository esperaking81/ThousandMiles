using System.Collections.Generic;
using UnityEngine;

namespace Domain.Models
{
    public class Game
    {
        public Game(Deck deck)
        {
            Players = new List<Player> { new("You", true), new("AI") };
            Deck = deck;
            DiscardPile = new DiscardPile();
            Direction = PlayDirection.Clockwise;
            State = GameState.WaitingForPlayers;
        }

        // --- Players ---
        public List<Player> Players { get; }
        public Player CurrentPlayer => Players[CurrentPlayerIndex];
        public int CurrentPlayerIndex { get; private set; }

        // --- Deck & Discard ---
        public Deck Deck { get; }
        public CardPile DiscardPile { get; private set; }

        // --- Game Flow ---
        public GameState State { get; private set; }
        public PlayDirection Direction { get; private set; }
        public int RoundNumber { get; private set; }

        // --- Optional: Score Tracking ---
        public Dictionary<Player, int> Scores { get; private set; }

        public void StartGame()
        {
            Debug.Log("Game started.");

            Scores = new Dictionary<Player, int>();
            CurrentPlayerIndex = 0;

            foreach (var player in Players) Scores[player] = 0;

            // for player in game, add a card to hand
            for (var i = 0; i < 6; i++)
                foreach (var player in Players)
                    DealCard(player);
        }

        private void DealCard(Player player)
        {
            var card = Deck.DrawCard();
            player.AddCard(card);
        }

        public void RequestDrawCard()
        {
            if (!CanDraw(CurrentPlayer)) return;

            DealCard(CurrentPlayer);
        }

        private bool CanDraw(Player player)
        {
            return player.Hand.Count < 7;
        }
    }

    public enum GameState
    {
        WaitingForPlayers,
        Starting,
        PlayerTurn,
        Scoring,
        Finished
    }

    public enum PlayDirection
    {
        Clockwise,
        CounterClockwise
    }
}