using Components;
using Core;
using Signals;
using UnityEngine;

namespace Systems
{
    public class ElementsMoveSystem : GameSystem
    {
        public override void OnInit()
        {
            Supyrb.Signals.Get<SwipeSignal>().AddListener(TryMoveElements);
        }

        private void TryMoveElements(SwipeType swipeType)
        {
            if (Data.currentClickedCell.Element != null)
            {
                Move(swipeType);
            }
            
            Data.currentClickedCell = null;
        }

        private void Move(SwipeType swipeType)
        {
            var origin = Vector2.zero;
            
            switch (swipeType)
            {
                case SwipeType.Up:
                    origin = Data.currentClickedCell.transform.position + Vector3.up;
                    break;
                
                case SwipeType.Down:
                    origin = Data.currentClickedCell.transform.position + Vector3.down;
                    break;
                
                case SwipeType.Left:
                    origin = Data.currentClickedCell.transform.position + Vector3.left;
                    break;
                
                case SwipeType.Right:
                    origin = Data.currentClickedCell.transform.position + Vector3.right;
                    break;
            }
            
            var hit = Physics2D.Raycast(origin, Vector2.zero);
            
            if (hit.transform != null)
            {
                var cellToSwap = hit.transform.GetComponent<CellComponent>();

                if (cellToSwap.Element != null)
                {
                    var elementToSwap = cellToSwap.Element;
                    var elementClicked = Data.currentClickedCell.Element;
                    Data.currentClickedCell.SetElement(elementToSwap);
                    cellToSwap.SetElement(elementClicked);
                }
                else if (swipeType == SwipeType.Up && cellToSwap.Element != null)
                {
                    var elementToSwap = cellToSwap.Element;
                    var elementClicked = Data.currentClickedCell.Element;
                    Data.currentClickedCell.SetElement(elementToSwap);
                    cellToSwap.SetElement(elementClicked);
                }
                else if (swipeType != SwipeType.Up)
                {
                    var elementClicked = Data.currentClickedCell.Element;
                    Data.currentClickedCell.Clear();
                    cellToSwap.SetElement(elementClicked);
                }
            }
        }
    }
}