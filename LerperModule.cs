namespace UnityPureMVC.Modules.Lerper
{
    using PureMVC.Interfaces;
    using PureMVC.Patterns.Facade;
    using UnityPureMVC.Modules.Lerper.Controller.Commands;
    using UnityPureMVC.Modules.Lerper.Controller.Notes;
    using System;
    using UnityEngine;

    internal class LerperModule : MonoBehaviour
    {
        /// <summary>
        /// The core facade.
        /// </summary>
        private IFacade facade;

        /// <summary>
        /// Start this instance.
        /// </summary>
        protected virtual void Awake()
        {
            try
            {
                facade = Facade.GetInstance("Lerper");
                facade.RegisterCommand(LerperNote.START, typeof(LerperStartCommand));
                facade.SendNotification(LerperNote.START, this);
            }
            catch (Exception exception)
            {
                throw new UnityException("Unable to initiate Facade", exception);
            }
        }

        /// <summary>
        /// On destroy.
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (facade != null)
            {
                facade.Dispose();
                facade = null;
            }
        }
    }
}