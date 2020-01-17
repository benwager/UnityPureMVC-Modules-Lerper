using System;
using System.Collections;
using static UnityPureMVC.Modules.Lerper.View.Components.Delegates.Delegates;

namespace UnityPureMVC.Modules.Lerper.View.Components
{
    public interface ILerper
    {
        OnCompleteDelegate OnComplete { get; set; }

        void From(object target, object from, float time, params Action[] callbacks);

        void To(object target, object to, float time, params Action[] callbacks);

        void FromTo(object target, object from, object to, float time, params Action[] callbacks);

        IEnumerator Animate(object target, object from, object to, float time, params Action[] callbacks);
    }
}