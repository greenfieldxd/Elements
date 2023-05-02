using Components;
using Core;
using Signals;
using UnityEngine;

namespace Systems
{
    public class CellClickSystem : GameSystem
    {
        public override void OnInit()
        {
            Supyrb.Signals.Get<ClickCellSignal>().AddListener(ElementClick);
        }

        private void ElementClick(CellComponent cell)
        {
            Data.currentClickedCell = cell;
        }
    }
}