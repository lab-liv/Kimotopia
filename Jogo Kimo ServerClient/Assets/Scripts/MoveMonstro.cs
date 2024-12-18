using UnityEngine;
using System.Collections;


public class MoveMonstro : MonoBehaviour {


    //void Update()
   // {
   //     transform.position = new Vector3( transform.position.x + 2.0f, 0.0f, transform.postion.z + 2.0f);
   // }

  /*  
    public GameObject playerTY;
    //posi��o do player para gerar posi��o do objeto ao redor dele
    private Vector3 playerPosition;

    //velocidade de deslocamento do objeto
    private float velocidade;
    //velocidade de rota��o para suavizar o movimento
    private float rotateSpeed;


    int cont;

    void Start() {
        velocidade = 0.5f;
        rotateSpeed = 2.0f;
        //voltou = true;
        cont = 0;
        //objeto inicia fora da mira
        //SetGazedAt(naMira);
        //inicia anima��o dos monstros
        transform.GetComponent<Animation>().Play("move");
        TeleportRandomly();
    }

    void Update() {
        //if (GameController.is_paused)
            return;
        if (GameController.playing_monstro)
        {
            //pega posi��o do player
            playerPosition = playerVR.transform.localPosition;

            //teleporta para proximo ao player quando volta do pause
            if (voltou)
            {
                cont += 1;
                TeleportRandomly();
                if (cont == 4)
                {
                    cont = 0;
                    voltou = false;
                }
            }

            //pega posi��o do alvo (menino)
            Vector3 targetPosition = playerTY.transform.position;
            //mantem objetos que nao voam no ch�o
            if (transform.tag != "Nao_Voa")
            {   //aumenta o y para n�o atravessar o ch�o
                targetPosition.y = targetPosition.y + 1;
            }
            //move objeto em dire��o ao alvo (menino)
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * velocidade);
            //transform.position = transform.position + (targetPosition - transform.position) * Time.deltaTime * velocidade;
            //rotaciona objeto para ficar olhando para o alvo (menino)
            LookAtPoint(playerTY.transform.position);

            //se apertou o botao e esta na mira, acertou!

        }
    }

    public void SetGazedAt(bool gazedAt) {
        //seta variavel de controle
        if (gazedAt) naMira = true;
        else naMira = false;
    }

    //chamada quando ocorre o "click" e acerta o alvo
    public void TeleportRandomly() {
        //pega posi��o do player
        playerPosition = playerVR.transform.localPosition;
        //sorteia nova posicao para o objeto ao redor do player
        Vector3 direction = new Vector3(Random.Range(playerPosition.x - 13f, playerPosition.x + 10f), 
                                        Random.Range(playerPosition.y - 0.5f, playerPosition.y + 3f), 
                                        Random.Range(playerPosition.z, playerPosition.z + 10f));
        //mantem objetos que nao voam no ch�o
        if (transform.tag == "Nao_Voa") direction.y = transform.position.y;
        //sorteia nova velocidade para o objeto
        velocidade = Random.Range(GameController.min_dificuldade, GameController.max_dificuldade);
        //move objeto para nova posi��o
        transform.localPosition = direction;
    }

    //faz objeto olhar na dire��o do alvo
    private void LookAtPoint(Vector3 target) {
        //pega posi��o do objeto
        Vector3 position = transform.position;
        //calcula dire��o entre o alvo e o objeto
        Vector3 direction = target - position;
        //retira rota��o em y
        direction.y = 0;
        //calcula a rota��o a ser aplicada
        Quaternion newRotation = Quaternion.FromToRotation(Vector3.forward, direction);
        //aplica a rota��o no objeto
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //detecta se o monstro colidiu com o alvo (menino)
        if (collision.gameObject.tag == "Player")
        {
            //se colidiu perde vida
            Score.PerdeSaude();
            TeleportRandomly();
        }
        //detecta se o monstro colidiu com um remedio
        if (collision.gameObject.tag == "Remedio")
        {
            TeleportRandomly();
            //incrementa os pontos
            Score.AddScore(1f);
        }
    }*/
}
