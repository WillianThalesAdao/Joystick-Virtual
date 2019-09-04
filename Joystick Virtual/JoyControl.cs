using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Joycontrol : MonoBehavior, IDragHandler, IPointerDowHandler, IPointerUpHandler {


[SerializeField]
private Image bgImg;
[SerializeField]

//essa imagem é a bolinha que aparece na tela
private image JoyImg;


public Vector3 inputDir;


//pega o bgimg usando a primeira linha, a segunda linha pega a outra img que está dentro do bg
private void Start ()
{
    bgImg = GetComponent<Image>();
    JoyImg = transform.GetChild(0).GetComponent<Image>();
}
public virtual void OnDrag(PointerEventData ped)
{
//cria uma estrutura condicional para trabalhar com a posiçaõ
    Vector2 pos;
    if(RectTransdormUtility.ScreenPointToLocalPointRectangle(bgImg.rectTransform,ped.position,ped.pressEventCamera,out pos))
    {
        //Esse sizeDelta retorna a diferença entre o retangulo real do elemento da interface e o retangulo das prizilias
       pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
       pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
       //Esse inputDir = new Vector3(pos.x * 2,pos.y,0); faz que a imagem do analogico fique dentro do circulo, casoo joystick fique lento é só alterar a velocidade trocando o 2
        inputDir = new Vector3(pos.x * 2,pos.y,0);
        //Esse inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir; faz com que a imagem do analogico fique limitada dentro do circulo, sem ficar rodando por toda a tela
        inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir; 
        //Esse Joyimg mexe com a imagem do joystick que aparece na tela

        //Esse JoyImg.rectTransform.anchoredPosition deixa a bolinha do analogico presa dentro do circulo
        JoyImg.rectTransform.anchoredPosition = new Vector3(inputDir.x * (bgImg.rectTransform.sizeDelta.x / 3),inputDir.y * (bgImg.rectTransform.y));

        
    }
}

public virtual void OnPointerDown(PointerEventData ped)
{
    OnDrag(ped);
}

public virtual void OnPointerUp(PointerEventData ped)
{
    //vai fazer o joystick voltar para o meio da img do analogico
    inputDir = Vector3.zero;
    JoyImg.rectTransform.anchoredPosition = Vector3.zero;
}

//com isso eu termino o joystick virtual podendo usar ele em outro codigo fazendo o movimento comoutra entidade
public float Hori()
{
    if(inputDir.x != 0)
    {
        return inputDir.x;
    }
    else
    {
        return inputDir.GetAxis("Horizontal");
    }
}

public float vert()
{
    if(inputDir.y != 0)
    {
        return inputDir.x;
    }
    else
    {
        return inputDir.GetAxis("Vertical");
    }

}


//aula 445, 446, 447, 448 controle virtual