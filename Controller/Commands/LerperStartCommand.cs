using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityPureMVC.Core.Libraries.UnityLib.Utilities.Logging;
using UnityPureMVC.Modules.Lerper.Controller.Commands.Requests;
using UnityPureMVC.Modules.Lerper.Controller.Notes;
using UnityPureMVC.Modules.Lerper.Model.Proxies;

namespace UnityPureMVC.Modules.Lerper.Controller.Commands
{
    class LerperStartCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            DebugLogger.Log("TransformLerperStartCommand::Execute");

            // Register Proxies
            Facade.RegisterProxy(new LerperProxy());

            // Register commands
            Facade.RegisterCommand(LerperNote.REQUEST_LERP_FROM, typeof(RequestLerpFromCommand));
            Facade.RegisterCommand(LerperNote.REQUEST_LERP_TO, typeof(RequestLerpToCommand));
            Facade.RegisterCommand(LerperNote.REQUEST_LERP_FROM_TO, typeof(RequestLerpFromToCommand));

            Facade.RemoveCommand(LerperNote.START);

        }
    }
}