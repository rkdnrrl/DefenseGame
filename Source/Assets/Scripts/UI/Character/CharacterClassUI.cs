using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterClassUI : MonoBehaviour, IClassSelect
{
    public ClassUI[] characterClassUIs;

    [Client]
    public void ChooseClass(CharacterClass charClass)
    {
        for (int i = 0; i < characterClassUIs.Length; i++)
        {
            if (characterClassUIs[i].charClass == charClass)
                characterClassUIs[i].gameObject.SetActive(true);
            else
                characterClassUIs[i].gameObject.SetActive(false);
        }
    }

    public ClassUI GetClassUI(CharacterClass charClass)
    {
        for (int i = 0; i < characterClassUIs.Length; i++)
        {
            if (characterClassUIs[i].charClass == charClass)
                return characterClassUIs[i];
        }

        return null;
    }
}
