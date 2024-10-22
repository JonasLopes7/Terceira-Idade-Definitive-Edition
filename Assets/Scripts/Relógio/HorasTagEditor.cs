using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HoraTag Data")]
public class HorasTagEditor : ScriptableObject
{
    public HorasTag[] horaMinutoTags;
}

[System.Serializable]
public class HorasTag
{
    public string horaTexto;
    public string tagHora;
    public string tagMinuto;
}
