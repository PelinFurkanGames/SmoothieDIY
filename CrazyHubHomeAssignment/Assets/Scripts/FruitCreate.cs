using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCreate : MonoBehaviour
{
    public GameObject fruitCreatePos;
    public static GameObject fruitCreatePosStatic;
    [SerializeField] string fruitName;

    public static bool honey,almond,milk = false;
    private void Start()
    {
        fruitCreatePosStatic = fruitCreatePos;
    }
    public void CreateFruit()
   {
        switch (fruitName)
        {
            case "Banana":
                GameObject fruit= Instantiate(GameManager.bananaStatic, fruitCreatePos.transform.position, Quaternion.identity);
                fruit.transform.SetParent(GameManager.clearParticleStatic.transform);
                GameManager.fruit = fruit;
                GameManager.stage1end = true;
                break;
            case "Blueberry":
                GameObject fruit2 = Instantiate(GameManager.blueberryStatic, fruitCreatePos.transform.position, Quaternion.identity);
                fruit2.transform.SetParent(GameManager.clearParticleStatic.transform);
                GameManager.fruit = fruit2;
                GameManager.stage1end = true;
                break;
            case "Strawberry":
                GameObject fruit3 = Instantiate(GameManager.strawberryStatic, fruitCreatePos.transform.position, Quaternion.identity);
                fruit3.transform.SetParent(GameManager.clearParticleStatic.transform);
                GameManager.fruit = fruit3;
                GameManager.stage1end = true;
                break;
            case "Kiwi":
                GameObject fruit4 = Instantiate(GameManager.kiwiStatic, fruitCreatePos.transform.position, Quaternion.identity);
                fruit4.transform.SetParent(GameManager.clearParticleStatic.transform);
                GameManager.fruit = fruit4;
                GameManager.stage1end = true;
                break;
            case "Mango":
                GameObject fruit5 = Instantiate(GameManager.mangoStatic, fruitCreatePos.transform.position, Quaternion.identity);
                fruit5.transform.SetParent(GameManager.clearParticleStatic.transform);
                GameManager.fruit = fruit5;
                GameManager.stage1end = true;
                break;
            case "Honey":
                MobileInput.instance.tap = false;
                MobileInput.instance.hold = false;
                GameManager.stage2end = true;
                honey = true;
                break;
            case "Almond":
                MobileInput.instance.tap = false;
                MobileInput.instance.hold = false;
                GameManager.stage2end = true;
                almond = true;
                break;
            case "Milk":
                MobileInput.instance.tap = false;
                MobileInput.instance.hold = false;
                GameManager.stage3end = true;
                milk = true;
                break;
            case "Blender":
                MobileInput.instance.tap = false;
                MobileInput.instance.hold = false;
                GameManager.stage4end = true;
                break;
            default:
                break;
        }
        
   }

}
