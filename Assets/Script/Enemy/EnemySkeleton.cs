using Script.Anim;
using Script.Interface;
using Script.ScriptableObject.Equipment;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Script.Player;
namespace Script.Enemy
{
    [System.Serializable]
    public class ItemToDrop : System.Object
    {
        public IItemable itemToDrop;
        public float probability;
    }

    public class EnemySkeleton : MonoBehaviour, IDamageAble, IOutlineAble
    {
        private CharacterAnims _characterAnims;
        public TextMeshPro enemyName;
        private EnemyHealth _enemyHealth;
        public CreaturesGroup creaturesGroup = null;
        private PolygonCollider2D polygonCollider;
        private Material normalMaterial;

        [FormerlySerializedAs("enemySO")] [SerializeField]
        private MonsterSO enemySo;
        private PlayerController lastDamagedPlayer;
        public void Start()
        {

            _characterAnims = new CharacterAnims(GetComponent<Animator>(), 0.2f);
            _enemyHealth = new EnemyHealth(enemySo.health);
            this._enemyHealth.OnDeath += Death;
            normalMaterial = GetComponent<SpriteRenderer>().material;
            polygonCollider = GetComponent<PolygonCollider2D>();
            


            enemyName.SetText($"<color=yellow> Lv. {enemySo.level}</color><color=red> {enemySo.monsterName}</color>");

        }

        public void Update()
        {
            transform.position += new Vector3(0.1f, 0.1f, 0f) * Time.deltaTime;
            _characterAnims.UpdateAnim(AnimAndDirection.AnimEnum.Idle, Vector2.left);
            
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
        public void TakeDamage(float damage,PlayerController p)
        {
            // todo: belirli bir cana kadar vuran oyunculara drop atacak bu drop i�in rastgele aralar�ndan bir playerController se�ilecek
            //todo: iki kat e�ya i�in droplar ayarlanacak her playerController i�in ayr� ayr�
            lastDamagedPlayer = p;
            _enemyHealth.TakeDamage(damage);

        }

        public void Death()
        {
           
            EnemyEvent.OnDeath?.Invoke((lastDamagedPlayer,enemySo));
            DropItem(lastDamagedPlayer);
            creaturesGroup.currentCreaturesNumber -= 1;
            if (creaturesGroup.currentCreaturesNumber <= 0)
            {

                creaturesGroup.CreateEnemy();
            }

            
            lastDamagedPlayer.ExpCalculator(int.Parse(enemySo.exp), int.Parse(enemySo.level));
            Destroy(gameObject);

        }

        public void DropItem(PlayerController player)
        {
            if (0 < 1)
            {
                foreach (var canDrop in enemySo.canDrops)
                {
                    GameEvent.OnItemDroppedWithPlayer?.Invoke(transform.position, canDrop, player.playerName);


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

        public void ResetClicked()
        {
            this.GetComponent<SpriteRenderer>().material = normalMaterial;
        }


        public Vector2 GetPosition()
        {
            return new Vector2(this.transform.position.x, this.transform.position.y);
        }

       
    }
}