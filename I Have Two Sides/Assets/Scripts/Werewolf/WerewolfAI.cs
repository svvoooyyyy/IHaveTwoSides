using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WerewolfAI : MonoBehaviour
{
    [SerializeField] private Transform _extra_target; // промежуточная цель
    [SerializeField] private Transform _target_1; // дверь
    [SerializeField] private Transform _target_2; // финиш

    private bool _isDoorPassed = false; // прошел ли оборотень дверь
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (_isDoorPassed) { _agent.SetDestination(_target_2.position); }
        else { _agent.SetDestination(_target_1.position); }
    }

    public void ChangeTargetToSecond()
    {
        _isDoorPassed = true;
    }

    public void Warp(Vector3 pos)
    {
        _agent.Warp(pos);
    }
}
