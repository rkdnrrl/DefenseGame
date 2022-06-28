using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour, IClassSelect
{
    [SyncVar(hook = nameof(HookSetAmmo))]
    public int ammo = 15;

    [SyncVar(hook = nameof(OnChangeClass))]
    public CharacterClass charClass = CharacterClass.KING;

    

    private int damage = 2;

    void OnSetClassUI()
    {
        if (!hasAuthority)
            return;

        PlayerManager.localPlayer = GetComponent<Player>();

        Manager manager = Manager.instance;
        UIManager uiManager = manager.uiManager;
        PlayerUI playerUI = uiManager.playerUI;

        IClassSelect classSelect = playerUI.characterClassUI;
        classSelect.ChooseClass(this.charClass);
        
    }

    void OnChangeClass(CharacterClass oldClass, CharacterClass newClass)
    {
        if (newClass == CharacterClass.KING)
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;

        }
    }

    void Start()
    {
        OnSetClassUI();
        OnChangeClass(0, this.charClass);

        if(charClass == CharacterClass.KNIGHT) HookSetAmmo(0, this.ammo);
    }
    public void ChooseClass(CharacterClass charClass)
    {
        this.charClass = charClass;

        
    }

    public CharacterClass GetCharacterClass()
    {
        return charClass;
    }


    /// <summary>
    /// isLocalplayer를 사용할지 hasAuthority를 사용할지 여기서 정합니다.
    /// </summary>
    /// <returns></returns>
    public bool UserCheck()
    {
        return hasAuthority;
    }

    public int GetDamage()
    {
        return damage;
    }
    
    public int GetAmmo()
    {
        return ammo;
    }

    [Command(requiresAuthority = false)]
    public void CmdSetAmmo(int value)
    {
        this.ammo += value;
        //HookSetAmmo(0, this.ammo);
    }

    void HookSetAmmo(int oldValue, int newValue)
    {
        if (!hasAuthority) return;

        CharacterClassUI characterClassUI = Manager.instance.uiManager.playerUI.characterClassUI;
        if(charClass == CharacterClass.KNIGHT)
        {
            KnightUI knightUI = characterClassUI.GetClassUI(charClass) as KnightUI;
            if (knightUI != null) knightUI.SetChangeValue();
        }
        
    }

    public void Reroad(int ammo)
    {
        
        if (Castle.instance.gold < 10) return;

        Castle.instance.CmdChangeMoney(-10);
        CmdSetAmmo(ammo);
    }
}
