using System;
using System.Collections;
using UnityEngine;

namespace UnityPureMVC.Modules.Lerper.View.Components
{
    public class LerpTransform : AbstractLerper
    {
        public override IEnumerator Animate(object target, object from, object to, float time, params Action[] callbacks)
        {
            Quaternion fromRotation = ((Transform)from).rotation;
            Vector3 fromPosition = ((Transform)from).position;
            Vector3 fromScale = ((Transform)from).localScale;

            Quaternion toRotation = ((Transform)to).rotation;
            Vector3 toPosition = ((Transform)to).position;
            Vector3 toScale = ((Transform)to).localScale;

            float elapsed = 0;
            float t = 0;

            while (elapsed < time)
            {
                t = elapsed / time;

                ((Transform)target).rotation = Quaternion.Lerp(fromRotation, toRotation, t);
                ((Transform)target).position = Vector3.Lerp(fromPosition, toPosition, t);
                ((Transform)target).localScale = Vector3.Lerp(fromScale, toScale, t);

                elapsed += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            ((Transform)target).rotation = toRotation;
            ((Transform)target).position = toPosition;
            ((Transform)target).localScale = toScale;

            InvokeCallbacks(callbacks);
            Destroy();
        }
    }
}