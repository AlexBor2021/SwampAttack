using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRage;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionRage += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRage)
        {
            NeedTransit = true;
        }
    }
}
