using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PonteiroMan : MonoBehaviour
{
    public HorasTagEditor horaTagData;
    private int currentHoraIndex = 0;
    private int ultimoHoraIndex = -1;
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
    public GameObject objetoDeCobertura; // Objeto que cobre o minigame
    public float intervaloDeEspera = 1.0f;

    public AudioClip pointSound;
    private AudioSource audioSource;
    public Text dica;

    void Start()
    {
        pointManager = FindObjectOfType<PointMan>();
        AtualizarHoraTag();
        audioSource = GetComponent<AudioSource>();
    }

    public void PonteiroPosicionadoCorretamente()
    {
        ponteirosCorretos++;
        VerificaPonteiros();
        Debug.Log("AUMENTOU ESSA MERDA");
    }

    public void PonteiroRemovidoDaPosicao()
    {
        ponteirosCorretos--;
        Debug.Log("DIMINUIU ESSE KRL");
    }

    private void VerificaPonteiros()
    {
        if (ponteirosCorretos >= totalDePonteiros)
        {
            StartCoroutine(ExecutarComIntervalo());
        }
    }

    private IEnumerator ExecutarComIntervalo()
    {
        objetoDeCobertura.SetActive(true);

        DragToRotate rodaroda1 = p1.GetComponent<DragToRotate>();
        DragToRotate rodaroda2 = p2.GetComponent<DragToRotate>();
        ObjectMan objectMan = man.GetComponent<ObjectMan>();

        objectMan.correctlyPlacedCount = 0;

        rodaroda1.enabled = false;
        rodaroda2.enabled = false;

        audioSource.PlayOneShot(pointSound);

        //tudo acima dessa linha vai acontecer durante/antes do cooldownzinho de quando tu acerta
        yield return new WaitForSeconds(intervaloDeEspera);
        //tudo abaixo dessa linha vai acontecer soh dps do cooldown, entao por exemplo, logo acima ta desativando o script de rotacao do ponteiro pra ele travar, mas aqui embaixo tem o script q teleporta o ponteiro, pq ele tem q ficar um pouco na posicao antes dele teleportar

        dica.text = "Arraste as peças!";
        
        textoHora.SetActive(false);

        objetoDeCobertura.SetActive(false);

        Debug.Log("Todos os ponteiros estão na posição correta!");
        TeleportPonteiros();
        TeleportNumeros();
        Debug.Log("Intervalo concluído!");

        AtualizarHoraTag();
        ponteirosCorretos = 0;

        if (pointManager != null)
        {
            pointManager.AddPoint();
        }
    }

        private void TeleportPonteiros()
    {
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
        int currentHoraIndex;

        do
        {
            currentHoraIndex = Random.Range(0, horaTagData.horaMinutoTags.Length);
        } while (currentHoraIndex == ultimoHoraIndex);

        ultimoHoraIndex = currentHoraIndex;

        HorasTag horaAtual = horaTagData.horaMinutoTags[currentHoraIndex];

        textoHoraDisplay.text = horaAtual.horaTexto;

        ponteiroHora.horaTag = horaAtual.tagHora;
        ponteiroMinuto.horaTag = horaAtual.tagMinuto;

        Debug.Log($"Novo horário: {horaAtual.horaTexto}, Hora Tag: {horaAtual.tagHora}, Minuto Tag: {horaAtual.tagMinuto}");
    }
}
