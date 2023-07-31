using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] List<Updatable> _updatables = new List<Updatable>();
    [SerializeField] List<Updatable> _lateUpdatables = new List<Updatable>();

    private void Update()
    {   
        if(_updatables.Count == 0)
            return;

        foreach (var updatable in _updatables)
        {
            if (updatable == null)
            {
                _updatables.Remove(updatable);
                return;
            }
            updatable.Update(Time.deltaTime);
        }          
    }

    private void LateUpdate()
    {
        if (_lateUpdatables.Count == 0)
            return;

        foreach (var updatable in _lateUpdatables)
        {
            if(updatable == null)
            {
                _lateUpdatables.Remove(updatable);
                return;
            }
            updatable.Update(Time.deltaTime);
        }           
    }

    public void AddUpdatable(Updatable updatable)
    {
        _updatables.Add(updatable);
    }

    public void AddLateUpdatable( Updatable lateUpdatable)
    {
        _lateUpdatables.Add(lateUpdatable);
    }
}
