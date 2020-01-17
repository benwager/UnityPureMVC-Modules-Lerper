using System;

namespace UnityPureMVC.Modules.Lerper.Model.VO
{
    [System.Serializable]
    internal class LerperRequestVO
    {
        internal object target;
        internal object from;
        internal object to;
        internal Type lerper;
        internal float time;
        internal Action callback;
    }
}