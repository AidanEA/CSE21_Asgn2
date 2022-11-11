using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
public class ChangeBrightnessButton : MonoBehaviour
{
    public List<Light> Lights;
    // Update is called once per frame
    private VisualElement frame;
    private Button button;
    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("BrightnessFrame");
        // get the button, which is nested in the frame
        button = frame.Q<Button>("BrightnessButton");
        // create event listener that calls ChangeCamera() when pressed
        button.RegisterCallback<ClickEvent>(ev => ChangeBrightness());
    }
    int click = 0;
    private void ChangeBrightness(){
        if(click == 0)
        {
            Lights.ForEach(light => light.intensity = 1);
        }
        if (click == 1)
        {
            Lights.ForEach(light => light.intensity = 0.5f);
        }
        if (click == 2)
        {
            Lights.ForEach(light => light.intensity = 0);
        }
        click++;

        // reset counter (3 light levels)
        if (click > 2)
        {
            click = 0;
        }
    }
}
