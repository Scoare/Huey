using UnityEngine;

public class BossCallAttack : MonoBehaviour
{
    public void attack(int triggerIndex) {
        transform.Find("AttackTriggers").GetChild(triggerIndex).GetComponent<BossCanAttack>().enabled = true;
    }
}
