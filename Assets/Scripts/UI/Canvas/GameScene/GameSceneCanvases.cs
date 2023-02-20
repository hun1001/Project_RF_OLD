using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyword;

namespace UI
{
    public class GameSceneCanvases : SceneCanvases
    {
        protected override void SetOnEnableAction()
        {
            ChangeCanvas(CanvasChangeType.PlayGame);
        }

        protected override void SetOnDisableAction()
        {
            
        }
        
        // TODO: this method will delete
        public void ChangeCanvas(int index)
        {
            ChangeCanvas((CanvasChangeType)index);
        }

        public void ChangeCanvas(CanvasChangeType type)
        {
            switch (type)
            {
                case CanvasChangeType.Item:
                    foreach (var canvas in Canvases)
                    {
                        if(canvas.Key == CanvasNameKeyword.ItemCanvas)
                            canvas.Value.OnEnableAction?.Invoke();
                        else
                            canvas.Value.OnDisableAction?.Invoke();
                    }
                    break;
                case CanvasChangeType.Result:
                    foreach (var canvas in Canvases)
                    {
                        if(canvas.Key == CanvasNameKeyword.ResultCanvas)
                            canvas.Value.OnEnableAction?.Invoke();
                        else
                            canvas.Value.OnDisableAction?.Invoke();
                    }
                    break;
                case CanvasChangeType.PlayGame:
                    foreach (var canvas in Canvases)
                    {
                        if(canvas.Key == CanvasNameKeyword.PlayInformationCanvas || canvas.Key == CanvasNameKeyword.ControllerCanvas)
                            canvas.Value.OnEnableAction?.Invoke();
                        else
                            canvas.Value.OnDisableAction?.Invoke();
                    }
                    break;
                default:
                    Debug.LogError("CanvasChangeType is not defined");
                    break;
            }
        }
    }
}
