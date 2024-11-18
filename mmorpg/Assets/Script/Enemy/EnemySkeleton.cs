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
public abstract class EnemySkeleton : MonoBehaviour ,IDamageAble
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
    public MonsterSO enemySO;
    public LineRenderer lineRenderer;
    private PolygonCollider2D polygonCollider;
    public LineRendererForEnemyCreatures LineRendererForEnemyCreatures;
    // Start is called before the first frame update


    public virtual void  Start()
    {
        // �izgi rengi, kal�nl��� ve d�ng� ayarlar�
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.loop = true;
        // Ba�lang��ta gizli tut
        lineRenderer.positionCount = 0;
        // LineRenderer bile�enini al

        polygonCollider = GetComponent<PolygonCollider2D>();

       
        
        currentHealth = maxHealth;
        enemyName.SetText($"<color=yellow> Lv. {enemySO.level}</color><color=red> {enemySO.monsterName}</color>" );

    }
    public virtual void Update()
    {
        transform.position += new Vector3(0.1f, 0.1f, 0f)  * Time.deltaTime;
    }
    public virtual void GenerateOutline( )
    {

        {
            // Polygon collider'dan k��e noktalar�n� al
            Vector2[] points = polygonCollider.points;

            // LineRenderer i�in nokta say�s�n� ayarla
            lineRenderer.positionCount = points.Length + 1; // �lk ve son nokta ayn� olmal�

            // Her bir noktay� d�nya koordinatlar�na d�n��t�r ve ayarla
            for (int i = 0; i < points.Length; i++)
            {
                Vector3 worldPos = transform.TransformPoint(points[i]);
                worldPos.z = -0.1f; // Z pozisyonunu 0 yap
                lineRenderer.SetPosition(i, worldPos);
            }

            // �izgiyi kapatmak i�in ilk noktay� sonuna ekleyin
            lineRenderer.SetPosition(points.Length, lineRenderer.GetPosition(0));
        }
    }
    public virtual void TakeDamage(float damage)
    {
        // todo: belirli bir cana kadar vuran oyunculara drop atacak bu drop i�in rastgele aralar�ndan bir player se�ilecek
        //todo: iki kat e�ya i�in droplar ayarlanacak her player i�in ayr� ayr�
        print(currentHealth + "absstractt");
        currentHealth -= damage;
        if (currentHealth <= 0) Death();
        print("hasar ald� �imdiki can:" + currentHealth);
    }
    public virtual void Death()
    { 
        foreach(var item in itemToDrops)
        {
            float random = Random.Range(0f, 1f);
            print(random);
            if(random < item.probability)
            {
                GameObject drop = Instantiate(itemDrop, RandomPositionByObjectCircle(), Quaternion.identity);
                drop.GetComponent<ItemDropGameObject>().Playername.text = "player";
                drop.GetComponent<ItemDropGameObject>().itemName.text = item.itemToDrop.name;
            }
            
        }
        creaturesGroup.currentCreaturesNumber -= 1;
        if (creaturesGroup.currentCreaturesNumber <= 0)
        {

            creaturesGroup.CreateEnemy();
        }
        Destroy(gameObject);
        
    }
    Vector3 RandomPositionByObjectCircle()
    {
        Vector2 position = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 1f, transform.position.y + 1f));
        return new Vector3(position.x, position.y, 0);
    }

}
