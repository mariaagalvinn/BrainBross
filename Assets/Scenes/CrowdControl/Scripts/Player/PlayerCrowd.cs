using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace BrainBross
{
    public class PlayerCrowd : MonoBehaviour
    {
        [SerializeField] private int crowdSizeForDebug = 5;
        [SerializeField] private int startingCrowdSize = 1;
        public static int crowdSize;

        [SerializeField] private PlayerShooter shooterPrefab;
        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
        private List<PlayerShooter> _shooters = new List<PlayerShooter>();
        public List<PlayerShooter> Shooters => _shooters;
        [ContextMenu("Set")]
        public void Debug_ResizeCrowd() => Set(crowdSizeForDebug);

        [SerializeField] private TMP_Text yearText;

        private int _year;

        private float _timer = 0f;

        private void Awake()
        {
            crowdSize = 1;
        }

        private void Start()
        {
            Set(startingCrowdSize);
            crowdSize = 1;
            yearText.text = crowdSize.ToString();
        }

        public void AddYearToCrowd(int yearToAdd)
        {
            _year += yearToAdd;
            foreach (var shooter in _shooters)      
            {
                shooter.UpdateWeaponYear(yearToAdd);
            }
            yearText.text = _year.ToString();
        }

        public void Set(int amount)
        {
            if (_shooters.Count == amount) return;
            var needToRemove = amount < _shooters.Count;
            var needToAdd = amount > _shooters.Count;
            while (amount != _shooters.Count)
            {
                if(needToRemove) RemoveShooter();
                else if (needToAdd) AddShooter();
            }

        }

        public bool CanAdd()
        {
            return _shooters.Count + 1 <= spawnPoints.Count;
        }

        public void RemoveShooter()
        {
            if (crowdSize>0)
            {
                crowdSize--;
            }
            var lastShooter = _shooters[_shooters.Count - 1];
            _shooters.Remove(lastShooter);
            Destroy(lastShooter.gameObject);
            yearText.text = crowdSize.ToString();
        }

        public void AddShooter()
        {
            if (!CanAdd()) return;
            crowdSize++;
            var lastShooterIndex = _shooters.Count - 1;
            var position = spawnPoints[lastShooterIndex + 1].position;
            var shooter = Instantiate(shooterPrefab, position, Quaternion.identity, transform);
            _shooters.Add(shooter);
            yearText.text = crowdSize.ToString();
        }

        public void OnCollisionEnter(Collision other)
        {
            if(other.transform.CompareTag("Damageable"))
            {
                RemoveShooter();
            }
        }

        public void OnCollisionStay(Collision other)
        {
            if(other.transform.CompareTag("Damageable"))
            {
                _timer += Time.deltaTime;
                if (_timer > 0.5f)
                {
                    RemoveShooter();
                    _timer = 0f;
                }
            }
        }

        public void OnCollisionExit()
        {
            _timer = 0f;
        }
    }
}