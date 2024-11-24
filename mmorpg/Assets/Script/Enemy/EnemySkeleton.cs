using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
[System.Serializable]
public class ItemToDrop : System.Object
{
    public ScriptableObject itemToDrop;
    public float probability;
}
public abstract class EnemySkeleton : MonoBehaviour ,IDamageAble, IOutlineAble
{
    public EnemyHealthBar EnemyHealthBar;
    public int creaturesLevel;
    public TextMeshPro enemyName;
    public GameObject itemDrop;
    private int canDropMax�tem;
    public ItemToDrop[] itemToDrops;
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    public CreaturesGroup creaturesGroup=null;
    [SerializeField]
    private MonsterSO enemySO;
    private PolygonCollider2D polygonCollider;
    public Material outlineRed;
    private Material normalMaterial;
    
    public virtual void  Start()
    {
        normalMaterial = GetComponent<SpriteRenderer>().material;
        polygonCollider = GetComponent<PolygonCollider2D>();

       
        
        currentHealth = maxHealth;
        enemyName.SetText($"<color=yellow> Lv. {enemySO.level}</color><color=red> {enemySO.monsterName}</color>" );

    }
    
    public virtual void Update()
    {
        transform.position += new Vector3(0.1f, 0.1f, 0f)  * Time.deltaTime;
    }

    /*public virtual void Outline(Color color)
    {
        if (color == Color.red)
        {
            this.GetComponent<SpriteRenderer>().material = outlineRed;
        }
        else if (color == Color.gray)
        {

            this.GetComponent<SpriteRenderer>().material = normalMaterial;
        }
    }*/
    public virtual void TakeDamage(float damage, Player p)
    {
        // todo: belirli bir cana kadar vuran oyunculara drop atacak bu drop i�in rastgele aralar�ndan bir player se�ilecek
        //todo: iki kat e�ya i�in droplar ayarlanacak her player i�in ayr� ayr�
        print(currentHealth + "absstractt");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death(p);
        }
        ////print("hasar ald� �imdiki can:" + currentHealth);
        

    }
    public virtual void Death(Player p)
    {
        DropItem();
        
        creaturesGroup.currentCreaturesNumber -= 1;
        if (creaturesGroup.currentCreaturesNumber <= 0)
        {

            creaturesGroup.CreateEnemy();
        }
        p.ExpCalculator(int.Parse(enemySO.exp),int.Parse(enemySO.level));
        Destroy(gameObject);
        
    }

    public virtual void DropItem()
    {
        foreach (var item in itemToDrops)
        {
            float random = Random.Range(0f, 1f);
            //print(random);
            if (random < item.probability)
            {
                GameObject drop = Instantiate(itemDrop, RandomPositionByObjectCircle(), Quaternion.identity);
                drop.GetComponent<ItemDropGameObject>().Playername.text = "player";
                drop.GetComponent<ItemDropGameObject>().scriptableObject = item.itemToDrop;
            }

        }
    }
    Vector3 RandomPositionByObjectCircle()
    {
        Vector2 position = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 1f, transform.position.y + 1f));
        return new Vector3(position.x, position.y, 0);
    }

    public virtual void Outline(Material material)
    {
        this.GetComponent<SpriteRenderer>().material = material;
    }
}
