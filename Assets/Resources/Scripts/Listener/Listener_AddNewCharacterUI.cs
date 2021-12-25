using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_AddNewCharacterUI : Listener
{
    public override void RunListenerLogic(DispatchData _dispatchData)
    {
        AddNewCharacterUI(_dispatchData.InteractorGO.GetComponent<Character>());
    }

    public void AddNewCharacterUI(Character _character)
    {
        FindObjectOfType<Test_UIManager>().CreatePlayerUI(_character);
    }


}
