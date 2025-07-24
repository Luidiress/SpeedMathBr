using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pezinho46 : MonoBehaviour
{
    [Header("angelo")]
    [SerializeField] private TextMeshProUGUI perguntaTexto;
    [SerializeField] private TMP_InputField inputResposta;
    [SerializeField] private GameObject telaVitoria;
    [SerializeField] private GameObject telaDerrota;
    [SerializeField] private TextMeshProUGUI textoTimer;

    private int numero1;
    private int numero2;
    private int resultadoCorreto;
    private int acertosSeguidos = 0;
    private const int acertosParaVitoria = 3;

    private float tempoTotal = 90f;
    private bool jogoAtivo = true;
    private char operacaoAtual; 

    void Start()
    {
        telaVitoria.SetActive(false);
        telaDerrota.SetActive(false);
        GerarNovaPergunta();
    }

    void Update()
    {
        if (!jogoAtivo) return;

        tempoTotal -= Time.deltaTime;
        int minutos = Mathf.FloorToInt(tempoTotal / 60);
        int segundos = Mathf.FloorToInt(tempoTotal % 60);
        textoTimer.text = $"Tempo: {minutos:00}:{segundos:00}";

        if (tempoTotal <= 0f)
        {
            Derrota();
        }
    }

    public void GerarNovaPergunta()
    {
        numero1 = Random.Range(1, 101); 
        numero2 = Random.Range(1, 11);

        
        
        
      operacaoAtual = 'x'; 
      resultadoCorreto = numero1 * numero2;
        
        

        perguntaTexto.text = $"Quanto eh {numero1} {operacaoAtual} {numero2}?";
        inputResposta.text = "";
    }

    public void VerificarResposta()
    {
        if (!jogoAtivo) return;

        if (int.TryParse(inputResposta.text, out int respostaDoJogador))
        {
            if (respostaDoJogador == resultadoCorreto)
            {
                acertosSeguidos++;

                if (acertosSeguidos >= acertosParaVitoria)
                {
                    Vitoria();
                }
                else
                {
                    GerarNovaPergunta();
                }
            }
            else
            {
                Derrota();
            }
        }
        else
        {
            Debug.Log("Por favor, insira um número válido.");
        }
    }

    private void Vitoria()
    {
        jogoAtivo = false;
        telaVitoria.SetActive(true);
    }

    private void Derrota()
    {
        jogoAtivo = false;
        telaDerrota.SetActive(true);
    }
}