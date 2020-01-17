using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityPureMVC.Modules.Lerper.View.Components.Delegates.Delegates;

namespace UnityPureMVC.Modules.Lerper.View.Components
{
    public abstract class AbstractLerper : MonoBehaviour, ILerper
    {
        public OnCompleteDelegate OnComplete { get; set; }

        public void From(object target, object from, float time, params Action[] callbacks)
        {
            StopAllCoroutines();
            List<Action> cb = callbacks.ToList();
            cb.Add(() => { OnComplete?.Invoke(target); });
            StartCoroutine(Animate(target, from, target, time, cb.ToArray()));
        }

        public void To(object target, object to, float time, params Action[] callbacks)
        {
            StopAllCoroutines();
            List<Action> cb = callbacks.ToList();
            cb.Add(() => { OnComplete?.Invoke(target); });
            StartCoroutine(Animate(target, target, to, time, cb.ToArray()));
        }

        public void FromTo(object target, object from, object to, float time, params Action[] callbacks)
        {
            StopAllCoroutines();
            List<Action> cb = callbacks.ToList();
            cb.Add(() => { OnComplete?.Invoke(target); });
            StartCoroutine(Animate(target, from, to, time, cb.ToArray()));
        }

        protected void InvokeCallbacks(params Action[] callbacks)
        {
            callbacks.ToList().ForEach(cb => cb?.Invoke());
        }

        protected void Destroy()
        {
            GameObject.Destroy(this);
        }

        public abstract IEnumerator Animate(object target, object from, object to, float time, params Action[] callbacks);
    }
}