using System;
using Script.Anim;
using Script.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Script.Player;
using UnityEditor.Animations;

namespace Script.Enemy
{   

    public class EnemySkeleton : MonoBehaviour, IDamageAble, IOutlineAble,IPoolable
    {
        private CharacterAnims _characterAnims;
        public TextMeshPro enemyName;
        private EnemyHealth _enemyHealth;
        public CreaturesGroup creaturesGroup = null;
        private PolygonCollider2D _polygonCollider;
        private Material _normalMaterial;

        [FormerlySerializedAs("enemySO")] [SerializeField]
        private MonsterSO enemySo;
        private PlayerController _lastDamagedPlayer;
        
        private Vector3 _startPosition;
        public void Initialize(MonsterSO monsterSo, AnimatorController animatorController)
        {
            this.enemySo = monsterSo;
            this.GetComponent<Animator>().runtimeAnimatorController = animatorController;
        }
        public void Awake()
        {
            _startPosition = transform.position;
            _characterAnims = new CharacterAnims(GetComponent<Animator>(), 0.2f);
            _enemyHealth = new EnemyHealth(enemySo.health);
            this._enemyHealth.OnDeath += Death;
            _normalMaterial = GetComponent<SpriteRenderer>().material;
            _polygonCollider = GetComponent<PolygonCollider2D>();
            
            enemyName.SetText($"<color=yellow> Lv. {enemySo.level}</color><color=red> {enemySo.monsterName}</color>");
        }

        private void OnEnable()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            transform.position += new Vector3(0.1f, 0.1f, 0f) * Time.deltaTime;
            _characterAnims.UpdateAnim(AnimationEnum.Idle, Vector2.left);
            
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
            _lastDamagedPlayer = p;
            _enemyHealth.TakeDamage(damage);

        }

        public void Death()
        {
           
            EnemyEvent.OnDeath?.Invoke((_lastDamagedPlayer,enemySo));
            creaturesGroup.OnEnemyDeath();
            DropItem(_lastDamagedPlayer);
            _lastDamagedPlayer.ExpCalculator(int.Parse(enemySo.exp), int.Parse(enemySo.level));
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
            this.GetComponent<SpriteRenderer>().material = _normalMaterial;
        }


        public Vector2 GetPosition()
        {
            return new Vector2(this.transform.position.x, this.transform.position.y);
        }


        public string GetPoolType()
        {
            return enemySo.monsterName;
        }
    }
}