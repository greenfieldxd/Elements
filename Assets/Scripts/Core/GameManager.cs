using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
    
        private List<GameSystem> _systems;

        private void Start()
        {
            var gameData = new GameData();
            _systems ??= new List<GameSystem>();
            _systems = GetComponentsInChildren<GameSystem>().OrderBy(x => x.transform.GetSiblingIndex()).ToList();

            foreach (var system in _systems)
            {
                system.Set(config, gameData);
                system.OnInit();
            }
        }

        private void Update()
        {
            foreach (var system in _systems)
            {
                system.OnUpdate();
            }
        }
    
        private void FixedUpdate()
        {
            foreach (var system in _systems)
            {
                system.OnFixedUpdate();
            }
        }
    }
}
