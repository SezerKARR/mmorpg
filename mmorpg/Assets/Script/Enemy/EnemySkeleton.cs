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
    private int canDropMaxÝtem;
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
        // Çizgi rengi, kalýnlýðý ve döngü ayarlarý
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.loop = true;
        // Baþlangýçta gizli tut
        lineRenderer.positionCount = 0;
        // LineRenderer bileþenini al

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
            // Polygon collider'dan köþe noktalarýný al
            Vector2[] points = polygonCollider.points;

            // LineRenderer için nokta sayýsýný ayarla
            lineRenderer.positionCount = points.Length + 1; // Ýlk ve son nokta ayný olmalý

            // Her bir noktayý dünya koordinatlarýna dönüþtür ve ayarla
            for (int i = 0; i < points.Length; i++)
            {
                Vector3 worldPos = transform.TransformPoint(points[i]);
                worldPos.z = -0.1f; // Z pozisyonunu 0 yap
                lineRenderer.SetPosition(i, worldPos);
            }

            // Çizgiyi kapatmak için ilk noktayý sonuna ekleyin
            lineRenderer.SetPosition(points.Length, lineRenderer.GetPosition(0));
        }
    }
    public virtual void TakeDamage(float damage)
    {
        // todo: belirli bir cana kadar vuran oyunculara drop atacak bu drop için rastgele aralarýndan bir player seçilecek
        //todo: iki kat eþya için droplar ayarlanacak her player için ayrý ayrý
        print(currentHealth + "absstractt");
        currentHealth -= damage;
        if (currentHealth <= 0) Death();
        print("hasar aldý þimdiki can:" + currentHealth);
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
