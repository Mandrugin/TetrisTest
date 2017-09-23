using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

public class RecordView : View
{
    public Signal okButtonClickedSignal = new Signal();

    public Text RecordText;
    public Button OkButton;

    protected override void Awake()
    {
        base.Awake();
        OkButton.onClick.AddListener(() => okButtonClickedSignal.Dispatch());
    }
}
