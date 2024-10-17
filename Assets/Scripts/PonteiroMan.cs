using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonteiroMan : MonoBehaviour
{
    public int ponteirosCorretos = 0;  // Contagem de quantos ponteiros estão posicionados corretamente
    public int totalDePonteiros = 2;    // Define o número total de ponteiros no jogo
    public GameObject[] spawnPoints; // Adicione os spawn points aqui
    private ObjectMan objectManager;
    public GameObject p1;
    public GameObject p2;

    void Start()
    {
        objectManager = FindObjectOfType<ObjectMan>(); // Obter a referência ao ObjectMan
    }

    // Método chamado quando um ponteiro é posicionado corretamente
    public void PonteiroPosicionadoCorretamente()
    {
        ponteirosCorretos++;
        VerificaPonteiros();
    }

    // Método chamado quando um ponteiro sai da posição correta
    public void PonteiroRemovidoDaPosicao()
    {
        ponteirosCorretos--;
    }

    // Verifica se todos os ponteiros estão posicionados
    private void VerificaPonteiros()
    {
        if (ponteirosCorretos >= totalDePonteiros)
        {
            Debug.Log("Todos os ponteiros estão na posição correta!");

            // Teleportar os ponteiros para posições aleatórias
            TeleportPonteiros();

            DragToRotate rodaroda1 = p1.GetComponent<DragToRotate>();
            DragToRotate rodaroda2 = p2.GetComponent<DragToRotate>();

            rodaroda1.enabled = false;
            rodaroda2.enabled = false;
            Debug.Log("eu juro q eu vou me matar mano");
        }
    }

    private void TeleportPonteiros()
    {
        // Encontra todos os ponteiros
        PontaDoPonteiro[] pontas = FindObjectsOfType<PontaDoPonteiro>();
        foreach (PontaDoPonteiro ponta in pontas)
        {
            // Acessa o objeto pai da ponta do ponteiro
            Transform ponteiroPai = ponta.transform.parent;

            // Escolhe um spawn point aleatório
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 randomPosition = spawnPoints[randomIndex].transform.position;

            // Teleporta o ponteiro pai para a posição aleatória
            ponteiroPai.position = randomPosition;

            // Chama o método de teleportar que reseta a rotação
            DragAndDrop dragAndDrop = ponteiroPai.GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                dragAndDrop.Teleport(); // Reseta a rotação do ponteiro
            }
        }
    }
}
