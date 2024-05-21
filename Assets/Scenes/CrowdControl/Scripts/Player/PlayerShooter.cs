using System;
using UnityEngine;


public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float defaultShootDelay = 1f;
    [SerializeField] private float damagePerShootable = 100f;
    [SerializeField] private Shootable shootablePrefab;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private float damageAddPerYear = 2f;
    private float _shootDelay;
    private float _runningTimer;
    private float _damagePerShootable;
    private int _year = 0;
    private bool canShoot = true;

    private void Start()
    {
        _shootDelay = defaultShootDelay;
        _damagePerShootable = damagePerShootable;
    }

    private void Update()
    {
        _runningTimer += Time.deltaTime;
        if (canShoot && _runningTimer >= _shootDelay)
        {
            _runningTimer = 0f;
            Shoot();
        }
    }

    public void UpdateWeaponYear(int toAdd)
    {
        _year += toAdd;
        var damageToAdd = _year * damageAddPerYear;
        _damagePerShootable = damagePerShootable + damageToAdd;
    }
    
    public void Shoot()
    {
        if(canShoot == true){
            var shootable = Instantiate(shootablePrefab, shootFrom.position, Quaternion.identity);
            shootable.Init(_damagePerShootable);
        }
    }

    public void StopShooting()
    {
        canShoot = false;
    }

    public void ContinueShooting()
    {
        canShoot = true;
    }
}
