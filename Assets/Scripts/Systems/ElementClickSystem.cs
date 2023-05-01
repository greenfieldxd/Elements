using Components;
using Core;
using Signals;
using UnityEngine;

namespace Systems
{
    public class ElementClickSystem : GameSystem
    {
        public override void OnInit()
        {
            Supyrb.Signals.Get<ClickElementSignal>().AddListener(ElementClick);
        }

        private void ElementClick(ElementComponent elementComponent)
        {
            Data.currentElementClicked = elementComponent;
            Debug.Log(Data.currentElementClicked.name);
        }
    }
}