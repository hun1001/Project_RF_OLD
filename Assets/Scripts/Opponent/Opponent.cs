using UnityEngine;
using Base;
using System.Linq;
using Random = UnityEngine.Random;

namespace Opponent
{
    public class Opponent : CustomGameObject<Opponent>
    {
        [Header("Transform")]
        [SerializeField]
        private Transform _spawnPointParent1 = null;
        [SerializeField]
        private Transform _spawnPointParent2 = null;
        [SerializeField]
        private Transform _spawnPointParent3 = null;


        [SerializeField]
        private Transform _playerSpawnPoint1 = null;
        public Transform PlayerSpawnPoint1 => _playerSpawnPoint1;
        [SerializeField]
        private Transform _playerSpawnPoint2 = null;
        public Transform PlayerSpawnPoint2 => _playerSpawnPoint2;
        [SerializeField]
        private Transform _playerSpawnPoint3 = null;
        public Transform PlayerSpawnPoint3 => _playerSpawnPoint3;

        public Transform[] SpawnPoints1 => _spawnPointParent1.GetComponentsInChildren<Transform>().Where(x => x != _spawnPointParent1).ToArray();
        public Transform GetRandomSpawnPoint1 => SpawnPoints1[Random.Range(0, SpawnPoints1.Length)];
        public Transform[] SpawnPoints2 => _spawnPointParent2.GetComponentsInChildren<Transform>().Where(x => x != _spawnPointParent2).ToArray();
        public Transform GetRandomSpawnPoint2 => SpawnPoints2[Random.Range(0, SpawnPoints2.Length)];
        public Transform[] SpawnPoints3 => _spawnPointParent3.GetComponentsInChildren<Transform>().Where(x => x != _spawnPointParent3).ToArray();
        public Transform GetRandomSpawnPoint3 => SpawnPoints3[Random.Range(0, SpawnPoints3.Length)];

        [SerializeField]
        private SO.OpponentSO _opponentSO = null;
        public SO.OpponentSO OpponentSO => _opponentSO;

        [SerializeField]
        private UI.TextController _waveTimer = null;
        public UI.TextController WaveTimer => _waveTimer;
    }
}
