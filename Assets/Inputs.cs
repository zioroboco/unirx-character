using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Inputs : MonoBehaviour {
    
    public static Inputs Instance { get; private set; }
    public IObservable<Vector2> Movement { get; private set; }

    private void Awake() {
        
        Instance = this;
        
        Movement = this.FixedUpdateAsObservable()
            .Select(_ => {
                var x = Input.GetAxisRaw("Horizontal");
                var y = Input.GetAxisRaw("Vertical");
                return new Vector2(x, y).normalized;
            });
    }
    
}
