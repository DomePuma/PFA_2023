using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    [SerializeField] private Button equipeGrayScreen;
    [SerializeField] private Button equipeAsthymScreen;
    [SerializeField] private Button equipeMajScreen;
    [SerializeField] private Button sortsGray;
    [SerializeField] private Button sortsAsthym;
    [SerializeField] private Button sortsMaj;
    [SerializeField] private Button attack;

    [SerializeField] private Button graySword;
    [SerializeField] private Button grayPickaxe;       
    [SerializeField] private Button grayHammer;

    
    public void SelectGraySword()
    {
        graySword.Select();
    }
    public void SelectGrayPickaxe()
    {
        grayPickaxe.Select();
    }
    public void SelectGrayHammer()
    {
        grayHammer.Select();
    }
    public void SelectSortGray()
    {
        sortsGray.Select();
    }
    public void SelectSortMaj()
    {
        sortsMaj.Select();
    }
    public void SelectSortAsthym()
    {
        sortsAsthym.Select();
    }
    public void SelectEquipeGray()
    {
        equipeGrayScreen.Select();
    }
    public void SelectEquipeAsthym()
    {
        equipeAsthymScreen.Select();
    }
    public void SelectEquipeMaj()
    {
        equipeMajScreen.Select();
    }
    public void SelectAtk()
    {
        attack.Select();
    }

}
