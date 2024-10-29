using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PonteiroMan : MonoBehaviour
{
    public HorasTagEditor horaTagData;
    private int currentHoraIndex = 0;
    public Text textoHoraDisplay;

    public PontaDoPonteiro ponteiroHora;
    public PontaDoPonteiro ponteiroMinuto;

    public int ponteirosCorretos = 0;
    public int totalDePonteiros = 2;

    private PointMan pointManager;
    public GameObject[] spawnPoints;
    private ObjectMan objectManager;
    public GameObject p1;
    public GameObject p2;
    public GameObject num;
    public GameObject man;
    public GameObject textoHora;

    void Start()
    {
        //importa o horario gerado
        pointManager = FindObjectOfType<PointMan>();
        AtualizarHoraTag();
    }

    public void PonteiroPosicionadoCorretamente()
    {
        //diz que o ponteiro ta perto da posicao certa
        ponteirosCorretos++;
        VerificaPonteiros();
        Debug.Log("AUMENTOU ESSA MERDA");
    }

    public void PonteiroRemovidoDaPosicao()
    {
        //diz que o ponteiro saiu da posicao certa
        ponteirosCorretos--;
        Debug.Log("DIMINUIU ESSE KRL");
    }

    private void VerificaPonteiros()
    {
        if (ponteirosCorretos >= totalDePonteiros)
        {
            Debug.Log("Todos os ponteiros estão na posição correta!");
            //verifica se os ponteiros estao na posicao certa
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

            AtualizarHoraTag();
            ponteirosCorretos = 0;

            if (pointManager != null)
            {
                pointManager.AddPoint();
            }
        }
    }

        private void TeleportPonteiros()
    {
        //funcao que teleporta o ponteiro pra posicao certa quando tocado no collider
        PontaDoPonteiro[] pontas = FindObjectsOfType<PontaDoPonteiro>();
    foreach (PontaDoPonteiro ponta in pontas)
    {
        ponta.positioned = false;

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
        //funcao que teleporta o numero pra posicao certa quando tocado no collider
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

    private void AtualizarHoraTag()
    {
        //funcao que atualiza a tag de hora
        currentHoraIndex = Random.Range(0, horaTagData.horaMinutoTags.Length);

        HorasTag horaAtual = horaTagData.horaMinutoTags[currentHoraIndex];

        textoHoraDisplay.text = horaAtual.horaTexto;

        ponteiroHora.horaTag = horaAtual.tagHora;
        ponteiroMinuto.horaTag = horaAtual.tagMinuto;

        Debug.Log($"Novo horário: {horaAtual.horaTexto}, Hora Tag: {horaAtual.tagHora}, Minuto Tag: {horaAtual.tagMinuto}");
    }
}
