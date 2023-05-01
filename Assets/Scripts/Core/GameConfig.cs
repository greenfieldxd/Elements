using Components;
using NaughtyAttributes;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu (menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [BoxGroup("Prefabs")] 
        [SerializeField] private ElementComponent[] elementPrefabs;
        
        [BoxGroup("Elements configs")] 
        [SerializeField] private ElementConfig[] elementConfigs;
        
        [BoxGroup("Levels")]
        [SerializeField] private LevelComponent[] levels;

        public ElementComponent[] ElementPrefabs => elementPrefabs;
        public ElementConfig[] ElementConfigs => elementConfigs;
        public LevelComponent[] Levels => levels;
    }
}
