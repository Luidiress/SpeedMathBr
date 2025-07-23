using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mudarFase : MonoBehaviour
{
    [SerializeField] private string nomeDaProximaFase = "";
    [SerializeField] private float tempoDeTransicao = 1.0f;
    [SerializeField] private GameObject efeitoFade;
    private Animator animator;
    private bool faseCarregando = false;

    void Start()
    {
        animator = efeitoFade.GetComponent<Animator>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!faseCarregando && !string.IsNullOrEmpty(nomeDaProximaFase))
        {
            faseCarregando = true;
            StartCoroutine(TransicaoParaProximaFase());
        }
    }

    IEnumerator TransicaoParaProximaFase()
    {
        // Inicia o efeito de fade
        animator.SetBool("FadeOut", true);  // <- nome do parâmetro do Animator
        // Espera o tempo de transição
        yield return new WaitForSeconds(tempoDeTransicao);
        // Carrega a próxima fase
        SceneManager.LoadScene(nomeDaProximaFase);
    }

    // Botões do menu
    public void play()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void MudarParaCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void MudarParaIninio()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MudarParafinal()
    {
        SceneManager.LoadScene("Fase2");
    }
}