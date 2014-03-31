using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Element element;
	public MapViewer mapViewer;

	void Update () {

		if(Input.GetMouseButtonUp(0) ){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100)) {
				
				Element selectedElement = Map.Instance.GetElementAt(new Vector3(hit.collider.transform.position.x, Mathf.Abs (hit.collider.transform.position.y), 0) + mapViewer.GetPosition());
				if(selectedElement != null && selectedElement.isControllable) {
					element = selectedElement;
				}
			}
		}

		//Everything below here only happens if you have a unity selected
		if(element == null) return;

		if(Input.GetMouseButtonUp(1) ){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100)) {

				Vector3 destination = new Vector3(hit.collider.transform.position.x, Mathf.Abs (hit.collider.transform.position.y), 0) + mapViewer.GetPosition();

				element.SetDestination(destination);
			}
		}


	}

}
