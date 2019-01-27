using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour
{

    [SerializeField] private float _trauma = 0f;
    public float MaxAngle = 30f;

    public bool Shaking = false;

    private Quaternion _initialRot;
    private float _angle;

    private float flipFlop = 1f;

    private float _currentAngle;

    private void Awake()
    {
        _initialRot = transform.localRotation;
    }

    public void DoShake(float damage)
    {
        _trauma += damage;

        this.enabled = true;
    }

    private void Update()
    {
        //Do Shaking
        {
            float seed = Random.Range(0, 100f);

            if (_trauma > 1f) _trauma = 1f;

            flipFlop = -flipFlop;
            _angle = MaxAngle * _trauma * Mathf.PerlinNoise(seed, Time.time) * flipFlop;

            _trauma *= 0.9f;

            //transform.Rotate(transform.forward, _angle, Space.Self);
            transform.localRotation = Quaternion.AngleAxis(_angle, transform.forward);

            if (_trauma <= 0.01f)
            {
                _trauma = 0f;
                transform.localRotation = _initialRot;

                this.enabled = false;
            }
        }
    }
}