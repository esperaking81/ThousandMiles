using System.Collections.Generic;
using Presentation.Views;
using UnityEngine;
using UnityEngine.Splines;

namespace Presentation.Managers
{
    public class HandManager : MonoBehaviour
    {
        [SerializeField] private int maxHandSize = 7;
        [SerializeField] private SplineContainer splineContainer;

        private readonly List<CardView> _handCards = new();

        public void AddCard(CardView card)
        {
            _handCards.Add(card);
            RecalculateLayout(card);
        }

        public void RemoveCard(CardView card)
        {
            _handCards.Remove(card);
            RecalculateLayout(card);
        }

        private void RecalculateLayout(CardView newlyAdded = null)
        {
            var cardSpacing = 1f / maxHandSize; // Adjust as needed for visual spacing
            var firstCardPosition = 0.5f - cardSpacing * (_handCards.Count - 1) / 2; // Center the cards on the spline
            var spline = splineContainer.Spline;
            for (var i = 0; i < _handCards.Count; i++)
            {
                var targetPosition = firstCardPosition + i * cardSpacing;
                Vector3 splinePosition = spline.EvaluatePosition(targetPosition);
                Vector3 forward = spline.EvaluateTangent(targetPosition);
                Vector3 up = spline.EvaluateUpVector(targetPosition);
                var rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
                _handCards[i].transform.SetParent(transform);

                if (_handCards[i] == newlyAdded)
                    _handCards[i].MoveFromDeckTo(splinePosition, rotation);
                else
                    _handCards[i].MoveToLayout(splinePosition, rotation);
            }
        }
    }
}