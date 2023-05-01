using Components;
using NaughtyAttributes;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu (menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [BoxGroup("Elements configs")] 
        [SerializeField] private ElementConfig[] elementConfigs;
        
        [BoxGroup("Levels")]
        [SerializeField] private LevelComponent[] levels;

        public ElementConfig[] ElementConfigs => elementConfigs;
        public LevelComponent[] Levels => levels;
    }
}
