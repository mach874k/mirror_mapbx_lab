namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Unity.Map;
	using UnityEngine;
	using Mirror;
	using System.Collections;

	public class ImmediatePositionWithLocationProvider : MonoBehaviour
	{

		bool _isInitialized;

		ILocationProvider _locationProvider;
		ILocationProvider LocationProvider
		{
			get
			{
				if (_locationProvider == null)
				{
					_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
				}

				return _locationProvider;
			}
		}

		Vector3 _targetPosition;

		void Start()
		{
			LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
			StartCoroutine(__LocalGetPos());
		}

		private IEnumerator __LocalGetPos(){
			WaitForSeconds wait = new WaitForSeconds(0.5f);
			while(true){
				transform.position = ReturnLocationProviderPos(); 
				yield return wait;
			}
		}

        private Vector3 ReturnLocationProviderPos(){
			var map = LocationProviderFactory.Instance.mapManager;
			Vector3 vector_pos = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
			return vector_pos; 
		}

	}
}