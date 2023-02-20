using System;
using System.Collections;
using System.Collections.Generic;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEditor;
using UnityEngine;

namespace UI
{
    public class ItemCanvas : BaseCanvas
    {
        protected override void SetOnEnableAction()
        {
            gameObject.SendMessage("ItemShow");
        }
        
        protected override void SetOnDisableAction()
        {
            
        }
    }
}
