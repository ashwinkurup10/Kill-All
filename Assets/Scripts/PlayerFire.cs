using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{

	private int currentAmmo;
	public int ammo;
	private bool outOfAmmo;
	public float showBulletInMagDelay = 0.6f;
	public SkinnedMeshRenderer bulletInMagRenderer;

	PlayerControls controls;
	Animator anim;
	public AudioSource mainAudioSource;
	public AudioSource shootAudioSource;
	public class soundClips
	{
		public AudioClip shootSound;
		public AudioClip takeOutSound;
		public AudioClip holsterSound;
		public AudioClip reloadSoundOutOfAmmo;
		public AudioClip reloadSoundAmmoLeft;
		public AudioClip aimSound;
	}
	public soundClips SoundClips;



	void Awake()
	{
		controls = new PlayerControls();

		controls.GamePlay.rel.performed += ctx => rel();


	}




	private void Reload()
	{

		if (outOfAmmo == true)
		{
			//Play diff anim if out of ammo
			anim.Play("Reload Out Of Ammo", 0, 0f);

			mainAudioSource.clip = SoundClips.reloadSoundOutOfAmmo;
			mainAudioSource.Play();

			//If out of ammo, hide the bullet renderer in the mag
			//Do not show if bullet renderer is not assigned in inspector
			if (bulletInMagRenderer != null)
			{
				bulletInMagRenderer.GetComponent
				<SkinnedMeshRenderer>().enabled = false;
				//Start show bullet delay
				StartCoroutine(ShowBulletInMag());
			}
		}
		else
		{
			//Play diff anim if ammo left
			anim.Play("Reload Ammo Left", 0, 0f);

			mainAudioSource.clip = SoundClips.reloadSoundAmmoLeft;
			mainAudioSource.Play();

			//If reloading when ammo left, show bullet in mag
			//Do not show if bullet renderer is not assigned in inspector
			if (bulletInMagRenderer != null)
			{
				bulletInMagRenderer.GetComponent
				<SkinnedMeshRenderer>().enabled = true;
			}
		}
		//Restore ammo when reloading
		currentAmmo = ammo;
		outOfAmmo = false;
	}

	private IEnumerator ShowBulletInMag()
	{

		//Wait set amount of time before showing bullet in mag
		yield return new WaitForSeconds(showBulletInMagDelay);
		bulletInMagRenderer.GetComponent<SkinnedMeshRenderer>().enabled = true;
	}

	void rel()
	{
		Reload();
	}


}