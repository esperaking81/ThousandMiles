using Data;
using Domain.Models;
using Presentation.Controllers;
using Presentation.Presenters;
using UnityEngine;

namespace Presentation.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private DeckData deckData;
        [SerializeField] private GamePresenter gamePresenter;

        private Game _game;

        public void Start()
        {
            Deck deck = new(DeckController.InitializeDeck(deckData));

            _game = new Game(deck);

            Debug.Log($"Game started with {deck.Cards.Count} cards!");

            gamePresenter.Bind(_game);

            _game.StartGame();
        }

        public void OnDestroy()
        {
            gamePresenter.UnBind(_game);
        }
    }
}