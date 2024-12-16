using System.Collections;
using System.Collections.Generic;
using Script.Enemy;
using Script.ObjectInTheGround;
using Script.ScriptableObject.Equipment;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[System.Serializable]
public class ItemToDrop : System.Object
{
    public IItemable itemToDrop;
    public float probability;
}
public  class EnemySkeleton : MonoBehaviour ,IDamageAble, IOutlineAble
{
    public EnemyHealthBar EnemyHealthBar;
    public int creaturesLevel;
    public TextMeshPro enemyName;
    public GameObject itemDrop;
    private int _canDropMaxItem;
    public ItemToDrop[] itemToDrops;
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    public CreaturesGroup creaturesGroup=null;
    [FormerlySerializedAs("enemySO")] [SerializeField]
    private MonsterSO enemySo;
    private PolygonCollider2D polygonCollider;
    public Material outlineRed;
    private Material normalMaterial;
    private EnemyHealth EnemyHealth;
    public virtual void  Start()
    {
        EnemyHealth = new EnemyHealth(enemySo.health);
        
        normalMaterial = GetComponent<SpriteRenderer>().material;
        polygonCollider = GetComponent<PolygonCollider2D>();

       
        
        currentHealth = maxHealth;
        enemyName.SetText($"<color=yellow> Lv. {enemySo.level}</color><color=red> {enemySo.monsterName}</color>" );

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
        DropItem(p);
        
        creaturesGroup.currentCreaturesNumber -= 1;
        if (creaturesGroup.currentCreaturesNumber <= 0)
        {

            creaturesGroup.CreateEnemy();
        }
        EnemyEvent.OnDeath?.Invoke((p,enemySo.exp,int.Parse(enemySo.level)));
        p.ExpCalculator(int.Parse(enemySo.exp),int.Parse(enemySo.level));
        Destroy(gameObject);
        
    }

    public virtual void DropItem(Player player)
    {
        if (0 < 1)
        {
            foreach (var canDrop in enemySo.canDrops)
            {
                EnemyEvent.OnDropObject?.Invoke(transform.position,canDrop,player.playerName);
                
                
            }
           
           
        }
        /*foreach (var item in itemToDrops)
        {
            float random = Random.Range(0f, 1f);
            //print(random);
            

        }*/
    }
    
    

    public virtual void Clicked(Material material)
    {
        this.GetComponent<SpriteRenderer>().material = material;
    }

    public virtual Material GetMaterial()
    {
        return this.GetComponent<SpriteRenderer>().material;
    }

    public Vector2 GetPosition()
    {
        return new Vector2( this.transform.position.x,this.transform.position.y);
    }

    public void ResetClicked()
    {
        throw new System.NotImplementedException();
    }
}
