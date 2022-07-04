using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Script que nos permite configurar el temporizador mediante un slider

public class TemporizadorSlider : MonoBehaviour
{

    Slider tempSlider; // slider
    TextMeshProUGUI tempText; // texto que indica los segundos

    public float gameTime = 20.0f; // tiempo que preestablecido que tiene el juego, en el nivel 2 lo hemos cambiado desde unity 
    Image fillImage;
    public Color32 normalFillColor; // color que indica que queda mas de la mitad del tiempo
    public Color32 warninglFillColor; // color que indicara que el tiempo se está acabando
    public float warningLimit; //Limite de tiempo antes de que vaya a finalizar

    public bool stopTemp; // Parar temporizador

    TextMeshProUGUI finJuegoText; // Fin del juego texto

    // Iniciamos el temporizador y la cuenta de tiempo con el color verde(normalFillColor), aparte le pasamos al slider el tiempo que va a tener la partida.
    // FinJuegoText lo dejamos en false hasta que no acabe el juego
    // Start is called before the first frame update
    void Start()
    {
        stopTemp = false;
        gameObject.GetComponent<Disparo>().enabled = true;
        finJuegoText = GameObject.FindGameObjectWithTag("FinJuegoText").GetComponent<TextMeshProUGUI>();
        finJuegoText.gameObject.SetActive(false);

        tempSlider = GameObject.FindGameObjectWithTag("TemporizadorSlider").GetComponent<Slider>();
        tempText = GameObject.FindGameObjectWithTag("TemporizadorText").GetComponent<TextMeshProUGUI>();

        fillImage = GameObject.FindGameObjectWithTag("SliderFill").GetComponent<Image>();

        tempSlider.maxValue = gameTime;
        tempSlider.value = gameTime;
        fillImage.color = normalFillColor;


        
    }

    // Actualizacion del slider con el tiempo que falta, en caso de acabar la partida desaparecen todos los enemigos
    // El slider va cambiando segun pasa el tiempo y cuando llega al warning limit cambiará de color, mientras tanto se mostrarán los segundos que queden
    // Una vez acabado el tiempo finalizará la partida no pudiendose disparar más, en el caso de estar en el nivel 1, podras ir al nivel 2 o al Menú.
    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        string textTime = "Tiempo sobra: " + gameTime.ToString("f0") + "s";

        if(stopTemp == false){
            tempText.text = textTime;
            tempSlider.value = gameTime;
        }

        if(tempSlider.value < ((warningLimit/100)*tempSlider.maxValue )){
            fillImage.color = warninglFillColor;
        }

        // Una vez que se activa fin juego text activamos tambien los botones para el siguiente nivel o menú
        
        if(gameTime <= 0 && stopTemp == false){
            stopTemp = true;
            gameObject.GetComponent<Disparo>().enabled = false;
            Destroy(tempSlider.gameObject);
            finJuegoText.gameObject.SetActive(true);

            GameObject[] enemigos =  GameObject.FindGameObjectsWithTag("Spider");
            foreach (GameObject enemigo in enemigos)
                Destroy(enemigo); // de esta manera eliminamos todos los enemigos cuando acaba el tiempo

        }


    }


}
