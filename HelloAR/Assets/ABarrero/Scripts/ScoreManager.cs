using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Este código chequea cuando el círculo de color se pone verde y es más pequeño que el blanco,
el tiempo que se demora en llegar a ese punto es 3.4 segundos.
La animación total se demora 4.2 segundos, así que después de ese tiempo la animación empieza 
otra vez y también el reloj de este código
Las funciones sólo se activan al ser llamadas por el SampleImageTarget del EasyAR
Este script combina una lógica de juego y la UI, cosa que no se debe hacer pero bueno
Si quieres diferentes tiempos de animación y de control debes modificar la animación y 
luego modificar los valores de este código*/
//Recordar porner en modo "Preferir calidad"

public class ScoreManager : MonoBehaviour {

	private int score=0;				//Puntaje
	public Text UI_score;				//Texto en la UI
	private float time;					//Contará los segundos

	void Start(){
		SetScore(); //Para iniciar el puntaje en 0 y mostrarlo
	}
	public void AddPoint(){
		if (time > 3.4f) {   	//Recuerda que esto se basa en la animación del círculo de color. 
			//Esta función se llama cuando el render desaparezca y si el círculo de color es de menor tamaño y que el blanco, añade un punto
			score++;
			SetScore ();     	//Actualiza por pantalla
			ReSetTime ();		
		}
	}

	private void SetScore(){
		//Esto lo único que hace poner el score en la pantalla
		UI_score.text = "Puntaje: "+score;
	}

	void Update(){
		time+=Time.deltaTime;		//Esto es lo que hace que cuente el tiempo
		if (time > 4.2f)			//Se utiliza para reiniciar el tiempo cuando acabe la animación y no se haya anotado un punto  
									//y tampoco se haya perdido la renderización del AR
			ReSetTime ();			//Recordad que 4.2 es la duración de la animación y si se cambia la animación se debe 
									//cambiar acá también y viseversa.
	}

	public void ReSetTime(){
		//Se reinicia el conteo del tiempo cada vez que se anota un punto o se acaba de crear un nuevo
		//objeto AR
		time = 0.0f;
	}
}
