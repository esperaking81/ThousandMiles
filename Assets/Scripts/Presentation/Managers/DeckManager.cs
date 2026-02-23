using System;
using UnityEngine;

namespace Presentation.Managers
{
    public class DeckManager : MonoBehaviour
    {
        public void OnMouseDown()
        {
            OnDeckClicked?.Invoke();
        }

        public event Action OnDeckClicked;
    }
}