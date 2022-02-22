using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBrick : MonoBehaviour
{


    public GameObject coinPrefab;

    //   This bool enables toggle in inspector 
    public bool hasCoin;

	

	void OnKill()
	{
		/*--    This assins the player class to this local variable playa
			 *   | [local variable playa]
			 *   |	   |  We use the (GameObject.Find) method to accses the player Gameobject and contune with the .GetComponet method of type <Player>
				 |     |				  |			Now we can use the player. variable we made.
				 |     |				  |
				 V	   V				  V					*/
		Playa playa = GameObject.Find("Playa").GetComponent<Playa>();



		if (hasCoin)
		{

			//       --------------------GameObject.Instantiate(Prefab); [spawns an object]------------


			GameObject coinObject = GameObject.Instantiate(coinPrefab);
			coinObject.transform.position = transform.position + new Vector3(0.20f, 2.8f, 0);


			// This refernces the coin script so the coin can vanish whsn swaned in this object
			Coin coin = coinObject.GetComponent<Coin>();
			coin.Vanish();


			// Informs the player that they have colleted a coin
			playa.onCollectCoin();
		}


		playa.OnDestroySkyBrick();
	}

}
