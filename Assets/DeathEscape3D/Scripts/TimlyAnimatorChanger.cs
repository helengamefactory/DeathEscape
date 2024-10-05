using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimlyAnimatorChanger : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] string _parameterName;
    [SerializeField] int _parameterMinValue;
    [SerializeField] int _parameterMaxValue;
    [SerializeField] int _parameterCurrentValue;
    [SerializeField] string _booleanParameterName;
    [SerializeField] bool _booleanParameterValue;
    [SerializeField] float _interval;
    [SerializeField] bool _isEnabled = true;
    [SerializeField] bool _setOnStart = true;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _parameterCurrentValue = _parameterMinValue;
        _anim.SetBool(_booleanParameterName, _booleanParameterValue);

        if (_setOnStart)
        {
            _setParameter();
        }
        StartCoroutine(_changeValue());
    }
    IEnumerator _changeValue()
    {
        while (_isEnabled)
        {
            yield return new WaitForSeconds(_interval);

            _setParameter() ;

        }
    }
    void _setParameter()
    {
        _anim.SetFloat(_parameterName, _parameterCurrentValue);
        _increaseValue();
    }
    void _increaseValue()
    {
        _parameterCurrentValue++;
        if (_parameterCurrentValue > _parameterMaxValue) _parameterCurrentValue = _parameterMinValue;
    }
}
