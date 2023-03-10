using UnityEngine;
using Keyword;

namespace UI
{
    public class GameSceneCanvases : SceneCanvases
    {
        // protected override void SetOnEnableAction()
        // {
        //     ChangeCanvas(CanvasChangeType.PlayGame, CanvasNameKeyword.PlayInformationCanvas);
        // }

        // protected override void SetOnDisableAction()
        // {

        // }

        // TODO: this method will delete
        public void ChangeCanvas(int index, string before)
        {
            ChangeCanvas((CanvasChangeType)index, before);
        }

        public void ChangeCanvas(CanvasChangeType type, string beforeName)
        {
            switch (type)
            {
                case CanvasChangeType.Item:
                    foreach (var canvas in Canvases)
                    {
                        if (canvas.Key == CanvasNameKeyword.ItemCanvas)
                            canvas.Value.OnEnableAction?.Invoke();
                        else if ((beforeName == CanvasNameKeyword.PlayInformationCanvas || beforeName == CanvasNameKeyword.ControllerCanvas) && (canvas.Key == CanvasNameKeyword.PlayInformationCanvas || canvas.Key == CanvasNameKeyword.ControllerCanvas))
                            canvas.Value.OnDisableAction?.Invoke();
                        else if (canvas.Key == beforeName)
                            canvas.Value.OnDisableAction?.Invoke();
                    }
                    break;
                case CanvasChangeType.Result:
                    foreach (var canvas in Canvases)
                    {
                        if (canvas.Key == CanvasNameKeyword.ResultCanvas)
                            canvas.Value.OnEnableAction?.Invoke();
                        else if ((beforeName == CanvasNameKeyword.PlayInformationCanvas || beforeName == CanvasNameKeyword.ControllerCanvas) && (canvas.Key == CanvasNameKeyword.PlayInformationCanvas || canvas.Key == CanvasNameKeyword.ControllerCanvas))
                            canvas.Value.OnDisableAction?.Invoke();
                        else if (canvas.Key == beforeName)
                            canvas.Value.OnDisableAction?.Invoke();
                    }
                    break;
                case CanvasChangeType.PlayGame:
                    foreach (var canvas in Canvases)
                    {
                        if (canvas.Key == CanvasNameKeyword.PlayInformationCanvas || canvas.Key == CanvasNameKeyword.ControllerCanvas)
                            canvas.Value.OnEnableAction?.Invoke();
                        else if (canvas.Key == beforeName)
                            canvas.Value.OnDisableAction?.Invoke();
                    }
                    break;
                case CanvasChangeType.Setting:
                    foreach (var canvas in Canvases)
                    {
                        if (canvas.Key == CanvasNameKeyword.SettingCanvas)
                            canvas.Value.OnEnableAction?.Invoke();
                        else if ((beforeName == CanvasNameKeyword.PlayInformationCanvas || beforeName == CanvasNameKeyword.ControllerCanvas) && (canvas.Key == CanvasNameKeyword.PlayInformationCanvas || canvas.Key == CanvasNameKeyword.ControllerCanvas))
                            canvas.Value.OnDisableAction?.Invoke();
                        else if (canvas.Key == beforeName)
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
