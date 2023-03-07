using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Util
{
    public class WeightPicker<T>
    {
        // 총 가중치 합
        public double SumOfWeights
        {
            get
            {
                CalculateSumIfDirty();
                return _sumOfWeights;
            }
        }

        private System.Random _randomInstance;
        private readonly Dictionary<T, double> _itemWeightDictionary;
        private readonly Dictionary<T, double> _normalizedItemWeightDictionary;

        private bool _isDirty;
        private double _sumOfWeights;

        // 생성자
        #region Constructors
        public WeightPicker()
        {
            _randomInstance = new System.Random();
            _itemWeightDictionary = new Dictionary<T, double>();
            _normalizedItemWeightDictionary = new Dictionary<T, double>();
            _isDirty = true;
            _sumOfWeights = 0.0f;
        }

        public WeightPicker(int randomSeed)
        {
            _randomInstance = new System.Random(randomSeed);
            _itemWeightDictionary = new Dictionary<T, double>();
            _normalizedItemWeightDictionary = new Dictionary<T, double>();
            _isDirty = true;
            _sumOfWeights = 0.0f;
        }
        #endregion

        // 아이템 추가
        #region ItemAdd
        // 새로운 아이템-가중치 쌍 추가
        public void Add(T item, double weight)
        {
            CheckDuplicatedItem(item);
            CheckValidWeight(weight);

            _itemWeightDictionary.Add(item, weight);
            _isDirty = true;
        }

        // 새로운 아이템-가중치 쌍들 추가
        public void Add(params (T item, double weight)[] pairs)
        {
            foreach (var pair in pairs)
            {
                CheckDuplicatedItem(pair.item);
                CheckValidWeight(pair.weight);

                _itemWeightDictionary.Add(pair.item, pair.weight);
            }

            _isDirty = true;
        }
        #endregion

        #region Public
        // 아이템 제거
        public void Remove(T item)
        {
            CheckNotExistedItem(item);

            _itemWeightDictionary.Remove(item);
            _isDirty = true;
        }

        // 아이템 가중치 수정
        public void ModifyWeight(T item, double weight)
        {
            CheckNotExistedItem(item);
            CheckValidWeight(weight);

            _itemWeightDictionary[item] = weight;
            _isDirty = true;
        }

        // 시드 재설정
        public void ReSeed(int seed)
        {
            _randomInstance = new System.Random(seed);
        }
        #endregion

        // 뽑기 관련
        #region Getter
        public T GetRandomPick()
        {
            double chance = _randomInstance.NextDouble();
            chance *= SumOfWeights;

            return GetRandomPick(chance);
        }

        public T GetRandomPick(double randomValue)
        {
            if (randomValue < 0.0) randomValue = 0.0;
            if (randomValue > SumOfWeights) randomValue = SumOfWeights - 0.00000001;

            double current = 0.0;
            foreach (var pair in _itemWeightDictionary)
            {
                current += pair.Value;

                if (randomValue < current)
                {
                    return pair.Key;
                }
            }

            throw new Exception($"Unreachable - [Random Value : {randomValue}, Current Value : {current}]");
        }

        public double GetWeight(T item)
        {
            return _itemWeightDictionary[item];
        }

        public double GetNormalizedWeight(T item)
        {
            CalculateSumIfDirty();
            return _normalizedItemWeightDictionary[item];
        }

        // 아이템 목록 확인(읽기 전용)
        public ReadOnlyDictionary<T, double> GetItemDictReadonly()
        {
            return new ReadOnlyDictionary<T, double>(_itemWeightDictionary);
        }

        // 가중치 합이 1이 되도록 정규화된 아이템 목록 확인(읽기 전용)
        public ReadOnlyDictionary<T, double> GetNormalizedItemDictReadonly()
        {
            CalculateSumIfDirty();
            return new ReadOnlyDictionary<T, double>(_normalizedItemWeightDictionary);
        }
        #endregion

        #region Private
        // 가중치 합 구하기
        private void CalculateSumIfDirty()
        {
            if (_isDirty == false) return;
            _isDirty = false;

            _sumOfWeights = 0.0f;
            foreach (var pair in _itemWeightDictionary)
            {
                _sumOfWeights += pair.Value;
            }

            UpdateNormalizedDictionary();
        }

        private void UpdateNormalizedDictionary()
        {
            _normalizedItemWeightDictionary.Clear();
            foreach (var pair in _itemWeightDictionary)
            {
                _normalizedItemWeightDictionary.Add(pair.Key, pair.Value / _sumOfWeights);
            }
        }

        // 이미 아이템이 존재하는지 여부 검사
        private void CheckDuplicatedItem(T item)
        {
            if (_itemWeightDictionary.ContainsKey(item))
                throw new Exception($"이미 [{item}] 아이템이 존재합니다.");
        }

        // 존재하지 않는 아이템인 경우
        private void CheckNotExistedItem(T item)
        {
            if (!_itemWeightDictionary.ContainsKey(item))
                throw new Exception($"[{item}] 아이템이 목록에 존재하지 않습니다.");
        }

        // 가중치 값 범위 검사(0보다 커야 함)
        private void CheckValidWeight(in double weight)
        {
            if (weight <= 0f)
                throw new Exception("가중치 값은 0보다 커야 합니다.");
        }
        #endregion
    }
}
