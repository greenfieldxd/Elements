using System;
using DefaultNamespace;
using DG.Tweening;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Components
{
    public class CellComponent : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private ElementType type;
        [SerializeField] private int spriteLayerIndex;

        public ElementType Type => type;
        public ElementComponent Element { get; private set; }

        public void SetElement(ElementComponent elementComponent)
        {
            Element = elementComponent;
            Element.SpriteRenderer.sortingOrder = spriteLayerIndex;
            var trElement = Element.transform;
            trElement.SetParent(transform);
            trElement.DOLocalMove(Vector2.zero, 0.1f);
        }

        public void Clear()
        {
            Element = null;
        }
        
        public void SetSpriteLayer(int value)
        {
            spriteLayerIndex = value;
        }

        private Color GetGizmosColor()
        {
            switch (type)
            {
                case ElementType.None:
                    return Color.gray;
                
                case ElementType.Fire:
                    return Color.red;
                
                case ElementType.Water:
                    return Color.blue;
            }
            return Color.gray;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            Supyrb.Signals.Get<ClickCellSignal>().Dispatch(this);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = GetGizmosColor();
            Gizmos.DrawCube(transform.position, Vector2.one);
        }
    }
}
