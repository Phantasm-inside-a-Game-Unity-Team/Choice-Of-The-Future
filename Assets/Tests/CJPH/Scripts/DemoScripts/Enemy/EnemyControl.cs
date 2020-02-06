using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{
    public int enemyHP;
    public AEnemyModeManager enemyModeManager;
    public float enemySize { get { return enemyModeManager.enemySize; } }       //敌人判定半径
    public bool isDead;

    Animator enemyAnimator;
    AnimatorStateInfo stateInfo;

    // Use this for initialization
    void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP < 1 && isDead==false)
        {
            enemyAnimator.SetBool("isDead", true);
            isDead = true;
            DemoSceneManager.Instance.enemies.Remove(gameObject);
        }
        if (isDead)
        {
            stateInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsTag("Disappear") && stateInfo.normalizedTime >= 1)
            {
                GetComponent<ItemDrop>().RandomItemDrop();
                Destroy(gameObject);
            }
        }
    }
}
