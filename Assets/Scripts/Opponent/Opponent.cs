using UnityEngine;
using Base;
using System.Linq;
using Random = UnityEngine.Random;
using System.Collections.Generic;

namespace Opponent
{
    public class Opponent : CustomGameObject<Opponent>
    {
        [Header("Transform")]
        [SerializeField]
        private List<Transform> _spawnPointParent = new List<Transform>();
        public List<Transform> SpawnPointParent => _spawnPointParent;


        [SerializeField]
        private List<Transform> _playerSpawnPoint =  new List<Transform>();
        public List<Transform> PlayerSpawnPoint => _playerSpawnPoint;

        public Transform[] GetsSpawnPoint(Transform parent)
        {
            return parent.GetComponentsInChildren<Transform>().Where(x => x != parent).ToArray();
        }
        public Transform GetRandomSpawnPoint(Transform[] list)
        {
            return list[Random.Range(0, list.Length)];
        }

        [SerializeField]
        private SO.OpponentSO _opponentSO = null;
        public SO.OpponentSO OpponentSO => _opponentSO;

        [SerializeField]
        private UI.TextController _waveTimer = null;
        public UI.TextController WaveTimer => _waveTimer;
    }
}
