using UnityEngine;

public class ArrowTraps : MonoBehaviour
{
   [SerializeField] 
   private float attackCooldown;
   [SerializeField] 
   private Transform firePoint;
   [SerializeField] 
   private GameObject[] Arrows;
   private float coolDowntimer;

private void attack()
{
    coolDowntimer = 0;


    Arrows[Findarrow()].transform.position = firePoint.position;
    Arrows[Findarrow()].GetComponent<EnemyProjectile>().ActiveProjectile();
}
private int Findarrow()
{
    for (int i = 0; i < Arrows.Length; i++)
    {
        if(!Arrows[i].activeInHierarchy)
        return i;
    }   
    return 0;
}
private void Update()
{
    coolDowntimer += Time.deltaTime;
    if(coolDowntimer >= attackCooldown)
        attack();
}

}



// public class EnemyProjectile : MonoBehaviour
// {
//   [SerializeField] protected float damage;


//   protected void OnTriggerEnter2D(Collider2D collision)
//   {
//     if(collision.tag == "Player")
//         collision.GetComponent<Health>().takeDamage(damage);
//   }
// }