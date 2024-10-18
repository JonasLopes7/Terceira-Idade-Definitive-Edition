using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonteiroMan : MonoBehaviour
{
    public int ponteirosCorretos = 0;
    public int totalDePonteiros = 2;
    public GameObject[] spawnPoints;
    private ObjectMan objectManager;
    public GameObject p1;
    public GameObject p2;
    public GameObject num;
    public GameObject man;
    private PointMan pointManager;
    public GameObject textoHora;

    void Start()
    {
        objectManager = FindObjectOfType<ObjectMan>();
        pointManager = FindObjectOfType<PointMan>();
    }

    public void PonteiroPosicionadoCorretamente()
    {
        ponteirosCorretos++;
        VerificaPonteiros();
    }

    public void PonteiroRemovidoDaPosicao()
    {
        ponteirosCorretos--;
    }

    private void VerificaPonteiros()
    {
        if (ponteirosCorretos >= totalDePonteiros)
        {
            Debug.Log("Todos os ponteiros estão na posição correta!");

            TeleportPonteiros();
            TeleportNumeros();

            DragToRotate rodaroda1 = p1.GetComponent<DragToRotate>();
            DragToRotate rodaroda2 = p2.GetComponent<DragToRotate>();
            ObjectMan objectMan = man.GetComponent<ObjectMan>();

            objectMan.correctlyPlacedCount = 0;

            textoHora.SetActive(false);

            rodaroda1.enabled = false;
            rodaroda2.enabled = false;
            Debug.Log("eu juro q eu vou me matar mano");

            if (pointManager != null)
            {
                pointManager.AddPoint();
            }
        }
    }

    private void TeleportPonteiros()
    {
        PontaDoPonteiro[] pontas = FindObjectsOfType<PontaDoPonteiro>();
        foreach (PontaDoPonteiro ponta in pontas)
        {
            Transform ponteiroPai = ponta.transform.parent;

            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 randomPosition = spawnPoints[randomIndex].transform.position;

            ponteiroPai.position = randomPosition;

            DragAndDrop dragAndDrop = ponteiroPai.GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                dragAndDrop.Teleport();
                dragAndDrop.hasIncremented = false;
            }
        }
    }

    private void TeleportNumeros()
    {
        if (num != null)
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 randomPosition = spawnPoints[randomIndex].transform.position;

        num.transform.position = randomPosition;

        DragAndDrop dragAndDrop = num.GetComponent<DragAndDrop>();
        if (dragAndDrop != null)
        {
            dragAndDrop.Teleport();
        }

        Debug.Log("Pericles");
    }
    }
}
