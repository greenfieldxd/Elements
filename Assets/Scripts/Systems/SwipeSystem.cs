using Components;
using Core;
using Signals;
using UnityEngine;

namespace Systems
{
    public class SwipeSystem : GameSystem
    {
        [SerializeField] private float SWIPE_THRESHOLD = 20f;

        private Vector2 fingerDownPos;
        private Vector2 fingerUpPos;

        public override void OnUpdate()
        {
            if (!Data.haveInput) return;
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                fingerUpPos = Input.mousePosition;
                fingerDownPos = Input.mousePosition;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                fingerDownPos = Input.mousePosition;
                DetectSwipe();
            }
        }

        void DetectSwipe()
        {
            if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
            {
                if (fingerDownPos.y - fingerUpPos.y > 0)
                {
                    OnSwipeUp();
                }
                else if (fingerDownPos.y - fingerUpPos.y < 0)
                {
                    OnSwipeDown();
                }

                fingerUpPos = fingerDownPos;
            }
            else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
            {
                if (fingerDownPos.x - fingerUpPos.x > 0)
                {
                    OnSwipeRight();
                }
                else if (fingerDownPos.x - fingerUpPos.x < 0)
                {
                    OnSwipeLeft();
                }

                fingerUpPos = fingerDownPos;
            }
        }

        float VerticalMoveValue()
        {
            return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
        }

        float HorizontalMoveValue()
        {
            return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
        }

        void OnSwipeUp()
        {
            Supyrb.Signals.Get<SwipeSignal>().Dispatch(SwipeType.Up);
        }

        void OnSwipeDown()
        {
            Supyrb.Signals.Get<SwipeSignal>().Dispatch(SwipeType.Down);
        }

        void OnSwipeLeft()
        {
            Supyrb.Signals.Get<SwipeSignal>().Dispatch(SwipeType.Left);
        }

        void OnSwipeRight()
        {
            Supyrb.Signals.Get<SwipeSignal>().Dispatch(SwipeType.Right);
        }
    }
}