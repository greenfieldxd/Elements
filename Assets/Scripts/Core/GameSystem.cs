using UnityEngine;

namespace Core
{
    public class GameSystem : MonoBehaviour
    {
        protected GameConfig Config;
        protected GameData Data;

        public void Set(GameConfig gameConfig, GameData data)
        {
            Config = gameConfig;
            Data = data;
        }
    
        public virtual void OnInit()
        {
        
        }
    
        public virtual void OnUpdate()
        {
        
        }
    
        public virtual void OnFixedUpdate()
        {
        
        }
    }
}
