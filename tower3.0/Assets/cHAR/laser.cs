using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
   [SerializeField] private LineRenderer _beam;
   [SerializeField] private Transform _muzzlePoint;
   [SerializeField] private float _maxLength;

   [SerializeField] private ParticleSystem _muzzleParticle;
   [SerializeField] private ParticleSystem _hitParticles;

   private void Awake()
   {
    _beam.enabled = false;
   }

   private void Activate()
   {
    _beam.enabled = true;

    _muzzleParticle.Play();
    _hitParticles.Play();
   }

   private void Deactivate()
   {
    _beam.enabled = false;
    _beam.SetPosition(0,_muzzlePoint.position);
    _beam.SetPosition(1,_muzzlePoint.position);

     _muzzleParticle.Stop();
    _hitParticles.Stop();
   }

   private void Update()
   {
        if(Input.GetMouseButtonDown(0)) Activate();
        else if(Input.GetMouseButtonUp(0)) Deactivate();
   }

   private void FixedUpdate()
   {
    if(!_beam.enabled) return;

    Ray ray = new Ray(_muzzlePoint.position,_muzzlePoint.forward);
    bool cast = Physics.Raycast(ray,out RaycastHit hit , _maxLength);
    Vector3 hitPosition = cast ? hit.point : _muzzlePoint.position + _muzzlePoint.forward * _maxLength;

    _beam.SetPosition(0,_muzzlePoint.position);
    _beam.SetPosition(1,hitPosition);

    _hitParticles.transform.position = hitPosition;
   }
   
}
