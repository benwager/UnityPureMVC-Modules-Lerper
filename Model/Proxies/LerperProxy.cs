using PureMVC.Patterns.Proxy;
using UnityPureMVC.Core.Libraries.UnityLib.Utilities.Logging;
using UnityPureMVC.Modules.Lerper.Model.VO;
using UnityEngine;

namespace UnityPureMVC.Modules.Lerper.Model.Proxies
{
    internal class LerperProxy : Proxy
    {
        new internal const string NAME = "LerperProxy";

        protected LerperVO LerperVO { get { return Data as LerperVO; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UnityPureMVC.Core.Model.Proxies.DataProxy"/> class.
        /// Create a new DataVO object
        /// Call method to set ay DataVO default values
        /// </summary>
        internal LerperProxy() : base(NAME)
        {
            DebugLogger.Log(NAME + "::__Contstruct");
            Data = new LerperVO();
        }

        /// <summary>
        /// 
        /// </summary>
        public GameObject ContainerGameObject
        {
            get
            {
                if (LerperVO.containerGameObject == null)
                {
                    LerperVO.containerGameObject = new GameObject("Lerper Module");
                }
                return LerperVO.containerGameObject;
            }
            set
            {
                LerperVO.containerGameObject = value;
            }
        }
    }
}