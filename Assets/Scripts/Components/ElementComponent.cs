using DefaultNamespace;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Components
{
    public class ElementComponent : MonoBehaviour, IPointerClickHandler
    {
        [field:SerializeField] public ElementType Type { get; private set; }
        [field:SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Supyrb.Signals.Get<ClickElementSignal>().Dispatch(this);
        }
    }
}