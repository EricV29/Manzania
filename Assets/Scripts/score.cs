using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    /*
    //BOTON CERRAR JUEGO
    private AssetBundle myLoadedAssetBundle;
    private string scenePaths = "Scenes/Menu";
    */

    public Texture2D manzanaTexture; // La imagen de la manzana
    public Texture2D vida100Texture; // La imagen de la vida al 80-100
    public Texture2D vida60Texture; // La imagen de la vida al 60-80
    public Texture2D vida40Texture; // La imagen de la vida al 40-60
    public Texture2D vida1Texture; // La imagen de la vida al 1-40
    public Texture2D vida0Texture; // La imagen de la vida al 0

    //TEXTURA LOSE
    public Texture2D loseTexture; // La imagen de perder
    private Vector2 posLose = new Vector2(250, 130); //Posición de la etiqueta en la pantalla

    //MANZANAS RECOLECTADAS
    public int apples = 0; //Variable para almacenar el numero de manzanas
    private Vector2 posApples = new Vector2(1, 1); //Posición de la etiqueta en la pantalla
    private GUIStyle estiloApples = new GUIStyle(); //Estilo de la etiqueta

    //VIDA DE MALUS
    public int life = 100; //Variable para almacenar la vida del personaje
    private Vector2 posLife = new Vector2(800, 1); //Posición de la etiqueta en la pantalla
    private GUIStyle estiloLife = new GUIStyle(); //Estilo de la etiqueta

    //FIN DEL JUEGO
    public FirstPersonMovement fin;
    public FirstPersonLook finc;

    //CAMARAS DEL JUEGO
    public Camera camerawin; //camara winner
    public Camera cameraplayer; //camara player

    void Start()
    {
        Cursor.visible = false;
        camerawin.enabled = false;
        cameraplayer.enabled = true;

        //ETIQUETA APPLES
        estiloApples.fontSize = 40;//Establecer el tamaño de fuente de la etiqueta apples
        estiloApples.normal.textColor = new Color(255, 0, 0);//Establecer el color de la etiqueta apples

        //ETIQUETA LIFE
        estiloLife.fontSize = 30;//Establecer el tamaño de fuente de la etiqueta life
        estiloLife.normal.textColor = new Color(0, 255, 0);//Establecer el color de la etiqueta life

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        //PERDER
        if (life == 0)
        {
            CerrarAplicacion();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //MANZANA ROJA
        if (col.gameObject.CompareTag("red"))
        {
            apples += 1; //Suma 1 manzana recolectada
            Destroy(col.gameObject);
        }

        //MANZANA VERDE
        if (col.gameObject.CompareTag("green"))
        {
            if (life >= 100) { 
            }
            else
            {
                life += 5; //Suma 5 puntos de vida
                if (life > 100)
                {
                    life = 100;
                }
            }
        }

        //MANZANA MORADA
        if (col.gameObject.CompareTag("purple"))
        {
            if (life == 0)
            {
                Invoke("CerrarAplicacion", 1f);
            }
            else
            {
                life -= 20; //Resta 5 puntos de vida
                if(life <= 0)
                {
                    Invoke("CerrarAplicacion", 1f);
                    life = 0;
                }
            }
        }

        //MANZANA DORADA
        if (col.gameObject.CompareTag("gold"))
        {
            if (life >= 100)
            {
            }
            else
            {
                life += 15; //Suma 15 puntos de vida
                if (life > 100)
                {
                    life = 100;
                }
            }
        }

        //NAVE GANAR
        if (col.gameObject.CompareTag("shipw"))
        {
            FindObjectOfType<winner>().scoreS = this;
        }

        //DANO ENEMIGO
        if (col.gameObject.CompareTag("enemy"))
        {
            life -= 10;
        }

    }
    void CerrarAplicacion()
    {
        fin.enabled = false;
        finc.enabled = false;
        Invoke("irMenu", 4.0f);

    }

    void irMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void OnGUI()
   {
        //ETIQUETA APPLES
        //GUI.Label(new Rect(posApples.x, posApples.y, 200, 50), "MANZANAS: " + apples, estiloApples);
        GUI.DrawTexture(new Rect(posApples.x, posApples.y, 50, 50), manzanaTexture); // Dibuja la imagen de la manzana
        GUI.Label(new Rect(posApples.x + 60, posApples.y, 200, 50), "" + apples, estiloApples); // Muestra el número de manzanas al lado de la imagen

        //ETIQUETA LIFE
        //GUI.Label(new Rect(posLife.x, posLife.y, 200, 50), "VIDA: " + life, estiloLife);
        if (life >= 80 && life <= 100) 
        { 
            GUI.DrawTexture(new Rect(posLife.x, posLife.y, 50, 50), vida100Texture); // Dibuja la imagen de la manzana
            GUI.Label(new Rect(posLife.x + 60, posLife.y, 200, 50), "" + life, estiloLife); // Muestra el número de manzanas al lado de la imagen
        }else if (life >= 60 && life < 80) 
        {
            GUI.DrawTexture(new Rect(posLife.x, posLife.y, 50, 50), vida60Texture); // Dibuja la imagen de la manzana
            GUI.Label(new Rect(posLife.x + 60, posLife.y, 200, 50), "" + life, estiloLife); // Muestra el número de manzanas al lado de la imagen
        }
        else if (life >= 40 && life < 60)
        {
            GUI.DrawTexture(new Rect(posLife.x, posLife.y, 50, 50), vida40Texture); // Dibuja la imagen de la manzana
            GUI.Label(new Rect(posLife.x + 60, posLife.y, 200, 50), "" + life, estiloLife); // Muestra el número de manzanas al lado de la imagen
        }
        else if (life >= 1 && life < 40)
        {
            GUI.DrawTexture(new Rect(posLife.x, posLife.y, 50, 50), vida1Texture); // Dibuja la imagen de la manzana
            GUI.Label(new Rect(posLife.x + 60, posLife.y, 200, 50), "" + life, estiloLife); // Muestra el número de manzanas al lado de la imagen
        }
        else if (life == 0)
        {
            GUI.DrawTexture(new Rect(posLife.x, posLife.y, 50, 50), vida0Texture); // Dibuja la imagen de la manzana
            GUI.Label(new Rect(posLife.x + 60, posLife.y, 200, 50), "" + life, estiloLife); // Muestra el número de manzanas al lado de la imagen
            //ETIQUETA PERDEDOR
            GUI.DrawTexture(new Rect(posLose.x, posLose.y, 500, 150), loseTexture);
        }
    }

    public void WaitForEnd()
    {
        SceneManager.LoadScene("Menu");
    }
}
