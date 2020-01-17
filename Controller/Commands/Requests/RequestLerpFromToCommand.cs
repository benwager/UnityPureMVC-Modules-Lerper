using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityPureMVC.Core.Libraries.UnityLib.Utilities.Logging;
using UnityPureMVC.Modules.Lerper.Controller.Notes;
using UnityPureMVC.Modules.Lerper.Model.Proxies;
using UnityPureMVC.Modules.Lerper.Model.VO;
using UnityPureMVC.Modules.Lerper.View.Components;

namespace UnityPureMVC.Modules.Lerper.Controller.Commands.Requests
{
    internal class RequestLerpFromToCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            DebugLogger.Log("RequestTransformLerpFromToCommand::Execute");

            LerperProxy lerperProxy = Facade.RetrieveProxy(LerperProxy.NAME) as LerperProxy;

            LerperRequestVO lerperRequestVO = notification.Body as LerperRequestVO;

            if (lerperRequestVO.target == null)
            {
                DebugLogger.LogWarning("Lerp error : No target Transform specified.");
                return;
            }

            if (lerperRequestVO.from == null)
            {
                DebugLogger.LogWarning("Lerp error : No from Transform specified.");
                return;
            }

            if (lerperRequestVO.to == null)
            {
                DebugLogger.LogWarning("Lerp error : No to Transform specified.");
                return;
            }

            if (lerperRequestVO.lerper == null || lerperRequestVO.lerper.GetInterface(nameof(ILerper)) == null)
            {
                DebugLogger.LogWarning("Lerp warning : No lerper specified or not implementing ILerper. Reverting to default.");

                lerperRequestVO.lerper = typeof(LerpTransform);
            }

            ILerper lerper = (ILerper)lerperProxy.ContainerGameObject.AddComponent(lerperRequestVO.lerper);

            lerper.OnComplete += OnLerpComplete;

            lerper.FromTo(
                lerperRequestVO.target,
                lerperRequestVO.from,
                lerperRequestVO.to,
                lerperRequestVO.time,
                lerperRequestVO.callback);
        }

        private void OnLerpComplete(object target)
        {
            SendNotification(LerperNote.RESULT_LERP_COMPLETE, target);
        }
    }
}
