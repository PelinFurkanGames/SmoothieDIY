using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Characters")]
    public List<GameObject> characters;
    [SerializeField] GameObject character;

    [Header("Blender-Glass")]
    public GameObject blender;
    public GameObject glass;
    public GameObject blenderLiquid;
    public GameObject glassLiquid;
    public static GameObject fruit;
    public List<Material> liquidMaterials;

    [Header("Fruits")]
    public GameObject banana;
    public static GameObject bananaStatic;
    public GameObject blueberry;
    public static GameObject blueberryStatic;
    public GameObject kiwi;
    public static GameObject kiwiStatic;
    public GameObject mango;
    public static GameObject mangoStatic;
    public GameObject strawberry;
    public static GameObject strawberryStatic;

    [Header("Sounds")]
    public List<AudioClip> audioClips;

    [Header("SmoothiePics")]
    public List<Sprite> smoothiePics;
    public Image smoothiePic;
    public Image smoothieGamePic;
    public static int smoothieNum;

    [Header("Operation")]
    public static bool isGameStarted;
    public static bool gameOver;
    public static bool win;
    public static bool lose;
    public static bool stage1end;
    public static bool stage2end;
    public static bool stage3start;
    public static bool stage3end;
    public static bool stage4start;
    public static bool stage4end;
    public static bool stage5;

    [Header("Panels")]
    public GameObject startPanel;
    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject smoothiePicPanel;
    public GameObject smoothieGamePanel;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;

    [Header("Requirements")]
    public GameObject sceenCenter;
    public GameObject playSceen;
    public GameObject charInst;
    public GameObject cube;
    public GameObject blenderEnd;
    public GameObject glasspoint;
    public GameObject holdPage;
    public static GameObject holdPageStatic;

    [Header("Particle")]
    public GameObject winParticle;

    [Header("Cameras")]
    public GameObject camStart;
    public GameObject camGame;

    [Header("Game Stages")]
    public GameObject stageFirst;

    [Header("Particle Effects")]
    public GameObject freezeParticle;
    public GameObject honeyParticle;
    public static GameObject honeyParticleStatic;
    public GameObject almondParticle;
    public static GameObject almondParticleStatic;
    public GameObject milkParticle;
    public static GameObject milkParticleStatic;

    [Header("EmptyObj")]
    public GameObject clearParticle;
    public static GameObject clearParticleStatic;

    private void Start()
    {
        isGameStarted = false;
        gameOver = false;
        win = false;
        lose = false;
        stage1end = false;
        stage2end = false;
        stage3start=false;
        stage3end=false;
        stage4start = false;
        stage4end=false;
        stage5=false;

        startPanel.SetActive(true);
        CharacterCome();

        strawberryStatic = strawberry;
        bananaStatic = banana;
        blueberryStatic = blueberry;
        kiwiStatic = kiwi;
        mangoStatic = mango;

        clearParticleStatic = clearParticle;
        honeyParticleStatic = honeyParticle;
        almondParticleStatic = almondParticle;
        milkParticleStatic = milkParticle;

        holdPageStatic = holdPage;

    }
    bool control1 = true;
    bool control2=true;
    bool control3Time=true;
    bool control4=true;
    bool control5=true;
    bool control6=true;
    bool control7=true;

    [SerializeField] GameObject fruit6;
    [SerializeField] GameObject fruit7;
    [SerializeField] GameObject blenderC;
    [SerializeField] GameObject blenderL;
    [SerializeField] GameObject glassObj;
    [SerializeField] GameObject gLiq;

    public bool timerIsRunning = false;
    public float time = 0.5f;
    private void Update()
    {
        if (win)
        {
            winPanel.SetActive(true);
            if (control7)
            {
                AudioSource.PlayClipAtPoint(audioClips[0], transform.position);
                control7 = false;
            }
        }
        if (lose)
        {
            losePanel.SetActive(true);
        }
        if (isGameStarted)
        {
            startPanel.SetActive(false);
            smoothiePicPanel.SetActive(false);
            smoothieGamePanel.SetActive(true);
            camStart.SetActive(false);
            camGame.SetActive(true);
            SmoothieType();
            stageFirst.SetActive(true);
            stage1.SetActive(true);
        }
        if (stage1end)
        {
            isGameStarted=false;
            stage1.SetActive(false);
            if (control1)
            {
                StartCoroutine(Freeze());
                control1 = false;
            }
        }
        if (stage2end)
        {
            stage1end = false;
            stage2.SetActive(false);
        }
        if (stage3start)
        {
            stage2end = false;
            stage3.SetActive(true);
        }
        if (stage3end)
        {
            stage3start = false;
            stage3.SetActive(false);
            if (control3Time)
            {
                time = 0.5f;
                StartCoroutine(CleaningHoney());
                control3Time = false;
            }
        }
        if (stage4start)
        {
            stage3end = false;
            stage4.SetActive(true);
            if (control4)
            {
                StartCoroutine(Cleaning());
                Liquid();
                control4 = false;
            }
        }
        if (stage4end)
        {
            stage4start = false;
            stage4.SetActive(false);
            if (control5)
            {
                StartCoroutine(Blender());
                control5 = false;
            }

        }
        if (stage5)
        {
            stage4end = false;
            if (control6)
            {
                camStart.SetActive(true);
                camGame.SetActive(false);
                StartCoroutine(ControlEnd());
                control6 = false;
            }
        }

        if (FruitCreate.honey)
        {
            holdPageStatic.SetActive(true);
            if (MobileInput.instance.hold)
            {
                fruit6 = Instantiate(honeyParticleStatic, FruitCreate.fruitCreatePosStatic.transform.position, Quaternion.identity);
                fruit6.transform.SetParent(clearParticleStatic.transform);
                
                timerIsRunning = true;
            }
            else
            {
                for (int i = 0; i < clearParticle.transform.childCount; i++)
                {
                    if (clearParticle.transform.GetChild(i).name == "Honey3d(Clone)")
                    {
                        Destroy(clearParticle.transform.GetChild(i).gameObject);
                    }
                }
                timerIsRunning = false;
            }
        }
        if (FruitCreate.almond)
        {
            holdPageStatic.SetActive(true);
            if (MobileInput.instance.hold)
            {
                fruit7 = Instantiate(almondParticleStatic, FruitCreate.fruitCreatePosStatic.transform.position, Quaternion.identity);
                fruit7.transform.SetParent(clearParticleStatic.transform);
                
                timerIsRunning = true;
            }
            else
            {
                
                for (int i = 0; i < clearParticle.transform.childCount; i++)
                {
                    if (clearParticle.transform.GetChild(i).name=="almond(Clone)")
                    {
                        Destroy(clearParticle.transform.GetChild(i).gameObject);
                    }
                }
                timerIsRunning = false;
            }

        }
        if (FruitCreate.milk)
        {
            holdPageStatic.SetActive(true);
            if (MobileInput.instance.hold)
            {
                fruit7 = Instantiate(milkParticleStatic, FruitCreate.fruitCreatePosStatic.transform.position, Quaternion.identity);
                fruit7.transform.SetParent(clearParticleStatic.transform);
                
                timerIsRunning = true;
            }
            else
            {
                for (int i = 0; i < clearParticle.transform.childCount; i++)
                {
                    if (clearParticle.transform.GetChild(i).name == "Milk(Clone)")
                    {
                        Destroy(clearParticle.transform.GetChild(i).gameObject);
                    }
                }
                timerIsRunning = false;
            }

        }

        if (timerIsRunning)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 0;
                timerIsRunning = false;
                holdPageStatic.SetActive(false);
                if (FruitCreate.honey)
                {
                    stage3start = true;
                    FruitCreate.honey =false;

                }
                if (FruitCreate.almond)
                {
                    stage3start = true;
                    FruitCreate.almond =false;
                }
                if (FruitCreate.milk)
                {
                    stage4start = true;
                    FruitCreate.milk =false;
                }
                if (fruit6 != null)
                {
                    Destroy(fruit6);
                }
                if (fruit7 != null)
                {
                    Destroy(fruit7);
                }
            }
        }

    }
    void CharacterCome()
    {
        RandomCount();
        character = Instantiate(characters[a], charInst.transform.position,Quaternion.identity);
        character.transform.SetParent(clearParticle.transform);
        character.transform.Rotate(0, -90, 0);
        StartCoroutine(Move(character)); 
    }

    int a,b;
    void RandomCount()
    {
        a = Random.Range(0, characters.Count);
        b= Random.Range(0, smoothiePics.Count);
    }
    IEnumerator Move(GameObject character)
    {
        yield return new WaitForSeconds(0.5f);
        character.transform.DOMove(sceenCenter.transform.position, 1f);
        Vector3 newR = new Vector3( character.transform.rotation.x, character.transform.rotation.y-180, character.transform.rotation.z);
        character.transform.DORotate(newR, 1.2f);
        yield return new WaitForSeconds(0.7f);
        smoothiePic.sprite = smoothiePics[b];
        smoothieGamePic.sprite = smoothiePics[b];
        smoothiePicPanel.SetActive(true);
    }
    void SmoothieType()
    {
        switch (b)
        {
            case 0:
                smoothieNum = 0;
                break;
            case 1:
                smoothieNum = 1;
                break;
            case 2:
                smoothieNum = 2;
                break;
            case 3:
                smoothieNum = 3;
                break;
            case 4:
                smoothieNum = 4;
                break;
            default:
                break;
        }
    }

    
    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(freezeParticle,clearParticle.transform);
        yield return new WaitForSeconds(1f);
        stageFirst.SetActive(false);

        blenderC = Instantiate(blender, clearParticle.transform);
        yield return new WaitForSeconds(0.5f);

        var rb = fruit.GetComponent<Rigidbody>();
        Destroy(rb);
        yield return new WaitForSeconds(0.3f);

        fruit.transform.Rotate(0, 0,0);
        if (fruit.name == "Banana(Clone)")
        {
            fruit.transform.Rotate(0, 0, 60);
        }
        var scale = new Vector3(0.6f, 0.6f, 0.6f);
        fruit.transform.DOScale(scale, 0.5f);

        yield return new WaitForSeconds(0.3f);

        fruit.transform.DOMove(cube.transform.position, 0.3f);

        yield return new WaitForSeconds(0.5f);
        stage2.SetActive(true);
    }
    void Glass()
    {
        glassObj = Instantiate(glass, blenderEnd.transform.position, Quaternion.identity);
        gLiq = Instantiate(glassLiquid, blenderEnd.transform.position, Quaternion.identity);
        gLiq.GetComponent<MeshRenderer>().material = liquidMaterials[material];
        glassObj.transform.SetParent(clearParticle.transform);
        gLiq.transform.SetParent(clearParticle.transform);
        glassObj.transform.Rotate(-90,0, 0);
        gLiq.transform.Rotate(-90,0, 0);
    }
    IEnumerator Blender()
    {        
        yield return new WaitForSeconds(0.3f);
        blenderL.GetComponent<Animator>().Play("Blend");
        yield return new WaitForSeconds(1f);
        blenderL.GetComponent<Animator>().Play("Empty");
        Destroy(fruit);
        blenderC.transform.DOMove(blenderEnd.transform.position, 0.5f);
        blenderL.transform.DOMove(blenderEnd.transform.position, 0.5f);
        Destroy(blenderL);
        Destroy(blenderC);
        
        yield return new WaitForSeconds(0.2f);
        Glass();
        Instantiate(winParticle, clearParticle.transform);
        glassObj.transform.DOMove(glasspoint.transform.position, 0.5f);
        gLiq.transform.DOMove(glasspoint.transform.position, 0.5f);
        yield return new WaitForSeconds(0.5f);

        stage5 = true;
    }
    IEnumerator CleaningHoney()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < clearParticle.transform.childCount; i++)
        {
            if (clearParticle.transform.GetChild(i).name == "almond(Clone)")
            {
                Destroy(clearParticle.transform.GetChild(i).gameObject);
            }
            if (clearParticle.transform.GetChild(i).name == "Honey3d(Clone)")
            {
                Destroy(clearParticle.transform.GetChild(i).gameObject);
            }
        }
    }
    int material;
    IEnumerator Cleaning()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < clearParticle.transform.childCount; i++)
        {
            if (clearParticle.transform.GetChild(i).name == "Milk(Clone)")
            {
                Destroy(clearParticle.transform.GetChild(i).gameObject);
            }
            if (clearParticle.transform.GetChild(i).name == "almond(Clone)")
            {
                Destroy(clearParticle.transform.GetChild(i).gameObject);
            }
            if (clearParticle.transform.GetChild(i).name == "Honey3d(Clone)")
            {
                Destroy(clearParticle.transform.GetChild(i).gameObject);
            }
        }
    }

    private void Liquid()
    {
        blenderL = Instantiate(blenderLiquid, clearParticle.transform);
        var Fname = fruit.name;
        switch (Fname)
        {
            case "Banana(Clone)":
                blenderL.GetComponent<MeshRenderer>().material = liquidMaterials[0];
                material = 0;
                break;
            case "Blueberry(Clone)":
                blenderL.GetComponent<MeshRenderer>().material = liquidMaterials[1];
                material = 1;
                break;
            case "Kiwi(Clone)":
                blenderL.GetComponent<MeshRenderer>().material = liquidMaterials[2];
                material = 2;
                break;
            case "Mango(Clone)":
                blenderL.GetComponent<MeshRenderer>().material = liquidMaterials[3];
                material = 3;
                break;
            case "Strawberry(Clone)":
                blenderL.GetComponent<MeshRenderer>().material = liquidMaterials[4];
                material = 4;
                break;
            default:
                break;
        }
    }
    IEnumerator ControlEnd()
    {
        yield return new WaitForSeconds(1f);
        ControlGlass();
    }
    void ControlGlass()
    {
        switch(smoothieNum) 
        { 
            case 0:
                if (material==0)
                {
                    win = true;
                }
                else
                {
                    lose = true;
                }
                break;
            case 1:
                if (material == 1)
                {
                    win = true;
                }
                else
                {
                    lose = true;
                }
                break;
            case 2:
                if (material == 2)
                {
                    win = true;
                }
                else
                {
                    lose = true;
                }
                break;
            case 3:
                if (material == 3)
                {
                    win = true;
                }
                else
                {
                    lose = true;
                }
                break;
            case 4:
                if (material == 4)
                {
                    win = true;
                }
                else
                {
                    lose = true;
                }
                break;
        }
    }


}
